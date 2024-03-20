using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

public class CongratScript : MonoBehaviour
{
    [SerializeField] ParticleSystem SparksParticles;

    private TextMesh Text => GetComponent<TextMesh>();
    private readonly List<string> TextToDisplay = new() { "Congratulation", "All Errors Fixed" };

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating(nameof(ChangeText), 0, 1.5f);

        SparksParticles.Play();

       


    }


    private void ChangeText()
    {
        Text.text = TextToDisplay[0];

        TextToDisplay.Add(TextToDisplay[0]);
        TextToDisplay.RemoveAt(0);
    }




}