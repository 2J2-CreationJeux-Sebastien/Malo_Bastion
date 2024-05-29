
using System.Collections;
using System.Collections.Generic;
using System.Security.Principal;
using UnityEngine;


public class ArcherTower : MonoBehaviour {

    // Variable Vector3 qui decide le positionnement de ou les fleches ce font instancer.
    private Vector3 projectileShootFromPosition;
    // Met le 'Prefab' de arrow dans une variable pour 'Instantiate'
    public GameObject arrow;
    // Met le game object de 'CircleCollider' dans une variable pour aceder le la list 'currentEnnemis' du script 'CurrentEnnemis'
    public GameObject circleCollider;
    // Variable bolenne qui determine si la tour peut tirer
    public bool canShoot;
    public float timeBetweenShots;
    public float shotsCoundown;

    private void Awake() {
        // Done une valeur a la variable projectileShootFromPosition
        projectileShootFromPosition = new Vector2((gameObject.transform.position.x), (gameObject.transform.position.y+0.5f));
        canShoot = true;
        timeBetweenShots = 0.5f;
        shotsCoundown = timeBetweenShots;
    }

    private void Update() {
        // Si on click 'SPACE' et si on peut tirer et si il y a au moins un ennemis dans la list 'currentEnnemis'
        if ((canShoot == true)&&(circleCollider.GetComponent<CurrentEnnemis>().currentEnnemis.Count > 0)) 
        {
            // Cree des clones de arrow quand on tire a la position 'projectileShootFromPosition'
            GameObject cloneArrow = Instantiate(arrow, projectileShootFromPosition, Quaternion.identity);
            // Activer le clone arrow
            cloneArrow.SetActive(true);
            // Ne pas permettre de tirer jusqua que la fleche tirer touche un ennemis.
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
        timeBetweenShots = 0.25f;
    }
}
