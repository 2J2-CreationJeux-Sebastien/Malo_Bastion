using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    public GameObject archerTower;
    public GameObject ennemis;

    public float speedArrow;

    private Vector2 archerTowerPosition;
    private Vector2 ennemisPosition;

    private Vector2 distanceDiff; 
    private Vector2 nextPosition; 


    // Start is called before the first frame update
    void Start()
    {
        archerTower = GameObject.FindGameObjectWithTag("archerTower");
        ennemis = GameObject.FindGameObjectWithTag("ennemis");

        archerTowerPosition = new Vector2(archerTower.transform.position.x, archerTower.transform.position.y);
    }

    // Update is called once per frame
    void Update()
    {
        ennemisPosition = new Vector2(ennemis.transform.position.x, ennemis.transform.position.y);

        distanceDiff = ennemisPosition - archerTowerPosition;
        nextPosition = Vector2.MoveTowards(transform.position, ennemisPosition, speedArrow*Time.deltaTime);
    }
}
