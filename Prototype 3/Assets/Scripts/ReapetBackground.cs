using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReapetBackground : MonoBehaviour
{
    //To know where to setset the background 
    private Vector3 startPos;

    private float reapetWidth;


    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
        reapetWidth = GetComponent<BoxCollider>().size.x / 2;
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x < startPos.x - reapetWidth)
        {
            transform.position = startPos;
        }
    }
}
