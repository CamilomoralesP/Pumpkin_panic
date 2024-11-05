using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    public GameObject enemyPrefab;    // Prefab del enemigo
    public Transform[] spawnPoints;   // Puntos de respawn
    public float respawnTime = 1f;    // Tiempo entre respawns
    public int maxEnemies = 5;        // Máximo de enemigos permitidos
    
    private int currentEnemyCount = 0; // Contador de enemigos actuales
    // Start is called before the first frame update
    void Start()
    {
        // Iniciar el ciclo de respawn
        StartCoroutine(SpawnEnemies());
    }

    // Coroutine para el respawn de enemigos
    IEnumerator SpawnEnemies()
    {
        while (true)
        {
            if (currentEnemyCount < maxEnemies)
            {
                SpawnEnemyAtRandomPoint(); // Llamada al método de respawn
            }
            yield return new WaitForSeconds(respawnTime); // Esperar el tiempo de respawn
        }
    }

    // Método para generar un enemigo en un punto de respawn aleatorio
    void SpawnEnemyAtRandomPoint()
    {
        int randomIndex = Random.Range(0, spawnPoints.Length);
        GameObject newEnemy = Instantiate(enemyPrefab, spawnPoints[randomIndex].position, Quaternion.identity);

        currentEnemyCount++;
    }

    // Método para reducir el número de enemigos cuando uno muere
    public void OnEnemyDestroyed()
    {
        currentEnemyCount--; // Reducir el contador de enemigos actuales
    }

}