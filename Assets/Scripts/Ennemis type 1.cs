using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ennemistype1 : MonoBehaviour
{
    [SerializeField] Transform[] Points1;
    [SerializeField] Transform[] Points2;
    [SerializeField] Transform[] Points3;
    [SerializeField] private float moveSpeed;
    private int pointsIndex;
    void Start()
    {
        transform.position = Points1[pointsIndex].transform.position;
    }
    void Update()
    {
        if(pointsIndex <= Points1.Length -1)
        {
            transform.position = Vector2.MoveTowards(transform.position, Points1[pointsIndex].transform.position, moveSpeed * Time.deltaTime);
            if (transform.position == Points1[pointsIndex].transform.position)
            {
                pointsIndex += 1;
            }

            if (pointsIndex == Points1.Length) 
            {
                Click.ennemisCount--;
                print(Click.ennemisCount);
                Destroy(gameObject);
            }
        }
    }
}
