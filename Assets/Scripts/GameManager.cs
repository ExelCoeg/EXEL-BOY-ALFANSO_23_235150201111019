using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    InfoStatus infoStatus;
    public bool afterWave;
    public bool paused;
    // Start is called before the first frame update
    void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        infoStatus = GetComponent<InfoStatus>();
    }

    public void IncreaseScore(int amount)
    {
        infoStatus.currentScore += amount;
    }
    
    
}
