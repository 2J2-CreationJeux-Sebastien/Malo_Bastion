
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ArcherTower : MonoBehaviour {

    private Vector3 projectileShootFromPosition;
    public GameObject arrow;
    // private float range;
    // private int damageAmount;
    // private float shootTimerMax;
    // private float shootTimer;

    private void Awake() {
        projectileShootFromPosition = new Vector2((gameObject.transform.position.x), (gameObject.transform.position.y+0.5f));
        //range = 60f;
        //damageAmount = 25;
        //shootTimerMax = .4f;
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.Space)) {
            GameObject cloneArrow = Instantiate(arrow, projectileShootFromPosition, Quaternion.identity);
            cloneArrow.SetActive(true);
        }
        /*
        shootTimer -= Time.deltaTime;

        if (shootTimer <= 0f) {
            shootTimer = shootTimerMax;

            Enemy enemy = GetClosestEnemy();
            if (enemy != null) {
                // Enemy in range!
                ProjectileArrow.Create(projectileShootFromPosition, enemy, Random.Range(damageAmount - 5, damageAmount + 5));
            }
        }
        */
    }
    /*
    private Enemy GetClosestEnemy() {
        return Enemy.GetClosestEnemy(transform.position, range);
    }

    public float GetRange() {
        return range;
    }

    public void UpgradeRange() {
        range += 10f;
    }

    public void UpgradeDamageAmount() {
        damageAmount += 5;
    }

    private void OnMouseEnter() {
        UpgradeOverlay.Show_Static(this);
    }
    */
}
