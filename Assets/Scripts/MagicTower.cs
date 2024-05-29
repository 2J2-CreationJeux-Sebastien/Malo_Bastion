
using System.Collections;
using System.Collections.Generic;
using System.Security.Principal;
using UnityEngine;


public class MagicTower : MonoBehaviour {

    private Vector3 projectileShootFromPosition;
    public GameObject magicProjectile;
    public GameObject circleCollider;
    public bool canShoot;
    public float timeBetweenShots;
    public float shotsCoundown;

    private void Awake() {
        projectileShootFromPosition = new Vector2((gameObject.transform.GetChild(1).transform.position.x), (gameObject.transform.GetChild(1).transform.position.y));
        canShoot = true;
        timeBetweenShots = 1f;
        shotsCoundown = timeBetweenShots;
    }

    private void Update() {
        if ((canShoot == true) && (circleCollider.GetComponent<CurrentEnnemis>().currentEnnemis.Count > 0))
        {
            GameObject cloneMagicProjectile = Instantiate(magicProjectile, projectileShootFromPosition, Quaternion.identity);
            cloneMagicProjectile.SetActive(true);
            canShoot = false;
        }
        if (canShoot == false)
        {
            shotsCoundown -= Time.deltaTime;
        }
        if (shotsCoundown <= 0)
        {
            shotsCoundown = timeBetweenShots;
            canShoot = true;
        }
    }
    public void Level2()
    {
        timeBetweenShots = 0.75f;
    }
}
