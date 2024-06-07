using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    float vitesseX;      //vitesse horizontale actuelle
    public float vitesseXMax;   //vitesse horizontale Maximale désirée
    float vitesseY;      //vitesse verticale 
    public float vitesseYMax;   //vitesse de saut désirée

    public static bool attaque;

    void Start()
    {

    }


    void Update()
    {
        // Mouvement X
        if (Input.GetKey("a"))
        {
            vitesseX = -vitesseXMax;
            GetComponent<SpriteRenderer>().flipX = true;

        }
        else if (Input.GetKey("d"))
        {
            vitesseX = vitesseXMax;
            GetComponent<SpriteRenderer>().flipX = false;
        }
        else
        {
            vitesseX = GetComponent<Rigidbody2D>().velocity.x;
        }
        // Mouvement Y
        if (Input.GetKey("w"))
        {
            vitesseY = vitesseYMax;
        }
        else if (Input.GetKey("s"))
        {
            vitesseY = -vitesseYMax;
        }
        else
        {
            vitesseY = GetComponent<Rigidbody2D>().velocity.y;
        }


        if (Input.GetKeyDown(KeyCode.Space) && attaque == false)
        {
            attaque = true;
            Invoke("AnnulerAttaque", 1f);
            GetComponent<Animator>().SetTrigger("attack");
        }


        //Applique les vitesses en X et Y
        GetComponent<Rigidbody2D>().velocity = new Vector2(vitesseX, vitesseY);


        //**************************Gestion des animaitons de course et de repos********************************
        //Active l'animation de course si la vitesse de déplacement n'est pas 0, sinon le repos sera jouer par Animator



        if (vitesseX > 0.1f || vitesseX < -0.1f || vitesseY > 0.1f || vitesseY < -0.1f) 
        {

            GetComponent<Animator>().SetBool("run", true);
        }
        else
        {

            GetComponent<Animator>().SetBool("run", false);
        }
    }

    void OnCollisionEnter2D(Collision2D infoCollision)
    {

    }

    void AnnulerAttaque()
    {
        attaque = false;
    }
}
