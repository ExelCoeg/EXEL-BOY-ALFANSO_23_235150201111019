
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
        GameManager.instance.Pause();
    }
    public void GameResume()
    {
        pauseMenu.gameObject.SetActive(false);
        GameManager.instance.Resume();
    }
}
