using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    private float xSpawn;

    
    public List<GameObject> ballPrefabs;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("GenerateRandomSpawn", 2f, 2f);
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    void GenerateRandomSpawn()
    {
        Vector2 spawnPos = new Vector3(xSpawn, 28, 0.1f);
        xSpawn = Random.Range(-44, 38);

        GameObject randomPrefabs = ballPrefabs[Random.Range(0, ballPrefabs.Count)];

        transform.position = new Vector3(xSpawn, 26,0);
        Instantiate(randomPrefabs,spawnPos, Quaternion.identity);

    }

    
}
