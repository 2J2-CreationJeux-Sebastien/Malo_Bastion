using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.SceneManagement;
using Unity.UI;

public class DebutJeu : MonoBehaviour
{
    public GameObject transitionSlide1;
    public void LoadReglesJeu() 
    {
        Invoke("LoadScene", 1f);
        transitionSlide1.GetComponent<Animator>().enabled = true;
    }

    void LoadScene()
    {
        SceneManager.LoadScene("Bastion Regles");
    }
}
