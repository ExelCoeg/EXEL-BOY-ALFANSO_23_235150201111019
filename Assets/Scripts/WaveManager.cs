
using UnityEngine;

public class WaveManager : MonoBehaviour

{
    public static WaveManager instance;
    [SerializeField]
    GameObject[] enemyPrefabs;
    [SerializeField]
    GameObject miniBoss;
    [SerializeField]
    GameObject Boss;

    public Transform[] spawnLocations;
    [SerializeField]
    float spawnInterval = 3f;

    public float spawnTimer;
    public float waveTimer;

    [SerializeField]
    float waveDuration = 10f;
    public int currWave = 0;
    private void Start()
    {
        GameManager.instance.Resume();
        FindObjectOfType<AudioManager>().Play("BGM");
    }
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
        if (!GameManager.instance.playerDead)
        {
            if (!GameManager.instance.victory)
            {
                spawnTimer += Time.deltaTime;
                waveTimer -= Time.deltaTime;
                if (waveTimer >= 0)
                {
                    if (spawnTimer >= spawnInterval)
                    {
                        GameObject enemyToSpawn = enemyPrefabs[Random.Range(0, enemyPrefabs.Length)];
                        Instantiate(enemyToSpawn, spawnLocations[Random.Range(0, spawnLocations.Length)].position, Quaternion.identity);
                        spawnTimer = 0;
                    }
                }
                else if (waveTimer < 0)
                {
                    currWave++;
                    if (currWave % 3 == 0 && currWave!= 15)
                    {
                        spawnInterval -= 0.35f;
                    }
                    if (currWave >= 10 && currWave % 2 == 0  && currWave < 15)
                    {   
                        SpawnMiniBoss();
                    }
                    if (currWave == 15)
                    {
                        SpawnBoss();
                        spawnInterval = 1.7f;
                    }
                    if (currWave >= 16)
                    {
                        currWave = 15;
                    }
                    waveTimer = waveDuration;
                }
            }
            
        }
    }
    public void SpawnMiniBoss()
    {
        Instantiate(miniBoss, spawnLocations[Random.Range(0,spawnLocations.Length)].position, Quaternion.identity);
    }
    public void SpawnBoss()
    {
        Instantiate(Boss, spawnLocations[1].position, Quaternion.identity);
    }
    public void ClearEnemies()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject enemy in enemies)
        {
            Destroy(enemy);
        }
        GameObject[] miniBosses = GameObject.FindGameObjectsWithTag("MiniBoss");
        foreach (GameObject miniBoss in miniBosses) {
            Destroy(miniBoss);
        }
    }
}
