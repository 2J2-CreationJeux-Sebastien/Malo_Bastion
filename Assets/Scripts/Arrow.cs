using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    public AnimationCurve curve;
    public GameObject archerTower;
    public GameObject ennemis;

    public float speedArrow;

    private float archerTowerPositionX;
    private float ennemisPositionX;

    private float distanceDiff; 
    private float nextPositionX;
    private float projectileShootFromPosition;
    private float heightPath;


    // Start is called before the first frame update
    void Start()
    {
        archerTower = GameObject.FindGameObjectWithTag("archerTower");
        ennemis = GameObject.FindGameObjectWithTag("ennemis");

        archerTowerPositionX = archerTower.transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        ennemisPositionX = ennemis.transform.position.x;
        print(ennemis.transform.position.x);

        distanceDiff = ennemisPositionX - archerTowerPositionX;
        nextPositionX = Mathf.MoveTowards(transform.position.x, ennemisPositionX, speedArrow*Time.deltaTime);
        projectileShootFromPosition = Mathf.Lerp(archerTower.transform.position.y, ennemis.transform.position.y, (nextPositionX - archerTowerPositionX)/distanceDiff);
        heightPath = 2 * -(nextPositionX - archerTowerPositionX) * (nextPositionX - archerTowerPositionX) / (0.25f * distanceDiff * distanceDiff);

        Vector3 movePosition = new Vector3(nextPositionX, projectileShootFromPosition + heightPath, transform.position.z);
        transform.rotation = LookAtTarget(movePosition - transform.position);
        transform.position = movePosition;

        if(transform.position == ennemis.transform.position){
            Destroy(gameObject);
        }
    }

    public static Quaternion LookAtTarget(Vector2 rotation)
    {
        return Quaternion.Euler(0,0, Mathf.Atan2(rotation.y, rotation.x)* Mathf.Rad2Deg);
    }
}