using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationAudio : MonoBehaviour {

    public AudioClip clip;
    public bool play;

    AudioSource audioSource;
   
	// Use this for initialization
	void Start ()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (play)
        {
            audioSource.clip = clip;
            audioSource.Play();
            play = false;
        }
      }
	
}
