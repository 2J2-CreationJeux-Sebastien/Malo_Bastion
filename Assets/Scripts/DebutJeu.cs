using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.SceneManagement;
using Unity.UI;

public class DebutJeu : MonoBehaviour
{
    // Variable pour l'objet de la transition
    public GameObject transitionSlide1;

    // Quand on click le boutton "START" cette fonction s'active
    public void LoadReglesJeu() 
    {
        Invoke("LoadScene", 1f);
        // Active la premiere partie de l'animation de transition. L'autre partie est au debut de la prochaine scene
        transitionSlide1.GetComponent<Animator>().enabled = true;
    }

    // Load la scene qui explique les regles
    void LoadScene()
    {
        SceneManager.LoadScene("Bastion Regles");
    }
}
