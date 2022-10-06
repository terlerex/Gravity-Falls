using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class MainMenuAnimation : MonoBehaviour
{
    public Transform[] spawnPoints;
    public GameObject[] spawnObj;
    private int randomSpawnPoint, randomObj;
    public static bool spawnAllowed;


    void Start()
    {
        spawnAllowed = true;
        InvokeRepeating("SpawnObj", 0f, 5.0f);
    }

    void SpawnObj()
    {
        if (spawnAllowed)
        {
            randomSpawnPoint = Random.Range(0, spawnPoints.Length);
            randomObj = Random.Range(0, spawnObj.Length);
            Instantiate(spawnObj[randomObj], spawnPoints[randomSpawnPoint].position, Quaternion.identity);
        }
    }
}
