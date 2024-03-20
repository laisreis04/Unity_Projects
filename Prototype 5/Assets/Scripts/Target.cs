using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    private Rigidbody target2D;
    private GameManager gameManagerScript;
    private float minSpeed = 12;
    private float maxSpeed = 16;
    private float maxTorque = 10;
    private float xRange = 4;
    private float ySpawnPos = -5.2f;

    public int pointValue;
    public ParticleSystem explocionParticle;


    // Start is called before the first frame update
    void Start()
    {
        target2D = GetComponent<Rigidbody>();
        target2D.AddForce(RandomForce(), ForceMode.Impulse);
        target2D.AddTorque(RandomTorque(),RandomTorque(),RandomTorque(), ForceMode.Impulse);
        transform.position = RandomSpawnPos();

        gameManagerScript = GameObject.Find("Game Manager").GetComponent<GameManager>();  //Reference to the Game Manager

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //For - Add force to the object
    Vector3 RandomForce()
    {
        return Vector3.up * Random.Range(minSpeed, maxSpeed);
    }

    //FOR - Add torque to the objects (Rotatiton)
    float RandomTorque() 
    {
        return Random.Range(-maxTorque, maxTorque);
    }

    Vector3 RandomSpawnPos()
    {
        return new Vector3 (Random.Range(-xRange, xRange), ySpawnPos);
    }

    private void OnMouseDown()
    {
        if (gameManagerScript.isGameActive)
        {
            Destroy(gameObject);
            Instantiate(explocionParticle, transform.position, explocionParticle.transform.rotation);
            gameManagerScript.UpdateScore(pointValue);
        }
        
    }


    private void OnTriggerEnter(Collider other)
{
    Destroy(gameObject);

        if (!gameObject.CompareTag("Bad"))
        {
            gameManagerScript.GameOver();
        }
       
}

   
        
}
