using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    [SerializeField] private WaveSpawnEnemy[] waveSpawnEnemy;
    [SerializeField] private Transform[] spawnPos;
    [SerializeField] private WaitForSeconds wait;
    [SerializeField] public List<UnitEnemy> unitEnemies;
    private bool isLock = false;
    private int indexWave;
    public int maxWaves;
    public int curentWave = 1;



    private void Start()
    {
        StartCoroutine(Spawn());
    }
    public IEnumerator Spawn()
    {
        for (int i = 0; i < waveSpawnEnemy.Length; i++)
        {
            indexWave = i;
            isLock = waveSpawnEnemy[i].WaitDestroyEnemy;
            yield return new WaitWhile(() => isLock);
            wait = new WaitForSeconds(waveSpawnEnemy[i].DelaySpawn);
            yield return wait;
            if (waveSpawnEnemy[i].WaitDestroyEnemy)
            {
                curentWave++;
            }
            for (int j = 0; j < spawnPos.Length; j++)
            {
                UnitEnemy prefab = Instantiate(waveSpawnEnemy[i].unitEnemyPrefab, spawnPos[j].transform);
                unitEnemies.Add(prefab);
            }
        }
    }
    private void Update()
    {
        //if (isLock)
        //{
            for (int i = unitEnemies.Count - 1; i >= 0; i--)
            {
                if (unitEnemies[i].stats.Health <= 0)
                {
                    unitEnemies.Remove(unitEnemies[i]);
                }
            }
            isLock = !(unitEnemies.Count == 0);
        //}
        
    }

    public WaveSpawnEnemy GetInfoWave()
    {
        return waveSpawnEnemy[indexWave];
    }
}