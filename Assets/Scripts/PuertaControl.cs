using UnityEngine;

public class PuertaControl : MonoBehaviour
{
    Animator anim;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        anim = GetComponentInChildren<Animator>();
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
