using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.SceneManagement;
using Unity.UI;

public class ReglesJeu : MonoBehaviour
{
    public GameObject transitionSlide1;
    public GameObject transitionSlide3;
    void Start()
    {
        transitionSlide3.GetComponent<Animator>().enabled = true;
    }
    public void LoadBastion()
    {
        Invoke("LoadScene", 1f);
        transitionSlide1.GetComponent<Animator>().enabled = true;
    }
    void LoadScene()
    {
        SceneManager.LoadScene("Bastion 5");
    }
}
