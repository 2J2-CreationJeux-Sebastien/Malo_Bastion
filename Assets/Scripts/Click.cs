using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class Click : MonoBehaviour
{
    public static int gold;
    public static int lives;
    public GameObject gameEndUI;

    public GameObject starsWin;
    public GameObject starsLose;
    public GameObject oneStarWin;
    public GameObject twoStarWin;
    public GameObject threeStarWin;

    // Batiment Archer
    public GameObject archerTowerIcon; // UI pour construire un batiment archer 
    public GameObject pfarcherTower; // objet batiment archer 

    //Batiment Magic
    public GameObject magicTowerIcon;
    public GameObject pfmagicTower;

    
    // UI pour batiments 
    public GameObject upgrade_circle; // UI pour ameliorer et vendre un batiment 
    public GameObject upgrade_button; // UI boutton pour ameliorer
    public GameObject sell_button; // UI boutton pour vendre
    public GameObject buildUI; // objet UI pour consttuire les structures
    public GameObject button_close; // ferme les UI quand il est clicker

    // Variables utiles 
    public GameObject lastBuildingHit; // Dernier Batiment cliqué
    public GameObject lastSignHit; // Derniere affiche cliqué
    public Vector2 lastSignHitPosition; // Derniere position d'affiche cliqué

    public Vector2 magicTowerPosition;

    // Systeme ennemis
    public GameObject Ennemis_type_1;
    public Vector2 spawnpoint; // Point de depart des ennemis
    public GameObject waypoint_1;
    public GameObject wave_warning;
    public bool waveWarningStart = false; 
    public enum SpawnState { SPAWNING, WAITING, START, COUNTING};

    [System.Serializable]
    public class Wave
    {
        public string name;
        public Transform[] enemy;
        public int count;
        public float rate;
    }
    public Wave[] waves;
    public static int currentWave;
    public float timeBetweenWaves;
    float waveCountDown;
    SpawnState state = SpawnState.START;


    void Start()
    {   
        gold = 200;
        lives = 20;
        timeBetweenWaves = 30f;
        currentWave = 9;
        //Au debut du jeu il y a la tansition activer
        GameObject.Find("transitionSlide 1").gameObject.GetComponent<Animator>().enabled = true;
        //Arret de la transition quand fini
        Invoke("StopTransition", 1f);
        //Mettre l'objet buildUI pas actif au debut
        buildUI.gameObject.SetActive(false);
        //Mettre la collision de l'objet button_close pas actif au debut
        button_close.gameObject.GetComponent<Collider2D>().enabled = false;
        waveCountDown = timeBetweenWaves;
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // Si il y a un click activer CastRay 
        {
            CastRay();
        }
        
        if (state == SpawnState.WAITING)
        {
            if (!EnemyIsAlive())
            {
                WaveCompleted();
            }
            else
            {
                return;
            }
        }

        if (waveCountDown <= 0)
        {
            wave_warning.gameObject.transform.GetChild(0).gameObject.GetComponent<Animator>().SetBool("WaveWarning", true);
            Invoke("DeactivateWaveWarning", 1f);
            if (state != SpawnState.SPAWNING)
            {
                StartCoroutine(SpawnWave(waves[currentWave]));
            }
        }
        else if(waveWarningStart == true)
        {
            waveCountDown -= Time.deltaTime;
        }

        if (lives <= 0)
        {
            GameLose();
        }
    }

    void CastRay()
    {
        //Raycast qui dertermine qu'elle object a ete clicker
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction, Mathf.Infinity);
        if (hit.collider != null)
        {
            Debug.Log(hit.collider.gameObject.name);
            Debug.Log(hit.collider);
            if (hit.collider.gameObject.name == "build sign")
            {
                //Enregistre la derniere affiche clicker
                lastSignHit = hit.collider.gameObject;
                //Enregistre la position de la derniere affiche clicker
                lastSignHitPosition = new Vector2(hit.collider.gameObject.transform.position.x, hit.collider.gameObject.transform.position.y);
                magicTowerPosition = new Vector2(hit.collider.gameObject.transform.position.x+0.07f, hit.collider.gameObject.transform.position.y+0.07f);
                archerTowerIcon.gameObject.SetActive(true);
                magicTowerIcon.gameObject.SetActive(true);

                //Quand on click sur une affiche buildUI devient actif
                buildUI.gameObject.SetActive(true);
                //Donne l'option de clicker sur le fond pour ne pas construire et enlever buildUI
                button_close.gameObject.GetComponent<Collider2D>().enabled = true;
                //affiche l'objet buildUI au la derniere affiche clicker
                buildUI.transform.position = lastSignHitPosition;
            }

            if (hit.collider.gameObject.name == "button_close")
            {
                buildUI.gameObject.SetActive(false);
                lastBuildingHit.gameObject.transform.GetChild(0).gameObject.SetActive(false);
                sell_button.GetComponent<Collider2D>().enabled = true;
                button_close.gameObject.GetComponent<Collider2D>().enabled = false;
            }

            if ((hit.collider.gameObject.name == "magicTowerIcon")&&(gold >= 200))
            {
                gold -= 200;
                buildUI.gameObject.SetActive(false);
                magicTowerIcon.gameObject.SetActive(false);
                button_close.gameObject.GetComponent<Collider2D>().enabled = false;
                lastSignHit.gameObject.GetComponent<Collider2D>().enabled = false;
                Instantiate(pfmagicTower, magicTowerPosition, Quaternion.identity, lastSignHit.transform);
                GameObject.Find("pfmagicTower(Clone)").gameObject.SetActive(true);
                GameObject.Find("pfmagicTower(Clone)").gameObject.transform.GetChild(0).gameObject.SetActive(false);
            }

            if ((hit.collider.gameObject.tag == "magicTower")&&(hit.collider.GetType() == typeof(BoxCollider2D)))
            {
                buildUI.gameObject.SetActive(false);
                lastBuildingHit = hit.collider.gameObject;
                hit.collider.gameObject.transform.GetChild(0).gameObject.SetActive(true);
                sell_button.GetComponent<Collider2D>().enabled = true;
                GameObject.Find("button_close").gameObject.GetComponent<Collider2D>().enabled = true;
            }

            if ((hit.collider.gameObject.name == "archerTowerIcon")&&(gold >= 100))
            {
                gold -= 100;
                buildUI.gameObject.SetActive(false);
                archerTowerIcon.gameObject.SetActive(false);
                button_close.gameObject.GetComponent<Collider2D>().enabled = false;
                lastSignHit.gameObject.GetComponent<Collider2D>().enabled = false;
                Instantiate(pfarcherTower, lastSignHitPosition, Quaternion.identity, lastSignHit.transform);
                GameObject.Find("pfarcherTower(Clone)").gameObject.transform.GetChild(0).gameObject.SetActive(false);
            }

            //if ((hit.collider.gameObject.tag == "archerTower"))
            if ((hit.collider.gameObject.tag == "archerTower")&&(hit.collider.GetType() == typeof(BoxCollider2D)))
            {
                buildUI.gameObject.SetActive(false);
                lastBuildingHit = hit.collider.gameObject;
                hit.collider.gameObject.transform.GetChild(0).gameObject.SetActive(true);
                sell_button.GetComponent<Collider2D>().enabled = true;
                GameObject.Find("button_close").gameObject.GetComponent<Collider2D>().enabled = true;
            }

            if (hit.collider.gameObject.name == "sell_button")
            {
                if(lastBuildingHit.gameObject.tag == "archerTower"){
                    GameObject.Find("pfarcherTower(Clone)").gameObject.transform.GetChild(0).gameObject.SetActive(false);
                }
                if(lastBuildingHit.gameObject.tag == "magicTower"){
                    GameObject.Find("pfmagicTower(Clone)").gameObject.transform.GetChild(0).gameObject.SetActive(false);
                }
                lastBuildingHit.transform.parent.gameObject.SetActive(true);
                lastBuildingHit.transform.parent.gameObject.GetComponent<Collider2D>().enabled = true;
                lastBuildingHit.transform.gameObject.SetActive(false);
                button_close.gameObject.GetComponent<Collider2D>().enabled = false;
            }

            if (hit.collider.gameObject.name == "wave_warning")
            {
                waveWarningStart = true;
                waveCountDown = 0;
                wave_warning.gameObject.transform.GetChild(0).gameObject.GetComponent<Animator>().SetBool("WaveWarning", true);
                Invoke("DeactivateWaveWarning", 1f);
                //position initial des ennemis
                spawnpoint = new Vector2(waypoint_1.gameObject.transform.position.x, waypoint_1.gameObject.transform.position.y);
                //Si on click wave_warning, ca creer un clone de ennemis 
            }
        }
    }
    void StopTransition() 
    {
        //Arret de la transition
        GameObject.Find("transitionSlide 1").gameObject.GetComponent<Animator>().enabled = false;
    }

    void ActivateWaveWarning()
    {
        wave_warning.gameObject.GetComponent<Collider2D>().enabled = true;
        wave_warning.gameObject.transform.GetChild(0).gameObject.GetComponent<Animator>().SetBool("WaveWarning", false);

    }
    void DeactivateWaveWarning()
    {
        wave_warning.gameObject.GetComponent<Collider2D>().enabled = false;
    }
    IEnumerator SpawnWave(Wave _wave)
    {
        Debug.Log("Spawn Wave:" + _wave.name);
        state = SpawnState.SPAWNING;
        for (int i = 0; i < _wave.count; i++)
        {
            SpawnEnnemis();
            yield return new WaitForSeconds(1f / _wave.rate);
        }

        state = SpawnState.WAITING;
        yield break;
    }
    void SpawnEnnemis()
    {
        GameObject cloneEnnemisType1 = Instantiate(Ennemis_type_1, spawnpoint, Quaternion.identity);
        cloneEnnemisType1.SetActive(true);
    }
    void WaveCompleted()
    {
        Debug.Log("Wave Completed");
        currentWave+=1;
        if (currentWave == 10)
        {
            GameWin();
        }
        else 
        {
            Invoke("ActivateWaveWarning", 5f);
            waveCountDown = timeBetweenWaves;
            state = SpawnState.COUNTING;
        }
    }

    bool EnemyIsAlive()
    {
        if (GameObject.FindGameObjectWithTag("ennemis") == null)
        {
            return false;
        } 
        else 
        { 
            return true; 
        }
    }

    void GameWin() 
    {
        Time.timeScale = 0;
        gameEndUI.SetActive(true);
        starsWin.SetActive(true);
        if (lives == 20)
        {
            threeStarWin.SetActive(true);
        }
        else if (lives >= 10)
        {
            twoStarWin.SetActive(true);
        }
        else 
        { 
            oneStarWin.SetActive(true);
        }
    }

    void GameLose() 
    {
        Time.timeScale = 0;
        gameEndUI.SetActive(true);
        starsLose.SetActive(true);
    }
}
