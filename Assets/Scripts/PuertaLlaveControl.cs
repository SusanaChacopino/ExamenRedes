using Unity.Netcode;
using UnityEngine; //Nuevo

public class PuertaLlaveControl : NetworkBehaviour
{
    Animator anim;

    public int codigo = 0;

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

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (!IsServer) return; //Nuevo

        if(collision.CompareTag("Player"))
        {
            JugadorControl jc = collision.GetComponent<JugadorControl>();
            if (jc.llave.Value == codigo) // debe llevar la llave con el codigo de esta puerta
            {
                Abrir();
            }
        }
    }

    public void Abrir()
    {
        //anim.SetBool("abierta", true); //ya no se ejecuta aqui
        estaAbierta.Value = true;
    }

    public void Cerrar() //No se ejecuta. Lo dejo por si algo, pero podria borrarse
    {
        anim.SetBool("abierta", false);
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
