using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunnerSpawner : MonoBehaviour
{
    public GameObject TitanRunner;
    public Transform[] spawnSpots;
    private float timeBtwSpawns;
    public float startTimeBtwSpawn;

    // Start is called before the first frame update
    void Start()
    {
        timeBtwSpawns = startTimeBtwSpawn;
    }

    // Update is called once per frame
    void Update()
    {
        if (timeBtwSpawns <= 0)
        {
            int randPos = Random.Range(0, spawnSpots.Length);
            Instantiate(TitanRunner, spawnSpots[randPos].position, Quaternion.identity);
            timeBtwSpawns = startTimeBtwSpawn;
        }
        else
        {
            timeBtwSpawns -= Time.deltaTime;
        }
    }
}
