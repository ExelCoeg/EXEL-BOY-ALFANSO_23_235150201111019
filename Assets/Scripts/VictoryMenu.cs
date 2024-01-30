
using UnityEngine;


public class VictoryMenu : MonoBehaviour
{
    public GameObject victoryMenu;
    //public GameObject infoStatusMenu;

    // Update is called once per frame
    void Update()
    {
        if(GameManager.instance.victory == true)
        {
            victoryMenu.SetActive(true);
            GameManager.instance.Pause();
        }
    }
    public void RestartLevel()
    {
        GameManager.instance.RestartLevel();
    }
    public void MainMenu()
    {
        GameManager.instance.MainMenu();
    }
    
}
