using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Require AudioSource component to be attached to GameObject this script is attached to
[RequireComponent(typeof(AudioSource))]

public class PlaySound : MonoBehaviour
{
    private AudioSource audioSource;
    public AudioClip soundToPlay;
    public float volume = 1f;
    // Start is called before the first frame update
    void Start()
    {
        //Set reference to Audio Source
        audioSource = GetComponent<AudioSource>();

        //Play Sound on start
        audioSource.PlayOneShot(soundToPlay, volume);
    }
}
