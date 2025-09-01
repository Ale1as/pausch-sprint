using UnityEngine;

public class Spawner : MonoBehaviour
{
    [Header("Enemy Settings")]
    public GameObject enemyPrefab;         // Enemy to spawn
    public int maxEnemies = 20;            // Optional limit on enemies (-1 for infinite)

    [Header("Spawn Settings")]
    public float spawnInterval = 3f;       // Time between spawns

    private float spawnTimer = 0f;
    private int currentEnemyCount = 0;

    void Update()
    {
        // Count down
        spawnTimer -= Time.deltaTime;

        // Spawn when timer hits zero
        if (spawnTimer <= 0f)
        {
            if (maxEnemies == -1 || currentEnemyCount < maxEnemies)
            {
                SpawnEnemy();
            }
            spawnTimer = spawnInterval;
        }
    }

    void SpawnEnemy()
    {
        // Spawn enemy
        GameObject enemy = Instantiate(enemyPrefab, new Vector3(gameObject.transform.position.x,1f,gameObject.transform.position.z + 2f), gameObject.transform.rotation);

        currentEnemyCount++;
    }
}
