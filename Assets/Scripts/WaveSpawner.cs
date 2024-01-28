
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class WaveSpawner : MonoBehaviour

{
    public static WaveSpawner instance;
    [SerializeField]
    GameObject[] enemyPrefabs;
    [SerializeField]
    GameObject miniBoss;
    [SerializeField]
    Transform[] spawnLocations;
    [SerializeField]
    float spawnInterval = 3f;

    public float spawnTimer;
    public float waveTimer;

    [SerializeField]
    float waveDuration = 10f;
    public int currWave = 0;


    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    
    private void Update()
    {
        spawnTimer += Time.deltaTime;
        waveTimer -= Time.deltaTime;

        if (waveTimer >= 0)
        {
            if(spawnTimer >= spawnInterval )
            {
                GameObject enemyToSpawn = enemyPrefabs[Random.Range(0, enemyPrefabs.Length)];
                Instantiate(enemyToSpawn, spawnLocations[Random.Range(0, spawnLocations.Length)].position, Quaternion.identity);

                
                spawnTimer = 0;
            }
            
        }
        else if(waveTimer < 0)
        {
            currWave++;
            if(currWave % 3 == 0)
            {
                if(spawnInterval == 1.2)
                {
                    spawnInterval -= 0.01f;
                }
                else
                {
                    spawnInterval -= 0.3f;
                }
            }
            if(currWave == 10)
            {
                SpawnMiniBoss();
            }
            
            waveTimer = waveDuration;
        }
    }
    public void SpawnMiniBoss()
    {

        Instantiate(miniBoss, spawnLocations[Random.Range(0,spawnLocations.Length)].position, Quaternion.identity);
    }
  
}
