using System.Collections.Generic;

using UnityEngine;

public class EnemySpawnManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> enemiesPrefabs;
    [SerializeField] private GameObject spawnArea;

    [SerializeField] private int maxEnemies;
    [SerializeField] private float enemiesSpawnDelay;
    [SerializeField] private float enemiesSpawnInterval;

    private int activeEnemiesCount = 0;
    // Start is called before the first frame update
    private void Start()
    {
        InvokeRepeating(nameof(SpawnEnemiesWave), enemiesSpawnDelay, enemiesSpawnInterval);
    }

    // Update is called once per frame
    private void Update()
    {

    }

    private void SpawnEnemiesWave()
    {
        if (activeEnemiesCount == maxEnemies)
        {
            return;
        }

        var spawnPosition = spawnArea.GetComponent<SpawnArea>().GetRandomSpawnPosition();

        var enemy = CreateEnemy();

        Instantiate(enemy, spawnPosition, enemy.transform.rotation);

        activeEnemiesCount++;
    }

    private GameObject CreateEnemy()
    {
        var enemyIndex = Random.Range(0, enemiesPrefabs.Count);

        return enemiesPrefabs[enemyIndex];
    }
}
