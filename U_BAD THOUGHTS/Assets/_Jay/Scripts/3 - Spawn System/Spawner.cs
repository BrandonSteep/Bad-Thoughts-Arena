using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private ToSpawnSO[] spawnableWaves;
    
    [SerializeField] private Transform spawnPointHolder;
    [SerializeField] private Transform[] spawnPoints;

    private int waveToSpawn;

    void Start(){
        spawnPointHolder = GameObject.FindWithTag("SpawnPoints").transform;
        
        spawnPoints = new Transform[spawnPointHolder.transform.childCount];
        for(int i = 0; i < spawnPointHolder.transform.childCount; i++){
            spawnPoints[i] = spawnPointHolder.transform.GetChild(i);
        }
    }


    private void EventCalled(){
        // Debug.Log("10 SECONDS!!!!!");
        SpawnPointRNG();
    }

    private void SpawnPointRNG(){
        waveToSpawn = Random.Range(0, spawnableWaves.Length);
        if (spawnableWaves[waveToSpawn].waveType.ToString() == "bossWave")
        {
            OnBossSpawn();
        }
        Spawn(waveToSpawn);
    }

    private void Spawn(int wave){
        for(int i = 0; i < spawnableWaves[wave].GameObjectsToSpawn.Length; i++){
            int spawnPointId = Random.Range(0, spawnPoints.Length);
            Instantiate(spawnableWaves[wave].GameObjectsToSpawn[i], spawnPoints[spawnPointId].position, Quaternion.identity);
        }
    }

    public delegate void BossWave();
    public static event BossWave OnBossSpawn;

#region SubscribeToEvent
    void OnEnable(){
        Timer.TimedEvent += EventCalled;
    }

    void OnDisable(){
        Timer.TimedEvent -= EventCalled;
    }
    #endregion
}
