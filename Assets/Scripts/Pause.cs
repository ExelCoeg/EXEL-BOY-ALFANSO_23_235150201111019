
using UnityEngine;
using UnityEngine.Android;
using UnityEngine.Audio;
using UnityEngine.UI;
public class Pause : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu;
    [SerializeField] GameObject optionsMenu;
    
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !GameManager.instance.paused)
        {
            GamePause();
        }
    }
    public void GamePause()
    {
        FindObjectOfType<AudioManager>().Pause("BGM");
        pauseMenu.SetActive(true);
        GameManager.instance.Pause();
    }
    public void GameResume()
    {
        FindObjectOfType<AudioManager>().UnPause("BGM");
        pauseMenu.SetActive(false);
        GameManager.instance.Resume();
    }
    public void GameOptions()
    {
        pauseMenu.SetActive(false);
        optionsMenu.SetActive(true);
    }
    public void MainMenu()
    {
        GameManager.instance.MainMenu();
    }

    public void Quit()
    {
        Application.Quit();
    }
}
