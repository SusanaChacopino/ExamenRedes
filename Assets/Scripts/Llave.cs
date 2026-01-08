using UnityEngine;
using Unity.Netcode; //Nuevo

public class Llave : NetworkBehaviour 
{
    public int codigo = 0;
    
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (!IsServer) return; //Nuevo

        if (collision.CompareTag("Player"))
        {
            JugadorControl jc = collision.GetComponent<JugadorControl>();
            if(jc.llave.Value == 0) //Nuevo ".Value"
            {
                jc.llave.Value = codigo;
                //Destroy(gameObject); //Reemplazada por la siguiente linea
                GetComponent<NetworkObject>().Despawn(); //Nuevo: Esta es la forma de destruir el objeto en la red, osea, en todos los clientes.
            }
        }
    }
}
