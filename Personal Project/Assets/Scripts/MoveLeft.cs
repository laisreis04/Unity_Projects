using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    private float speed = 15f;
    private float leftBound = 54f;
    private PlayerController playerControllerScript;

    // Start is called before the first frame update
    void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>(); //para pegar o componente do scrip, o GameOver
    }

    // Update is called once per frame
    void Update()
    {
        
        if(playerControllerScript.gameOver == false) //fazer o spawn enquanto o jogo não for GameOver
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime);
        }

        if(transform.position.x > leftBound && gameObject.CompareTag("Enemy") && gameObject.CompareTag("Obstacle"))
        {
            Destroy(gameObject);
        }
          
    }
}
