using UnityEngine;

public class Llave : MonoBehaviour
{
    public int codigo = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            JugadorControl jc = collision.GetComponent<JugadorControl>();
            if(jc.llave == 0)
            {
                jc.llave = codigo;
                Destroy(gameObject);
            }
        }
    }
}
