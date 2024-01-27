using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Android;
using UnityEngine.UI;
public class Pause : MonoBehaviour
{
    public GameObject pauseMenu;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            GamePause();
        }
    }
    public void GamePause()
    {
        pauseMenu.gameObject.SetActive(true);
        Time.timeScale = 0f;
    }
    public void GameResume()
    {
        pauseMenu.gameObject.SetActive(false);
        Time.timeScale = 1f;
    }
}
