using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrentEnnemis : MonoBehaviour
{
    public static List<GameObject> currentEnnemis = new List<GameObject>();

    void Start()
    {
        
    }

    void Update()
    {

    }
    void OnTriggerEnter2D(Collider2D infoCollision)
    {
        print("hello");
        currentEnnemis.Add(infoCollision.gameObject);
        print(currentEnnemis[0]);
    }
    void OnTriggerExit2D(Collider2D infoCollision)
    {
        print("bye");
        currentEnnemis.Remove(currentEnnemis[0]);
    }
}
