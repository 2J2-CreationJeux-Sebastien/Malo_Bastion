using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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

    public void Restart()
    {
        Time.timeScale = 1;
        Invoke("LoadScene", 1f);
        GameObject.Find("transitionSlide 1").gameObject.GetComponent<Animator>().enabled = true;
        pauseMenuUI.SetActive(false);
    }

    void LoadScene()
    {
        SceneManager.LoadScene("Bastion 5");
    }
}
