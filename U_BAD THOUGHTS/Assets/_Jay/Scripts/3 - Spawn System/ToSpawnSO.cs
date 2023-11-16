using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Wave")]
public class ToSpawnSO : ScriptableObject
{
    public string waveName;
    public GameObject[] GameObjectsToSpawn;
    
    public enum Type{ standardWave, bossWave, powerUpWave };
    public Type waveType;
}
