
using UnityEngine;

public class PlayerDeadMenu : MonoBehaviour
{
    [SerializeField]
    GameObject playerDeadMenu;

    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance.playerDead)
        {
            playerDeadMenu.SetActive(true);
            WaveManager.instance.ClearEnemies();
            GameManager.instance.Pause();
        }
    }
    public void RestartLevel()
    {
        GameManager.instance.RestartLevel();
        playerDeadMenu.SetActive(false);
    }
    public void MainMenu()
    {
        GameManager.instance.MainMenu();
        playerDeadMenu.SetActive(false);
    }

}
