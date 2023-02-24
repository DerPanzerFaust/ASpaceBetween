using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundRandomizer : MonoBehaviour
{
    public AudioClip[] sounds;
    private AudioSource source;

    public float timeRemaining = 90;

    private void Start()
    {
        source = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if(timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime; 
            if(timeRemaining <= 0)
            {
                source.clip = sounds[Random.Range(0, sounds.Length)];
                source.Play();
                Debug.Log("Audio Played");
                timeRemaining = 90;
            }
        }
    }
}
