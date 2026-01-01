using UnityEngine;

public class BotonControl : MonoBehaviour
{
    public PuertaControl puerta;

    private int pulsando = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D (Collider2D collision)
    {
        if (pulsando == 0) puerta.Abrir();
        pulsando++;
    }

    void OnTriggerExit2D (Collider2D collision)
    {
        pulsando--;
        if (pulsando == 0) puerta.Cerrar();
    }
}
