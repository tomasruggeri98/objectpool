using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public GameObject projectilePrefab;  // El prefab del proyectil
    public Transform firePoint;          // El punto desde donde se disparan los proyectiles
    public int poolSize = 5;             // Tamaño máximo de la pool
    private List<GameObject> projectilePool;  // Lista para manejar la pool
    private int currentProjectileIndex = 0;   // Índice para gestionar el proyectil actual
    private bool canShoot = true;             // Controla si el jugador puede disparar

    void Start()
    {
        // Inicializamos la pool de proyectiles
        projectilePool = new List<GameObject>();
        for (int i = 0; i < poolSize; i++)
        {
            GameObject proj = Instantiate(projectilePrefab);
            proj.SetActive(false);  // Desactivamos el proyectil inicialmente
            projectilePool.Add(proj);
        }
        Debug.Log("Pool de proyectiles creada con " + poolSize + " proyectiles.");
    }

    void Update()
    {
        // Disparar proyectil cuando presionamos la tecla Espacio y se puede disparar
        if (Input.GetKeyDown(KeyCode.Space) && canShoot)
        {
            Shoot();
        }

        // Recargar los proyectiles cuando presionamos la tecla R
        if (Input.GetKeyDown(KeyCode.R))
        {
            ReloadProjectiles();
        }
    }

    void Shoot()
    {
        // Verificamos si el proyectil actual está inactivo en la pool
        GameObject projectile = projectilePool[currentProjectileIndex];
        if (!projectile.activeInHierarchy)
        {
            // Activamos el proyectil y lo posicionamos en el punto de disparo
            projectile.transform.position = firePoint.position;
            projectile.transform.rotation = firePoint.rotation;
            projectile.SetActive(true);
            Debug.Log("Disparando proyectil " + (currentProjectileIndex + 1) + " desde la pool.");

            // Avanzamos al siguiente proyectil en la pool
            currentProjectileIndex = (currentProjectileIndex + 1) % poolSize;

            // Si hemos usado todos los proyectiles, no podemos disparar más hasta recargar
            if (currentProjectileIndex == 0)
            {
                canShoot = false;
                Debug.Log("Todos los proyectiles han sido disparados. Necesitas recargar.");
            }
        }
        else
        {
            Debug.Log("El proyectil " + (currentProjectileIndex + 1) + " ya está activo, no se puede disparar.");
        }
    }

    void ReloadProjectiles()
    {
        // Desactivar todos los proyectiles y permitir disparar nuevamente
        foreach (GameObject proj in projectilePool)
        {
            proj.SetActive(false);
        }
        canShoot = true;
        Debug.Log("Proyectiles recargados. Puedes disparar nuevamente.");
    }
}
