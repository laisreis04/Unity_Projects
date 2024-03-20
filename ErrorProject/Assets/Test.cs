using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    string playerName = "Frank";
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Hello: " + gameObject.name + playerName);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
