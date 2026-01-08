using Unity.Netcode;
using UnityEngine;
using UnityEngine.InputSystem;

public class JugadorControl : NetworkBehaviour
{
    public InputAction mover;
    public InputAction saltar;

    public float velocidad = 5;
    public float fuerzaSalto = 5;

    public int puedoSaltar = 0;

    //public int llave = 0; //Reemplazado por la siguiente linea
    public NetworkVariable<int> llave = new NetworkVariable<int>(
    0,
    NetworkVariableReadPermission.Everyone,
    NetworkVariableWritePermission.Server
    ); //Nuevo, De esta forma el otro jugador tambien sabrá si esto cambia o no

    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        if (IsOwner)
        {
            saltar.Enable();
            mover.Enable();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(!IsOwner) return;

        float dir = mover.ReadValue<float>();
        //booelana para que el cliente pueda mandarle al server si se esta pulsando la tecla de saltar
        bool salto = saltar.triggered;

        MoverServerRpc(dir, salto);
    }

    [ServerRpc]
    void MoverServerRpc(float dir, bool salto)
    {
        if (salto && puedoSaltar > 0)
        {
            rb.AddForce(Vector3.up * fuerzaSalto, ForceMode2D.Impulse);
        }

        rb.linearVelocity = new Vector2(dir * velocidad, rb.linearVelocityY);
        Debug.Log("Pulsando");
    
    }
    

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("suelo")) puedoSaltar++;
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("suelo")) puedoSaltar--;
    }
}
