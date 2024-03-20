using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float speed; //To keep the speed of the player
    public float jumpForce;
    private Rigidbody playerRb;
    private bool isOnGround = true;
    public bool gameOver;
    public float gravityModifier;
   



    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        Physics.gravity *= gravityModifier;
        
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
    }



    //Move the Player
    private void MovePlayer()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround && !gameOver)
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround = false;

            //isOnGround = false; // To not jump when is off the floor
        }
    }
}
