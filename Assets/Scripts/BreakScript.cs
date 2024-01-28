using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BreakScript : MonoBehaviour
{
    private float breakTimer;
    private float breakTime = 5f;
    public GameObject breakMenu;
    public TextMeshProUGUI breakTimerText;
   
    //private void Update()
    //{
        
    //    if (GameManager.instance.afterWave)
    //    {
    //        breakMenu.gameObject.SetActive(true);
    //        breakTimer += Time.deltaTime;
    //        breakTimerText.text = breakTimer.ToString("0.00");
    //        if (breakTimer >= breakTime)
    //        {
    //            AfterWaveDone();
    //        }
    //    }

    //}
    //public void AfterWaveDone()
    //{
    //    breakMenu.gameObject.SetActive(false);
    //    GameManager.instance.afterWave = false;
    //    WaveSpawner.instance.currWave++;
    //}
    
    
}
