using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public GameObject ennemis;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D infoCollision)
    {
        if ((infoCollision.gameObject.tag == "ennemis") && (PlayerController.attack == true))
        { 
            
        }
    }
}
