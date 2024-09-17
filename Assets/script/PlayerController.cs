using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;  // Velocidad de movimiento del jugador

    private Vector2 movement;

    void Update()
    {
        // Obtener las entradas del teclado (flechas o WASD)
        float moveX = Input.GetAxis("Horizontal"); // Movimiento horizontal (izquierda y derecha)
        float moveY = Input.GetAxis("Vertical");   // Movimiento vertical (arriba y abajo)

        // Actualizar el vector de movimiento con las entradas del teclado
        movement = new Vector2(moveX, moveY);
    }

    void FixedUpdate()
    {
        // Mover al jugador basado en el vector de movimiento
        transform.Translate(movement * moveSpeed * Time.fixedDeltaTime);
    }
}
