using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private WaveConfigSO _waveConfigSo;
    private int enemyCount;

    void Awake()
    {
        enemyCount = _waveConfigSo.EnemyCount();
    }

    void Start()
    {
        Spawner();
    }
    
    public WaveConfigSO getCurrentWave()
    {
        return _waveConfigSo;
    }

    void Update()
    {
    }

    // Corrected IEnumerator and yield keyword
    private IEnumerator StartSpawning()
    {
        for (int i = 0; i < enemyCount; i++)
        {
            Instantiate(_waveConfigSo.GetEnemyPrefab(0), _waveConfigSo.GetStartingWaypoint().position, Quaternion.identity, transform);
            yield return new WaitForSeconds(1.3f);
        }
    }

    private void Spawner()
    {
        // Corrected StartCoroutine spelling
        StartCoroutine(StartSpawning());
    }
}