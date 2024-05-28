using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.SceneManagement;
using Unity.UI;

public class ReglesJeu : MonoBehaviour
{
    void Start()
    {
        GameObject.Find("transitionSlide 3").gameObject.GetComponent<Animator>().enabled = true;
    }
    public void LoadBastion()
    {
        Invoke("LoadScene", 1f);
        GameObject.Find("transitionSlide 1").gameObject.GetComponent<Animator>().enabled = true;
    }
    void LoadScene()
    {
        SceneManager.LoadScene("Bastion 5");
    }
}
