using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    Score score;

   
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
        score = GetComponent<Score>();
    }

    public void IncreaseScore(int amount)
    {
        score.currentScore += amount;
    }
}
