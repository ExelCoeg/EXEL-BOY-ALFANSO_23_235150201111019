
using TMPro;
using UnityEngine;


public class VictoryMenu : MonoBehaviour
{
    public GameObject victoryMenu;
    public GameObject newHiScoreText;
    public TextMeshProUGUI hiScoreText;
    public TextMeshProUGUI scoreText;
    

    // Update is called once per frame
    void Update()
    {
        if(GameManager.instance.victory == true)
        {
            victoryMenu.SetActive(true);
            hiScoreText.text = "Highscore : " + PlayerPrefs.GetInt("Highscore").ToString();
            scoreText.text = "Score: " + ScoreManager.instance.currentScore.ToString();
            newHiScoreText.SetActive(true);
            GameManager.instance.Pause();
        }
    }
    public void RestartLevel()
    {
        GameManager.instance.RestartLevel();
    }
    public void MainMenu()
    {
        GameManager.instance.MainMenu();

    }
    
}
