using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinMenu : MonoBehaviour
{
    public GameObject winMenuUI;
    public void Restart()
    {
        Time.timeScale = 1;
        Invoke("LoadBastion", 1f);
        GameObject.Find("transitionSlide 1").gameObject.GetComponent<Animator>().enabled = true;
        winMenuUI.SetActive(false);
    }
    public void Menu()
    {
        Time.timeScale = 1;
        Invoke("LoadMenu", 1f);
        winMenuUI.SetActive(false);
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
