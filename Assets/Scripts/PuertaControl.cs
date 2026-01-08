using Unity.Netcode; //Nuevo
using UnityEngine;

public class PuertaControl : NetworkBehaviour
{
   Animator anim;

   private NetworkVariable<bool> estaAbierta = new NetworkVariable<bool>(
   false,
   NetworkVariableReadPermission.Everyone,
   NetworkVariableWritePermission.Server
); // Nuevo: Booleana que mantendra la logica en toda la red; Si un player abre la puerta, pues se abre en todas,
   // ademas de que produce el llamado del evento OnEstadoPuertaCambiado


    void Start()
    {
        anim = GetComponentInChildren<Animator>();
        estaAbierta.OnValueChanged += OnEstadoPuertaCambiado;//Nuevo: significa: "SI el valor de estaAbierta cambia, llama a la variableOnEstadoPuertaCambiado"
    }

    //TODA ESTA FUNCION ES NUEVA
    //Esta funcion terminaria reemplazando a la de abrir y cerrar de abajo.
    void OnEstadoPuertaCambiado(bool valorAnterior, bool valorNuevo)
    {
        anim.SetBool("abierta", valorNuevo);
    }

    public void Abrir()
    {
        //anim.SetBool("abierta", true); // Reemplazada por la funcion OnEstadoPuertaCambiado
        if (!IsServer) return; //Nuevo
        estaAbierta.Value = true; //Nuevo
    }

    public void Cerrar()
    {
        //anim.SetBool("abierta", false); // Reemplazada por la funcion OnEstadoPuertaCambiado
        if(!IsServer) return; //Nuevo
        estaAbierta.Value = false; //Nuevo
    }


    //-------------------------- OPCIONAL ------------------------

    /* 
     *
     public override void OnDestroy() // Si tuviesemos mas niveles seria ultra necesario. Como solo es un nivel, este codigo no se va a ejecutar.
     {
         estaAbierta.OnValueChanged -= OnEstadoPuertaCambiado;
         base.OnDestroy();
     }

     */
}
