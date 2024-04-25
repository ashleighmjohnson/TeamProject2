using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController : MonoBehaviour
{
    [SerializeField] private AudioSource StartMusic;

    // Start is called before the first frame update
    void Start()
    {
        // Assuming you want to play the audio source attached to this object
        if (StartMusic != null)
        {
            StartMusic.Play();
        }
        else
        {
            Debug.LogWarning("Audio source is not assigned.");
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}

