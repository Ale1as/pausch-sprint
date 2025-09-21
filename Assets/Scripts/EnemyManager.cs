using System.Xml.Schema;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public int totalEnemies;
    bool keySpawned = false;
    [SerializeField] GameObject keyPrefab;
    [SerializeField] Transform spawnPoint;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        totalEnemies = FindAnyObjectByType<Spawner>().maxEnemies * 6;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!keySpawned && FindAnyObjectByType<Player_health>().killCount == totalEnemies)
        {
            Instantiate(keyPrefab, spawnPoint.position, Quaternion.identity);
            keySpawned = true;
        }

    }
}
