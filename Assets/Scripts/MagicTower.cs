
using System.Collections;
using System.Collections.Generic;
using System.Security.Principal;
using UnityEngine;


public class MagicTower : MonoBehaviour {

    // MEME COMMENTAIRES QUE Archer.cs :)

    private Vector3 projectileShootFromPosition;
    public GameObject magicProjectile;
    public GameObject circleCollider;
    public GameObject range;
    public GameObject upgradeButton;
    public GameObject magicTowerLevelprice;


    public Sprite magicLevel3price;
    public Sprite maxUpgrade;

    public bool canShoot;
    public float timeBetweenShots;
    public float shotsCountdown;
    public int magicTowerLevel;


    private void Awake() {
        magicTowerLevel = 1;
        projectileShootFromPosition = new Vector2((gameObject.transform.GetChild(1).transform.position.x), (gameObject.transform.GetChild(1).transform.position.y));
        canShoot = true;
        timeBetweenShots = 1f;
        shotsCountdown = timeBetweenShots;
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
            shotsCountdown -= Time.deltaTime;
        }
        if (shotsCountdown <= 0)
        {
            shotsCountdown = timeBetweenShots;
            canShoot = true;
        }
    }
    public void Level2()
    {
        magicTowerLevel += 1;
        timeBetweenShots = 0.90f;
        circleCollider.GetComponent<CircleCollider2D>().radius = 3.5f;
        range.gameObject.transform.localScale = new Vector3(0.73f, 0.73f, 0.73f);
        magicTowerLevelprice.GetComponent<SpriteRenderer>().sprite = magicLevel3price;
    }

    public void Level3()
    {
        magicTowerLevel += 1;
        timeBetweenShots = 0.75f;
        circleCollider.GetComponent<CircleCollider2D>().radius = 3.5f;
        range.gameObject.transform.localScale = new Vector3(0.73f, 0.73f, 0.73f);
        upgradeButton.GetComponent<SpriteRenderer>().sprite = maxUpgrade;
        upgradeButton.GetComponent<Collider2D>().enabled = false;
        magicTowerLevelprice.SetActive(false);
    }
}
