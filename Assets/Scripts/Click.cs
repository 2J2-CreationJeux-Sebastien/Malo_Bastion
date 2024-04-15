using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class Click : MonoBehaviour
{
    public GameObject buildUI;
    public GameObject button_close;

    public GameObject archerTowerIcon;
    public GameObject pfarcherTower;
    public GameObject upgrade_circle;
    public GameObject upgrade_button;
    public GameObject sell_button;

    public GameObject lastBuildingHit;

    public GameObject lastSignHit;
    public Vector2 lastSignHitPosition;

    public GameObject Ennemis_type_1;
    public Vector2 spawnpoint;
    public GameObject waypoint_1;

    void Start()
    {
        GameObject.Find("transitionSlide 1").gameObject.GetComponent<Animator>().enabled = true;
        Invoke("StopTransition", 1f);
        buildUI.gameObject.SetActive(false);
        button_close.gameObject.GetComponent<Collider2D>().enabled = false;
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            CastRay();
        }
    }

    void CastRay()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction, Mathf.Infinity);
        if (hit.collider != null)
        {
            Debug.Log(hit.collider.gameObject.name);
            if (hit.collider.gameObject.name == "build sign")
            {
                lastSignHit = hit.collider.gameObject;
                lastSignHitPosition = new Vector2(hit.collider.gameObject.transform.position.x, hit.collider.gameObject.transform.position.y);
                archerTowerIcon.gameObject.SetActive(true);
                buildUI.gameObject.SetActive(true);
                button_close.gameObject.GetComponent<Collider2D>().enabled = true;
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

            if (hit.collider.gameObject.name == "pfarcherTower(Clone)")
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
                Destroy(lastBuildingHit);
                button_close.gameObject.GetComponent<Collider2D>().enabled = false;
            }

            if (hit.collider.gameObject.name == "wave_warning")
            {
                spawnpoint = new Vector2(waypoint_1.gameObject.transform.position.x, waypoint_1.gameObject.transform.position.y);
                Instantiate(Ennemis_type_1, spawnpoint, Quaternion.identity);
            }
        }
    }
    void StopTransition() 
    {
        GameObject.Find("transitionSlide 1").gameObject.GetComponent<Animator>().enabled = false;
    }
}
