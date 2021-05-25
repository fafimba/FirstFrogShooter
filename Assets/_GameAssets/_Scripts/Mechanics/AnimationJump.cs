using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class AnimationJump : TriggerByDistance
{

    [SerializeField]
    string animationName;

    FirstPersonController FPS;
    Animation anim;

    // Use this for initialization
    void Start()
    {
        target = GameObject.Find("Player").transform;
        anim = target.GetComponent<Animation>();
        FPS = target.GetComponent<FirstPersonController>();
    }

    // Update is called once per frame
    void Update()
    {
        CheckTrigger();

        if (isEntering)
        {
            anim.Play(animationName);
        }

        if (anim.isPlaying)
        {
            FPS.enabled = false;
        }
        else
        {
            FPS.enabled = true;
        }

    }
}
