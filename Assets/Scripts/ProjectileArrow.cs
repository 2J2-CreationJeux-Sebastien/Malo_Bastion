
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileArrow : MonoBehaviour {
    public GameObject archerTower;
    public GameObject magicTower;
    public GameObject ennemis;
    public float moveSpeed;
    public GameObject circleCollider;
    public float archerDamage;
    public float magicDamage;

    void Start()
    {
        //archerDamage = 10f;
        //magicDamage = 20f;
        if (circleCollider.GetComponent<CurrentEnnemis>().currentEnnemis.Count > 0);
        {
            ennemis = circleCollider.GetComponent<CurrentEnnemis>().currentEnnemis[0];
        }
    }

    public void Update() {
        
        if (ennemis != null)
        {
            MoveProjectile();
            transform.rotation = RotateProjectile(ennemis.transform.position - transform.position);
            
            if (transform.position == ennemis.transform.position)
            {
                if (gameObject.name == "arrow(Clone)")
                {
                    ennemis.GetComponent<Ennemistype1>().healthEnemytype1 -= 10;

                }
                if (gameObject.name == "magic projectile(Clone)")
                {
                    ennemis.GetComponent<Ennemistype1>().healthEnemytype1 -= 25;
                }
                Destroy(gameObject);
            }
        }
        else 
        {
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
