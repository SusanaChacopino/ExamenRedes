using UnityEngine;
using Unity.Netcode;

public class BotonControl : NetworkBehaviour
{
    public PuertaControl puerta;

    void OnTriggerEnter2D (Collider2D collision)
    {
        if (!IsServer) return; //Nuevo

       // if (pulsando == 0) puerta.Abrir();
       // pulsando++;
       puerta.Abrir();
    }

    void OnTriggerExit2D (Collider2D collision)
    {
        if (!IsServer) return; //Nuevo

        // pulsando--;
        // if (pulsando == 0) puerta.Cerrar();
        puerta.Cerrar();
    }
}
