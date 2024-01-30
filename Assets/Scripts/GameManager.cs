
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public bool paused = false;
    public bool victory = false;
    public bool playerDead = false;


    private int currentSceneIndex;
    InfoStatus infoStatus;
    
    //InfoStatus infoStatus;
    // Start is called before the first frame update
    void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        infoStatus = GetComponent<InfoStatus>();
    }
    private void Update()
    {
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
    }
    public void RestartLevel()
    {
        Time.timeScale = 1f;
        if (currentSceneIndex == 1)
        {
            SceneManager.LoadScene(currentSceneIndex);
        }
        else
        {
            print("Can't restart due to not in level");
        }
    }
    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }
    public void Pause()
    {
        paused = true;
        Time.timeScale = 0f;
        
    }
    public void Resume()
    {
        paused = false;
        Time.timeScale = 1f;
    }
}
