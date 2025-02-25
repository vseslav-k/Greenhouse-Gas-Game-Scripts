using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    [SerializeField]GameObject pauseMenu;


    public void PauseGame()
    {

        pauseMenu.SetActive(true);
        Time.timeScale = 0;

    }

    public void UnpauseGame()
    {

        pauseMenu.SetActive(false);
        Time.timeScale = 1;

    }
}
