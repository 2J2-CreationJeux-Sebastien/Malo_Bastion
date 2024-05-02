
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileArrow : MonoBehaviour {
    public AnimationCurve curve;
    [SerializeField]
    private float duration = 1f;
    [SerializeField]
    private float heightY = 3f;

    public GameObject archerTower;
    public GameObject ennemis;

    public Vector3 start;
    public Vector3 end;


    void Start()
    {
        archerTower = GameObject.FindGameObjectWithTag("archerTower");
        ennemis = GameObject.FindGameObjectWithTag("ennemis");
        start = new Vector3(archerTower.transform.position.x, archerTower.transform.position.y, 0f);
        end = new Vector3(ennemis.transform.position.x, ennemis.transform.position.y, 0f);
        
    }

    public IEnumerator Curve(Vector3 start, Vector3 target)
    {
        float timePassed = 0f;

        Vector2 end = target;

        while (timePassed < duration)
        {
            timePassed+= Time.deltaTime;

            float linearT = timePassed / duration;
            float heightT = curve.Evaluate(linearT);

            float height = Mathf.Lerp(0f, heightY, heightT);

            transform.position = Vector2.Lerp(start, end, linearT)+ new Vector2(0f, height);

            yield return null;
        }
    }

    private void Update() {


        if(transform.position == ennemis.transform.position){
            Destroy(gameObject);
        }
    }

}
