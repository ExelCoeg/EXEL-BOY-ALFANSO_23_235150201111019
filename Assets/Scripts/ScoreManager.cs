
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    public int currentScore;
   
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

        if (PlayerPrefs.HasKey("Highscore"))
        {
            if (currentScore > PlayerPrefs.GetInt("Highscore"))

            {
                PlayerPrefs.SetInt("Highscore", currentScore);
            }
        }
    }
    public void IncreaseScore(int amount)
    {
        currentScore += amount;
        
    }
}
