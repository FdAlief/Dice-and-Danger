using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    public List<GameObject> listEnemy = new List<GameObject>();
    public int minEnemy; // Jumlah minimal enemy
    public int maxEnemy; // Jumlah maksimal enemy
    public float xmin;
    public float xmax;
    public float zmin;
    public float zmax;
    public Transform parentSpawnEnemy;

    void Start()
    {
        SpawnEnemies();
    }

    void SpawnEnemies()
    {
        int enemyNumber = UnityEngine.Random.Range(minEnemy, maxEnemy + 1);

        for (int i = 0; i < enemyNumber; i++)
        {
            float spawnX = UnityEngine.Random.Range(xmin, xmax);
            float spawnZ = UnityEngine.Random.Range(zmin, zmax);
            Vector3 spawnPosition = new Vector3(spawnX, 0, spawnZ);
            Quaternion spawnRotation = Quaternion.Euler(0, UnityEngine.Random.Range(0f, 360f), 0);

            // Pilih secara acak prefab enemy dari list
            GameObject selectedEnemyPrefab = listEnemy[UnityEngine.Random.Range(0, listEnemy.Count)];

            // Instantiate enemy
            GameObject enemy = Instantiate(selectedEnemyPrefab, spawnPosition, spawnRotation);

            // Set enemy sebagai child dari spawner untuk organisasi
            enemy.transform.parent = parentSpawnEnemy;
        }
    }
}
