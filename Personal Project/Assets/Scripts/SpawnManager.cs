using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemyFabs;
    public GameObject obstacleFabs;
    private Vector3 spawnPosition = new Vector3(-37.1f, 0.5f, -5.2f);

    private float startSpawn = 2f;
    private float reapetSpawn =2.7f;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnEnemySpot", startSpawn, reapetSpawn);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Local onde será gerado
    void SpawnEnemySpot()
    {
        Instantiate(enemyFabs, spawnPosition, enemyFabs.transform.rotation);
    }
  

    //Spawn Enemy
}
