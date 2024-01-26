
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    public int currentScore;
    public TextMeshProUGUI scoreText;

    private void Update()
    {
        scoreText.text = "Score: " + currentScore.ToString();
    }
}
