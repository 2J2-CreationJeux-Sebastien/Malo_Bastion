
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
    // Met le game object de 'range' dans une variable pour aceder son 'localScale' pour l'agrandir
    public GameObject range;
    // Met le game object de 'upgrade_button' dans une variable pour aceder son 'SpriteRenderer' et 'Collider' pour le niveau max
    public GameObject upgradeButton;
    // Met le game object de 'archerTowerLevelprice' dans une variable pour aceder son 'SpriteRenderer'
    public GameObject archerTowerLevelprice;

    // Variable pour enregistrer une image de 'archerlevel3price'
    public Sprite archerLevel3price;
    // Variable pour enregistrer une image de 'max'
    public Sprite maxUpgrade;

    // Variable bolenne qui determine si la tour peut tirer
    public bool canShoot;
    // Nombre original pour compteur de temp pour mettre du temp entre les tires
    public float timeBetweenShots;
    // Compteur de temp pour mettre du temp entre les tires
    public float shotsCountdown;
    // Variable pour determiner le niveau du la tour archer
    public int archerTowerLevel;

    private void Awake() {
        archerTowerLevel = 1;
        // Done une valeur a la variable projectileShootFromPosition
        projectileShootFromPosition = new Vector2((gameObject.transform.position.x), (gameObject.transform.position.y+0.5f));
        // Au debut on peut maintenant tirer
        canShoot = true;
        // Met une valeur a timeBetweenShots
        timeBetweenShots = 0.5f;
        // shotsCountdown = timeBetweenShots :) ;
        shotsCountdown = timeBetweenShots;
    }

    private void Update() {
        // Si on peut tirer et si il y a au moins un ennemis dans la list 'currentEnnemis'
        if ((canShoot == true)&&(circleCollider.GetComponent<CurrentEnnemis>().currentEnnemis.Count > 0)) 
        {
            // Cree des clones de arrow quand on tire a la position 'projectileShootFromPosition'
            GameObject cloneArrow = Instantiate(arrow, projectileShootFromPosition, Quaternion.identity);
            // Activer le clone arrow
            cloneArrow.SetActive(true);
            // Ne pas permettre de tirer jusqua que le compteur retourne a 0.
            canShoot = false;
        }
        if (canShoot == false) 
        {
            //un compteur de compteur de temp qui se deroule pour mettre du temp entre les tires.
            shotsCountdown -= Time.deltaTime;
        }

        // Si le compteur de temp est ecoule
        if (shotsCountdown <= 0) 
        {
            // On remet le comteur a sa valeur original
            shotsCountdown = timeBetweenShots;
            // On peut maintenant tirer
            canShoot = true;
        }
    }

    // Quand on ameliore au niveau 2
    public void Level2() 
    {
        // Ajoute 1 au niveau de la tour
        archerTowerLevel += 1;
        // Le temp pour tirer est plus cours
        timeBetweenShots = 0.35f;
        // Le radius du 'CircleCollider2D' est agrandit
        circleCollider.GetComponent<CircleCollider2D>().radius = 4.2f;
        // L'image du 'range' est agrandit pour etre le meme que le 'CircleCollider2D'
        range.gameObject.transform.localScale = new Vector3(1.02f, 1.02f, 1.02f);
        // Affiche maintenant le prix du prochain niveau -> (3)
        archerTowerLevelprice.GetComponent<SpriteRenderer>().sprite = archerLevel3price;
    }
    public void Level3()
    {
        // Ajoute 1 au niveau de la tour
        archerTowerLevel += 1;
        // Le temp pour tirer est plus cours
        timeBetweenShots = 0.20f;
        circleCollider.GetComponent<CircleCollider2D>().radius = 4.2f;
        range.gameObject.transform.localScale = new Vector3(1.02f, 1.02f, 1.02f);
        // Faire un changement d'image pour annoncer le niveau max de la tour
        upgradeButton.GetComponent<SpriteRenderer>().sprite = maxUpgrade;
        // Enleve le 'Collider2D' pour ne plus etre capable d'ameliorer
        upgradeButton.GetComponent<Collider2D>().enabled = false;
        // Enleve l'affichement de prix
        archerTowerLevelprice.SetActive(false);
    }
}
