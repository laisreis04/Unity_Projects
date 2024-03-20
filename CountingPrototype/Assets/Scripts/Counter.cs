using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Counter : MonoBehaviour
{
    public TextMeshProUGUI CounterText;
    public TextMeshProUGUI textColor;
    

    private int Count = 0;

    private void Start()
    {
        Count = 0;
    }

    private void OnTriggerEnter(Collider other)
    {
        Count += 1;
        CounterText.text = "Count : " + Count;

        Renderer colorName = other.GetComponent<Renderer>();

        if (colorName != null)
        {
            string materialName = colorName.material.name.Replace(" (Instance)", "");
            textColor.text = "Color: " + materialName;
        }
        
        

    }
}
