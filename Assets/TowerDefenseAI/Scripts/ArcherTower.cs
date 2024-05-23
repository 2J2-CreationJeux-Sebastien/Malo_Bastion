
using System.Collections;
using System.Collections.Generic;
using System.Security.Principal;
using UnityEngine;


public class ArcherTower : MonoBehaviour {

    private Vector3 projectileShootFromPosition;
    public GameObject arrow;
    public GameObject circleCollider;
    public bool canShoot = true;


    private void Awake() {
        projectileShootFromPosition = new Vector2((gameObject.transform.position.x), (gameObject.transform.position.y+0.5f));
    }

    private void Update() {
        if ((Input.GetKeyDown(KeyCode.Space))&&(canShoot == true)&&(circleCollider.GetComponent<CurrentEnnemis>().currentEnnemis.Count > 0)) 
        {
            GameObject cloneArrow = Instantiate(arrow, projectileShootFromPosition, Quaternion.identity);
            cloneArrow.SetActive(true);
            canShoot = false;
        }
    }
}
