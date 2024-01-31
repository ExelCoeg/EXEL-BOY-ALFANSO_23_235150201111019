
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    public int currentScore;
    public int hiScore = 0;
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
    }
    private void Update()
    {
        if(currentScore > hiScore)
        {
            PlayerPrefs.SetInt("Highscore", currentScore);
        }
    }
    public void IncreaseScore(int amount)
    {
        currentScore += amount;
        
    }
}
