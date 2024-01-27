
using UnityEngine;
using TMPro;

public class InfoStatus : MonoBehaviour
{
    public int currentScore;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI waveText;
    WaveSpawner wave;
    private void Awake()
    {
        wave = FindObjectOfType<WaveSpawner>();
    }
    private void Update()
    {
        scoreText.text = "Score: " + currentScore.ToString();
        waveText.text = "Wave: " + wave.currWave.ToString();
    }

}
