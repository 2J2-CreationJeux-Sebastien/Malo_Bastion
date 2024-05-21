
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileArrow : MonoBehaviour {
    public GameObject archerTower;
    public GameObject ennemis;
    public float moveSpeed = 1f;
    public GameObject circleCollider;

    void Start()
    {
        archerTower = GameObject.FindGameObjectWithTag("archerTower");
    }

    private void Update() {
       
        if (circleCollider.GetComponent<CurrentEnnemis>().currentEnnemis.Count > 0) 
        {
            ennemis = circleCollider.GetComponent<CurrentEnnemis>().currentEnnemis[0];
        }
        
        if (ennemis != null)
        {
            MoveProjectile();
            transform.rotation = RotateProjectile(ennemis.transform.position - transform.position);
        }
    }

    private void MoveProjectile()
    {
        transform.position = Vector2.MoveTowards(transform.position, ennemis.transform.position, moveSpeed * Time.deltaTime);
    }

    public static Quaternion RotateProjectile(Vector2 rotation)
    {
        return Quaternion.Euler(0,0, Mathf.Atan2(rotation.y, rotation.x)* Mathf.Rad2Deg);
    }
    
}
