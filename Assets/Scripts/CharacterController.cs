using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D rb2D; // Asigna el componente Rigidbody2D desde el inspector.

    public float moveSpeed = 5.0f; // Velocidad de movimiento en el eje X.
    public float jumpForce = 10.0f; // Fuerza de salto.

    private bool isGrounded = false; // Variable para verificar si el personaje está en el suelo.

    void Update()
    {
        // Verifica las teclas para mover el personaje en el eje X.
        float horizontalInput = Input.GetAxis("Horizontal");
        Vector2 movement = new Vector2(horizontalInput * moveSpeed, rb2D.velocity.y);

        rb2D.velocity = movement;

        // Verifica si el personaje está en el suelo para permitir un salto.
        if (isGrounded && Input.GetButtonDown("Jump")) // Asegúrate de configurar la entrada de salto en el Input Manager.
        {
            // Realiza un salto en el eje Y.
            rb2D.velocity = new Vector2(rb2D.velocity.x, jumpForce);
        }
    }

    // Método para verificar si el personaje está en el suelo.
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    // Método para verificar cuando el personaje deja de tocar el suelo.
    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }
}
