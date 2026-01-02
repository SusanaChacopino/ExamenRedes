using UnityEngine;

public class PuertaLlaveControl : MonoBehaviour
{
    Animator anim;

    public int codigo = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        anim = GetComponentInChildren<Animator>();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            JugadorControl jc = collision.GetComponent<JugadorControl>();
            if (jc.llave == codigo) // debe llevar la llave con el codigo de esta puerta
            {
                Abrir();
            }
        }
    }

    public void Abrir()
    {
        anim.SetBool("abierta", true);
    }

    public void Cerrar()
    {
        anim.SetBool("abierta", false);
    }
}
