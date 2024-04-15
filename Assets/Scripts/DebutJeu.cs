using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DebutJeu : MonoBehaviour
{
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            CastRay();
        }
    }

    void CastRay()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction, Mathf.Infinity);
        if (hit.collider != null)
        {
            Debug.Log(hit.collider.gameObject.name);
            if (hit.collider.gameObject.name == "Bastion Start")
            {
                print("hello");
                Invoke("LoadScene", 1f);
                GameObject.Find("transitionSlide 1").gameObject.GetComponent<Animator>().enabled = true;
            }

        }
    }

    void LoadScene()
    {
        SceneManager.LoadScene("Bastion 5");
    }
}
