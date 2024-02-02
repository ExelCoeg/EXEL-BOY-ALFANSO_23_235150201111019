using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BossWave : MonoBehaviour
{

    [SerializeField]
    GameObject rocketTarget;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(StartWave());
    }
   
    IEnumerator StartWave()
    {
        
        WaitForSeconds waitBetweenAttacks = new WaitForSeconds(1f);
        WaitForSeconds waitBetweenSpawnRocketsWave = new WaitForSeconds(4f);
        int spawnRocketsWave = 20;
        // bangalore ult type attack
        while (spawnRocketsWave > 0) // how many times the rocketfall wave will happen
        {
            WaitForSeconds waitBetweenSpawningRockets = new WaitForSeconds(0.25f);
            int randomManyRockets = 20;

            for (int rocket = 0; rocket < randomManyRockets; rocket++)
            { // spawning how much rockets to fall 
                Instantiate(rocketTarget, new Vector3(Random.Range(-9f, 10f), Random.Range(-3.8f, 2.86f), 0), Quaternion.identity);
                yield return waitBetweenSpawningRockets;
            }
            spawnRocketsWave--;
            yield return waitBetweenSpawnRocketsWave;
        }
        yield return waitBetweenAttacks;
        
        yield return null;
    }
   
}