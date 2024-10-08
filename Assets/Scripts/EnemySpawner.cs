using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private List<WaveConfigSO> _waveConfigSo;
    [SerializeField] bool isLooping;
    private float timeBetweenWaves;
    private WaveConfigSO _currentWave;
    private int enemyCount;


    void Start()
    {
        Spawner();
    }
    
    public WaveConfigSO getCurrentWave()
    {
        return _currentWave;
    }

    // Corrected IEnumerator and yield keyword
    private IEnumerator SpawningEnemyWaves()
    {
        do{
        foreach(WaveConfigSO waves in _waveConfigSo){
            enemyCount = waves.EnemyCount();
            _currentWave = waves;
        for (int i = 0; i < enemyCount; i++)
        {
            Instantiate(waves.GetEnemyPrefab(0), waves.GetStartingWaypoint().position, Quaternion.identity, transform);
            yield return new WaitForSeconds(waves.GetSpawnTime());
        }
        yield return new WaitForSeconds(timeBetweenWaves);
        }
        } while (isLooping);
    }

    private void Spawner()
    {
        // Corrected StartCoroutine spelling
        StartCoroutine(SpawningEnemyWaves());
    }
}