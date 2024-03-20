using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float horizontalMoves;
    
    private Rigidbody boxRB;
    private float speed = 0.5f;
    private float xRangeNeg = -44f;
    private float xRnagePos = 37f;
    public Renderer colorRendererBall;
    public Renderer colorRenBox;
    


    // Start is called before the first frame update
    void Start()
    {
        boxRB = GetComponent<Rigidbody>();
        colorRenBox = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (transform.position.x < xRangeNeg)
        {
            transform.position = new Vector3(xRangeNeg, transform.position.y, transform.position.z);
        }
        if(transform.position.x > xRnagePos)
        {
            transform.position = new Vector3(xRnagePos,transform.position.y, transform.position.z);
        }
        
        horizontalMoves = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.left * speed * horizontalMoves);

  

    }

    void OnTriggerEnter(Collider other)
    {
        colorRendererBall = other.GetComponent<Renderer>();

        Color ballColor = colorRendererBall.material.color;

        //if (other.CompareTag("Blue Ball") || other.CompareTag("Red Ball") || other.CompareTag("Yellow Ball") ||other.CompareTag("Green Ball"))
        //{
         
        //}

        colorRenBox.material.color = ballColor;
        Destroy(other.gameObject);
    }


}
