using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable] 
public class WaveSpawnEnemy 
{
    [field: SerializeField] public float DelaySpawn {  get; private set; }
    [field: SerializeField] public UnitEnemy unitEnemyPrefab {  get; private set; }
    [field: SerializeField] public bool WaitDestroyEnemy { get; private set; }
}
