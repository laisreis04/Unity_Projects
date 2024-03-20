using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;
    private Animator playerAn;  //Reference to Animator
    public ParticleSystem explosionParticle;   //Reference for the particles
    public ParticleSystem dirtParticle;   //Reference for the particles
    public AudioClip jumpSound;  //  Audio varible
    public AudioClip crashSound;  //  Audio varible
    private AudioSource playerAudio; //  Audio varible
    public float jumpForce = 700;
    public float gravityModifier;
    public bool isOnGround = true;
    public bool gameOver;
    


    // Start is called before the first frame update
    void Start()
    {
        //To make her jump 
        playerRb = GetComponent<Rigidbody>();
        Physics.gravity *= gravityModifier;   //To add physics
        playerAn = GetComponent<Animator>();
        playerAudio = GetComponent<AudioSource>();   //To play the audios clips

        
    }

    // Update is called once per frame
    void Update()
    {
        //Make the jump happen - and make sure that the player doens't jump when is on the floor
        if(Input.GetKeyDown(KeyCode.Space) && isOnGround && !gameOver) 
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround = false;
            playerAn.SetTrigger("Jump_trig");
            dirtParticle.Stop();
            playerAudio.PlayOneShot(jumpSound, 0.5f);
        }
    }

    //To detect collision to another things
    private void OnCollisionEnter(Collision collision)
    {
        

        if (collision.gameObject.CompareTag("Ground")) // When the player is at the flor this will happen
        {
            isOnGround = true;
            dirtParticle.Play();


            //GAME OVER
        }else if (collision.gameObject.CompareTag("Obstacle"))  //When the player hit the obstacle
        {
            //Make the player fall 
            Debug.Log("Game over!!");
            playerAn.SetBool("Death_b", true);  //To start the fall
            playerAn.SetInteger("DeathType_int", 1);  //To set the type of death -> INFO: animator window - Layer (Death) - Conditions
            explosionParticle.Play();
            gameOver = true;
            dirtParticle.Stop();
            playerAudio.PlayOneShot(crashSound, 0.5f);
        }
    }

}
