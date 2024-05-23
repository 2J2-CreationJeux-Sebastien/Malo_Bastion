
using System.Collections;
using System.Collections.Generic;
using System.Security.Principal;
using UnityEngine;


public class MagicTower : MonoBehaviour {

    private Vector3 projectileShootFromPosition;
    public GameObject magicProjectile;
    public GameObject circleCollider;
    public bool canShoot = true;


    private void Awake() {
        projectileShootFromPosition = new Vector2((gameObject.transform.GetChild(1).transform.position.x), (gameObject.transform.GetChild(1).transform.position.y));
    }

    private void Update() {
        if ((Input.GetKeyDown(KeyCode.Space)) && (canShoot == true) && (circleCollider.GetComponent<CurrentEnnemis>().currentEnnemis.Count > 0))
        {
            GameObject cloneMagicProjectile = Instantiate(magicProjectile, projectileShootFromPosition, Quaternion.identity);
            cloneMagicProjectile.SetActive(true);
            canShoot = false;
        }
    }
}
