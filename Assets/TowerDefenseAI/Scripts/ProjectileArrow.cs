
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileArrow : MonoBehaviour {
    public GameObject archerTower;
    public GameObject ennemis;
    public float moveSpeed = 1f;

    void Start()
    {
        archerTower = GameObject.FindGameObjectWithTag("archerTower");
        ennemis = GameObject.FindGameObjectWithTag("ennemis");
        
    }

    private void Update() {
        if(ennemis != null)
        {
            MoveProjectile();
            transform.rotation = RotateProjectile(ennemis.transform.position - transform.position);
            
        }

        if(transform.position == ennemis.transform.position){
            Destroy(gameObject);
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
