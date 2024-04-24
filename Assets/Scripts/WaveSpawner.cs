/*
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{

    public enum SpawnState { SPAWNING, WAITING};

    [System.Serializable]
    public class Wave
    {
        public string name;
        public Transform[] enemy;
        public int count;
        public float rate;
    }
    public Wave[] waves;

    public float timeBetweenWaves = 5f;
    float waveCountDown;

    SpawnState state = SpawnState.SPAWNING;

    void Start()
    {
        waveCountDown = timeBetweenWaves;
    }
    void Update()
    {
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
        else
        {
            waveCountDown -= Time.deltaTime;
        }
    }

    void WaveCompleted()
    {
        Debug.Log("Wave Completed");
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
        if (GameObject.FindGameObjectWithTag("Ennemis") == null)
        {
            return false;
        } 
        else 
        { 
            return true; 
        }
    }

    IEnumerator SpawnWave(Wave _wave)
    {
        Debug.Log("Spawn Wave:" + _wave.name);
        state = SpawnState.SPAWNING;

        for (int i = 0; i < _wave.count; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(1f / _wave.rate);
        }

        state = SpawnState.WAITING;
        yield break;
    }

    void SpawnEnemy()
    {
        GameObject cloneEnnemisType1 = Instantiate(Ennemis_type_1, spawnpoint, Quaternion.identity);
        cloneEnnemisType1.SetActive(true);
    }
}
*/
