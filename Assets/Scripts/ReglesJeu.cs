using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.SceneManagement;
using Unity.UI;

public class ReglesJeu : MonoBehaviour
{
    // GameObject pour l'objet de la transition pour transitionner a une autre scene
    public GameObject transitionSlide1;
    // GameObject pour l'objet de la transition au debut de la scene
    public GameObject transitionSlide3;
    void Start()
    {
        // Au debut du jeu la deuxieme partie de l'animation de transition de la sccene precedente
        transitionSlide3.GetComponent<Animator>().enabled = true;
    }
    public void LoadBastion()
    {
        Invoke("LoadScene", 1f);
        // Active la premiere partie de l'animation de transition. L'autre partie est au debut de la prochaine scene
        transitionSlide1.GetComponent<Animator>().enabled = true;
    }
    void LoadScene()
    {
        // Load la scene du jeu principal
        SceneManager.LoadScene("Bastion 5");
    }
}
