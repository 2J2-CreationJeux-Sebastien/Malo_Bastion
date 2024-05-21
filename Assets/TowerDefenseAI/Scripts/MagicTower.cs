
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MagicTower : MonoBehaviour {

    private Vector3 projectileShootFromPosition;
    public GameObject magicProjectile;
    public GameObject circleCollider;
    private void Awake() {
        projectileShootFromPosition = new Vector2((gameObject.transform.GetChild(1).transform.position.x), (gameObject.transform.GetChild(1).transform.position.y));
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.Space)) {
            if (circleCollider.GetComponent<CurrentEnnemis>().currentEnnemis.Count > 0) 
            {
                gameObject.transform.GetChild(1).gameObject.GetComponent<Animator>().SetTrigger("Attack");
                GameObject cloneMagicProjectile = Instantiate(magicProjectile, projectileShootFromPosition, Quaternion.identity);
                cloneMagicProjectile.SetActive(true);
            }
        }
    }
}
