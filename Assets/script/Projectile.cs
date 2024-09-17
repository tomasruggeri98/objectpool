using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed = 10f;
    public float lifeTime = 2f;  // Tiempo que el proyectil estar� activo antes de desactivarse

    void OnEnable()
    {
        // Cuando el proyectil se activa, invocamos el m�todo para desactivarlo despu�s de `lifeTime` segundos
        Debug.Log("Proyectil activado.");
        Invoke("DisableProjectile", lifeTime);
    }

    void Update()
    {
        // El proyectil se mueve hacia adelante
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        // Si colisiona con algo, se desactiva
        Debug.Log("Proyectil colision� con " + collision.gameObject.name + " y ser� desactivado.");
        DisableProjectile();
    }

    void DisableProjectile()
    {
        // Desactivar el proyectil
        Debug.Log("Proyectil desactivado.");
        gameObject.SetActive(false);
        CancelInvoke();  // Cancelamos la invocaci�n en caso de que choque antes de tiempo
    }
}
