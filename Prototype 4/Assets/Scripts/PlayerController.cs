using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    private GameObject focalPoint;
    private Rigidbody playerRb;
    public bool hasPowerUp = false;
    private float powerUpStrenght = 15.0f;
    public GameObject PowerupIndicator;



    // Start is called before the first frame update
    void Start()
    {
        focalPoint = GameObject.Find("Focal Point");
        playerRb = GetComponent<Rigidbody>();// to "put" the rigidBody on the player
    }

    // Update is called once per frame
    void Update()
    {
        float forwardInput = Input.GetAxis("Vertical");

        playerRb.AddForce(focalPoint.transform.forward * forwardInput * speed);

        PowerupIndicator.transform.position = transform.position + new Vector3 (0, -0.5f, 0);  //To be at the same positon as the player
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Powerup"))
        {
            hasPowerUp = true;
            PowerupIndicator.gameObject.SetActive(true); // Put this here when the powerup its ON
            Destroy(other.gameObject);  //This is teh player Script, when the palyer hit on the Powerupm the powerup desapear.
            StartCoroutine(PowerupCountDownRoutine());
        }
    }

    IEnumerator PowerupCountDownRoutine()
    {
        yield return new WaitForSeconds(7);
        hasPowerUp = false;
        PowerupIndicator.gameObject.SetActive(false); //To turn off the Powerup 
    }

    //When collided with the Enemy
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Rigidbody enemyRb = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 awayFromPlayer = collision.gameObject.transform.position - transform.position;

            enemyRb.AddForce(awayFromPlayer * powerUpStrenght, ForceMode.Impulse);
            Debug.Log("Collided with: " + collision.gameObject.name + "with powerup set to " + hasPowerUp);
        }
    }

}
