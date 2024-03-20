using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    public Color[] colors = new Color[5];
    private int colorIndex;
    private float horizontalPos;
    private float verticalPos;
    private float speed = 10.0f;

    public MeshRenderer Renderer;
    GameObject cube;
    
    void Start()
    {
        transform.position = new Vector3(3, 4, 1);
        transform.localScale = Vector3.one * 2.0f;
        
        //Material material = Renderer.material;
        //material.color = new Color(0.5f, 1.0f, 0.3f, 0.4f);



    }
    
    void Update()
    {
        transform.Rotate(20.0f * Time.deltaTime, 0.0f, 0.0f);


        //To make the color change Random hem the spaceBar is press
        colors[0] = Color.white;
        colors[1] = Color.black;
        colors[2] = Color.magenta;
        colors[3] = Color.cyan;
        colors[4]  = Color.red;
        
        colorIndex = Random.Range(0, colors.Length);

        if (Input.GetKeyDown(KeyCode.Space))
        {

            if (Renderer != null)
            {
                Material material = Renderer.material;
                material.color = colors[colorIndex];

            }

        }

    }

  void FixedUpdate()
    {
        horizontalPos = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * horizontalPos *Time.deltaTime * speed);


        verticalPos = Input.GetAxis("Vertical");
        transform.Translate(Vector3.up * verticalPos *Time.deltaTime * speed);

        
    }
}
