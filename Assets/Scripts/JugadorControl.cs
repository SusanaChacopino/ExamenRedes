using UnityEngine;
using UnityEngine.InputSystem;

public class JugadorControl : MonoBehaviour
{
    public InputAction mover;
    public InputAction saltar;

    public float velocidad = 5;
    public float fuerzaSalto = 5;

    public int puedoSaltar = 0;

    public int llave = 0;

    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        saltar.Enable();
        mover.Enable();
    }

    // Update is called once per frame
    void Update()
    {
        if (saltar.triggered && puedoSaltar > 0)
        {
            rb.AddForce(Vector3.up * fuerzaSalto, ForceMode2D.Impulse);
        }

        float dir = mover.ReadValue<float>();
        rb.linearVelocity = new Vector2(dir * velocidad, rb.linearVelocityY);
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
