using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicChange : TriggerByDistance {

    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip clip;

	// Use this for initialization
	void Start () {
        target = GameObject.Find("Player").transform;
	}
	
	// Update is called once per frame
	void Update () {
        CheckTrigger();
        if (isEntering)
        {
         
           audioSource.clip = clip;
           audioSource.Play();
        }
	}
}
