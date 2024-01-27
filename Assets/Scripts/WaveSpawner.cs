using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class WaveSpawner : MonoBehaviour
{
    public static WaveSpawner instance;
    public List<Enemy> enemies = new List<Enemy>();
    
    public List<GameObject> enemiesToSpawn = new List<GameObject>();

    public List<Transform> spawnLocations = new List<Transform>();
    public int waveDuration;
    private float waveTimer;
    private float spawnInterval;
    private float spawnTimer;
    public int currWave;
    [SerializeField]
    private int waveValue;

    
    
    private void Awake()
    {
        if(instance == null)
        {
            instance =  this;
        }
        else
        {
            Destroy(gameObject);
        }
        
    }
    //Start is called before the first frame update
    void Start()
    {
        GenerateWave(); 
    }
  
    
    // Update is called once per frame
    void FixedUpdate()
    {
        if (spawnTimer <= 0)
        {
            if(enemiesToSpawn.Count > 0)
            {
                Instantiate(enemiesToSpawn[0], spawnLocations[Random.Range(0,spawnLocations.Count)].position, Quaternion.identity);
                enemiesToSpawn.RemoveAt(0);
                spawnTimer = spawnInterval;
            }
            else
            {
                waveTimer = 0;
                GameManager.instance.afterWave = true;
                
            }
        }
        else
        {
            spawnTimer -= Time.fixedDeltaTime;
            waveTimer -= Time.fixedDeltaTime;
        }
    }
    public void GenerateWave()
    {
        waveValue = currWave * 2;
        GenerateEnemies();

        spawnInterval = waveDuration / enemiesToSpawn.Count;
        waveTimer = waveDuration;

    }
    public void GenerateEnemies()
    {
        List<GameObject> generatedEnemies = new List<GameObject>();
        while (waveValue > 0)
        {
            int randEnemyId = Random.Range(0, enemies.Count);
            int randEnemyCost = enemies[randEnemyId].cost;

            if(waveValue-randEnemyCost >= 0)
            {
                generatedEnemies.Add(enemies[randEnemyId].enemyPrefab);
                waveValue -= randEnemyCost;
            }
            else if (waveValue <= 0)
            {
                break;
            }
        }
        enemiesToSpawn.Clear();
        enemiesToSpawn = generatedEnemies;
    }
    

}

[System.Serializable]
public class Enemy
{
    public GameObject enemyPrefab;
    public int cost;
}
