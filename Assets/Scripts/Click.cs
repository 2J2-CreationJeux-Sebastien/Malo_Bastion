using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class Click : MonoBehaviour
{
    public GameObject archerTowerIcon; // UI pour construire un batiment archer 
    public GameObject pfarcherTower; // objet batiment archer 

    public GameObject upgrade_circle; // UI pour ameliorer et vendre un batiment 
    public GameObject upgrade_button; // UI boutton pour ameliorer
    public GameObject sell_button; // UI boutton pour vendre
    public GameObject buildUI; // objet UI pour consttuire les structures
    public GameObject button_close; // ferme les UI quand il est clicker

    public GameObject lastBuildingHit;

    public GameObject lastSignHit;
    public Vector2 lastSignHitPosition;
    public GameObject Ennemis_type_1;

    public Vector2 spawnpoint;
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
    int currentWave = 0;
    public float timeBetweenWaves = 10f;
    float waveCountDown;
    SpawnState state = SpawnState.START;


    void Start()
    {   //Au debut du jeu il y a la tansition activer
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
        //Debug.Log(state);
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
            if (state != SpawnState.SPAWNING)
            {
                StartCoroutine(SpawnWave(waves[currentWave]));
            }
        }
        else if(waveWarningStart == true)
        {
            waveCountDown -= Time.deltaTime;
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
            if (hit.collider.gameObject.name == "build sign")
            {
                //Enregistre la derniere affiche clicker
                lastSignHit = hit.collider.gameObject;
                //Enregistre la position de la derniere affiche clicker
                lastSignHitPosition = new Vector2(hit.collider.gameObject.transform.position.x, hit.collider.gameObject.transform.position.y);
                archerTowerIcon.gameObject.SetActive(true);
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

            if (hit.collider.gameObject.name == "archerTowerIcon")
            {
                buildUI.gameObject.SetActive(false);
                archerTowerIcon.gameObject.SetActive(false);
                button_close.gameObject.GetComponent<Collider2D>().enabled = false;
                lastSignHit.gameObject.GetComponent<Collider2D>().enabled = false;
                Instantiate(pfarcherTower, lastSignHitPosition, Quaternion.identity, lastSignHit.transform);
                GameObject.Find("pfarcherTower(Clone)").gameObject.transform.GetChild(0).gameObject.SetActive(false);
            }

            if (hit.collider.gameObject.tag == "archerTower")
            {
                buildUI.gameObject.SetActive(false);
                lastBuildingHit = hit.collider.gameObject;
                hit.collider.gameObject.transform.GetChild(0).gameObject.SetActive(true);
                sell_button.GetComponent<Collider2D>().enabled = true;
                GameObject.Find("button_close").gameObject.GetComponent<Collider2D>().enabled = true;
            }

            if (hit.collider.gameObject.name == "sell_button")
            {
                GameObject.Find("pfarcherTower(Clone)").gameObject.transform.GetChild(0).gameObject.SetActive(false);
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
        Invoke("ActivateWaveWarning", 5f);
        state = SpawnState.COUNTING;
        waveCountDown = timeBetweenWaves;
        if (currentWave == 15)
        {
            // Implemnt some sorta multiplier here to make it harder over time
            Debug.Log("ALL WAVES COMPLETE! Looping...");
        }
        else
        {
            currentWave++;
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

}
