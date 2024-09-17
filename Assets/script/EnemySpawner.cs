using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;           // Prefab del enemigo
    public Transform[] spawnPoints;          // Array de puntos de spawn
    public int poolSize = 5;                 // Tamaño de la pool de enemigos
    public float spawnInterval = 2f;         // Intervalo de tiempo entre apariciones

    private List<GameObject> enemyPool;      // Pool de enemigos
    private int currentEnemyIndex = 0;       // Índice actual de la pool
    private float nextSpawnTime = 0f;        // Tiempo para el próximo spawn

    void Start()
    {
        // Inicializamos la pool de enemigos
        enemyPool = new List<GameObject>();
        for (int i = 0; i < poolSize; i++)
        {
            GameObject enemy = Instantiate(enemyPrefab);
            enemy.SetActive(false);  // Desactivamos el enemigo inicialmente
            enemyPool.Add(enemy);
        }
        Debug.Log("Pool de enemigos creada con " + poolSize + " enemigos.");
    }

    void Update()
    {
        // Spawnear enemigos a intervalos regulares
        if (Time.time >= nextSpawnTime)
        {
            SpawnEnemy();
            nextSpawnTime = Time.time + spawnInterval;
        }
    }

    void SpawnEnemy()
    {
        // Obtenemos el siguiente enemigo de la pool
        GameObject enemy = enemyPool[currentEnemyIndex];
        if (!enemy.activeInHierarchy)
        {
            // Elegimos un punto de spawn aleatorio
            Transform spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];

            // Posicionamos al enemigo en el punto de spawn y lo activamos
            enemy.transform.position = spawnPoint.position;
            enemy.SetActive(true);
            Debug.Log("Enemigo " + (currentEnemyIndex + 1) + " spawneado en " + spawnPoint.position);

            // Avanzamos al siguiente enemigo en la pool
            currentEnemyIndex = (currentEnemyIndex + 1) % poolSize;
        }
        else
        {
            Debug.Log("El enemigo " + (currentEnemyIndex + 1) + " ya está activo.");
        }
    }
}
