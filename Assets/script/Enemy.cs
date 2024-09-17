using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 3f;         // Velocidad de movimiento del enemigo
    public float maxLifeTime = 4f;   // Tiempo máximo de vida del enemigo antes de desactivarse

    private float lifeTimer;         // Temporizador para llevar el control del tiempo de vida

    void OnEnable()
    {
        // Cuando el enemigo se activa, reiniciamos el temporizador
        lifeTimer = 0f;
        Debug.Log("Enemigo activado.");
    }

    void Update()
    {
        // Movimiento de derecha a izquierda
        transform.Translate(Vector2.left * speed * Time.deltaTime);

        // Incrementamos el temporizador con el tiempo transcurrido
        lifeTimer += Time.deltaTime;

        // Si el temporizador excede el tiempo máximo de vida, desactivamos el enemigo
        if (lifeTimer >= maxLifeTime)
        {
            Debug.Log("Tiempo de vida máximo alcanzado. Enemigo desactivado.");
            DisableEnemy();
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        // Si el enemigo colisiona con algo, se desactiva y vuelve a la pool
        Debug.Log("Enemigo colisionó con " + collision.gameObject.name + " y será desactivado.");
        DisableEnemy();
    }

    void DisableEnemy()
    {
        // Desactivar el enemigo y devolverlo a la pool
        Debug.Log("Enemigo desactivado y retornado a la pool.");
        gameObject.SetActive(false);
    }
}
