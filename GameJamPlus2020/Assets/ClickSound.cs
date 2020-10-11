using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickSound : MonoBehaviour
{
    

    public AudioSource MainAudio;
    void Start()
    {
        
    }

    public void ClickAudio() {
        MainAudio.Play();
    }
}
