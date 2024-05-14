using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrentEnnemis : MonoBehaviour
{
    public List<GameObject> currentEnnemis = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnTriggerEnter2D(Collider2D infoCollision)
    {
        print("hello");
        currentEnnemis.Add(infoCollision.gameObject);
    }
    void OnTriggerExit2D(Collider2D infoCollision)
    {
        print("bye");
        currentEnnemis.Remove(currentEnnemis[0]);
    }
}
