using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenuUI;
    public void Pause()
    {
        Time.timeScale = 0;
        pauseMenuUI.SetActive(true);
    }

    public void Continue()
    {
        Time.timeScale = 1;
        pauseMenuUI.SetActive(false);
    }
}
