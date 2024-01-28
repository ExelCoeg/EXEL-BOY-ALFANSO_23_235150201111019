
using UnityEngine;
using TMPro;

public class InfoStatus : MonoBehaviour
{
    public int currentScore;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI waveText;
    
    private void Update()
    {
        scoreText.text = "Score: " + currentScore.ToString();
        waveText.text = "Wave: " + WaveSpawner.instance.currWave.ToString();
    }

}
