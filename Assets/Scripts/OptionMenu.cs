using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionMenu : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu;
    [SerializeField] GameObject optionMenu;

    public void Back()
    {
        pauseMenu.SetActive(true);
        optionMenu.SetActive(false);
    }
}
