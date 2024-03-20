using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour

{
    public float speed = 3;
    private Rigidbody enemyRb;
    private GameObject player;


    // Start is called before the first frame update
    void Start()
    {
        enemyRb = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        //To know the way to go - the the player current position less then the enemy position to follow him arround.
        // we need first to get the current possition of the player and after that mutiply by the speed
        // use the ".normalized" to keep the same force.
        Vector3 lookDirection = (player.transform.position - transform.position).normalized;

        enemyRb.AddForce(lookDirection * speed);

       if(transform.position.y < -10) 
        {
            Destroy(gameObject);
            Destroy(gameObject);
        }

    }
}
