using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameEndMenu : MonoBehaviour
{
    public GameObject gameEndUI;
    public GameObject transitionSlide2;
    public void Restart()
    {
        Time.timeScale = 1;
        Invoke("LoadBastion", 1f);
        transitionSlide2.gameObject.GetComponent<Animator>().enabled = true;
        gameEndUI.SetActive(false);
    }
    public void Menu()
    {
        Time.timeScale = 1;
        Invoke("LoadMenu", 1f);
        gameEndUI.SetActive(false);
    }
    void LoadBastion()
    {
        SceneManager.LoadScene("Bastion 5");
    }

    void LoadMenu()
    {
        SceneManager.LoadScene("Bastion Debut");
    }

}
