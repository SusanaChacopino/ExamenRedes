using UnityEngine;
using Unity.Netcode;

public class MetaControl : NetworkBehaviour
{

    public GameObject letreroGanar;
    private NetworkVariable<bool> partidaGanada = new NetworkVariable<bool>(
        false,
        NetworkVariableReadPermission.Everyone,
        NetworkVariableWritePermission.Server
    ); //Nuevo 

    private void Start()
    {
        partidaGanada.OnValueChanged += OnPartidaGanada;
    }

    void OnPartidaGanada(bool oldValue, bool newValue)
    {
        if (newValue)
        {
            letreroGanar.SetActive(true);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (!IsServer) return; //Nuevo

        if (collision.CompareTag("Player"))
        {
            //HAN GANADO
            //letreroGanar.SetActive(true); //Reemplazada por la funcion void OnPartidaGanada
            partidaGanada.Value = true;
        }
    }
}
