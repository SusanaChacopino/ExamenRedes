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
        anim.SetBool("PuertaAnimControlAbrir", true);
    }

    public void Cerrar()
    {
        anim.SetBool("PuertaAnimControlAbrir", false);
    }
}
