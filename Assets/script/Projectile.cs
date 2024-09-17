using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed = 10f;
    public float lifeTime = 2f;  // Tiempo que el proyectil estará activo antes de desactivarse

    void OnEnable()
    {
        // Cuando el proyectil se activa, invocamos el método para desactivarlo después de `lifeTime` segundos
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
        Debug.Log("Proyectil colisionó con " + collision.gameObject.name + " y será desactivado.");
        DisableProjectile();
    }

    void DisableProjectile()
    {
        // Desactivar el proyectil
        Debug.Log("Proyectil desactivado.");
        gameObject.SetActive(false);
        CancelInvoke();  // Cancelamos la invocación en caso de que choque antes de tiempo
    }
}
