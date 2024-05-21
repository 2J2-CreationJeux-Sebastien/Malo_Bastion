using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ennemistype1 : MonoBehaviour
{
    [SerializeField] Transform[] Points;
    [SerializeField] Transform[] Points1;
    [SerializeField] Transform[] Points2;
    [SerializeField] Transform[] Points3;
    [SerializeField] private float moveSpeed;
    private int pointsIndex;
    private float randomNumber;
    [SerializeField] public int healthEnemytype1 = 50;

    void Start()
    {
        transform.position = Points1[pointsIndex].transform.position;
        randomNumber = Random.Range(1, 4);
        if(randomNumber == 1)
        {
            Points = Points1;
        } 
        else if(randomNumber == 2)
        {
            Points = Points2; 
        }
        else if(randomNumber == 3)
        {
            Points = Points3; 
        }
    }
    void Update()
    {
        if(pointsIndex <= Points.Length -1)
        {
            transform.position = Vector2.MoveTowards(transform.position, Points[pointsIndex].transform.position, moveSpeed * Time.deltaTime);
            if (transform.position == Points[pointsIndex].transform.position)
            {
                pointsIndex += 1;
            }

            if (pointsIndex == Points.Length) 
            {
                Destroy(gameObject);
            }
        }
        if (healthEnemytype1 <= 0)
        {
            Destroy(gameObject);
        }
    }
}

    
