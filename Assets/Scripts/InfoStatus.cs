
using UnityEngine;
using TMPro;
public class InfoStatus : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI waveText;
   
    private void Update()
    {
        scoreText.text = "Score: " + ScoreManager.instance.currentScore.ToString();
        waveText.text = "Wave: " + WaveManager.instance.currWave.ToString();
    }

}
