using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AfterWave : MonoBehaviour
{
    private float afterWaveTimer;
    private float afterWaveWaitTime = 10f;
    public GameObject afterWaveMenu;
    public TextMeshProUGUI afterWaveTimerText;
    
    private void Update()
    {
       
        if (GameManager.instance.afterWave)
        {
            afterWaveTimer += Time.deltaTime;
            afterWaveTimerText.text =afterWaveTimer.ToString("0.00");
            afterWaveMenu.gameObject.SetActive(true);
            if (afterWaveTimer >= afterWaveWaitTime)
            {
                AfterWaveDone();
            }
        }

    }
    public void AfterWaveDone()
    {
        GameManager.instance.afterWave = false;
        afterWaveMenu.gameObject.SetActive(false);
        WaveSpawner.instance.currWave++;
        WaveSpawner.instance.GenerateWave();
    }
    
    
}
