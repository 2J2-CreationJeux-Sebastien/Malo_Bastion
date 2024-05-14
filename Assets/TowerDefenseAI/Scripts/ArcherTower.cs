
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ArcherTower : MonoBehaviour {

    private Vector3 projectileShootFromPosition;
    public GameObject arrow;

    private void Awake() {
        projectileShootFromPosition = new Vector2((gameObject.transform.position.x), (gameObject.transform.position.y+0.5f));
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.Space)) {
            GameObject cloneArrow = Instantiate(arrow, projectileShootFromPosition, Quaternion.identity);
            cloneArrow.SetActive(true);
        }
    }
}
