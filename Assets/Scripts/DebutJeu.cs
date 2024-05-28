using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DebutJeu : MonoBehaviour
{
    public void LoadReglesJeu() 
    {
        Invoke("LoadScene", 1f);
        GameObject.Find("transitionSlide 1").gameObject.GetComponent<Animator>().enabled = true;
    }

    void LoadScene()
    {
        SceneManager.LoadScene("Bastion Regles");
    }
}
