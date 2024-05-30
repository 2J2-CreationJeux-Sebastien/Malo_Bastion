using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenuUI;
    public GameObject transitionSlide2;
    public void Pause()
    {
        // Enleve le temp du jeu donc le jeu est en pause.
        Time.timeScale = 0;
        pauseMenuUI.SetActive(true);
    }

    // Quand on click le boutton "REPRENDRE" cette fonction s'active.
    // Cette fonction resume le jeu.
    public void Continue()
    {
        // Remet le temp du jeu a la vittesse reguliere donc le jeu resume.
        Time.timeScale = 1;
        // Enleve le UI du Menu de pause car on a clicker resumer.
        pauseMenuUI.SetActive(false);
    }

    // Quand on click le boutton "RECOMMENCER" cette fonction s'active.
    // Cette fonction recommence le jeu au complet.
    public void Restart()
    {
        // Remet le temp du jeu a la vittesse reguliere donc le jeu resume.
        Time.timeScale = 1;
        Invoke("LoadScene", 1f);
        // Faire une transition pour quand on recommeence ca soit plus beau.
        // Active la premiere partie de l'animation de transition. L'autre partie est quand la scene est reloader.
        transitionSlide2.GetComponent<Animator>().enabled = true;
        // Enleve le UI du Menu de pause car on recommence.
        pauseMenuUI.SetActive(false);
    }

    // Reload la scene de jeu principal.
    void LoadScene()
    {
        SceneManager.LoadScene("Bastion 5");
    }
}
