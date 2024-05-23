using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrentEnnemis : MonoBehaviour
{
    public List<GameObject> currentEnnemis = new List<GameObject>();

    void OnTriggerEnter2D(Collider2D infoCollision)
    {
        currentEnnemis.Add(infoCollision.gameObject);
    }
    void OnTriggerExit2D(Collider2D infoCollision)
    {
        currentEnnemis.Remove(currentEnnemis[0]);
    }
}
