using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManagerX : MonoBehaviour
{
    public GameObject[] ballPrefabs;
    public int ballIndex;

    private float spawnLimitXLeft = -22;
    private float spawnLimitXRight = 7;
    private float spawnposy = 30;

    private float startDelay = 1.0f;
    private float spawnInterval = 4.0f;
    private float spawnRandom;

    // Start is called before the first frame update
    void Start()
    {
        spawnRandom = Random.Range(startDelay, spawnInterval);
        InvokeRepeating("SpawnRandomBall", startDelay, spawnRandom);
    }

    private void Update()
    {
        
    }

    // Spawn random ball at random x position at top of play area
    void SpawnRandomBall ()
    {
        // Generate random ball index and random spawn position
        ballIndex = Random.Range(0, ballPrefabs.Length);
        Vector3 spawnPos = new Vector3(Random.Range(spawnLimitXLeft, spawnLimitXRight), spawnposy,0 );

        // instantiate ball at random spawn location
        Instantiate(ballPrefabs[ballIndex], spawnPos, ballPrefabs[ballIndex].transform.rotation);
    }

}
