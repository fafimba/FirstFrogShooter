using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutScenes : MonoBehaviour {


    [SerializeField] UnityStandardAssets.Characters.FirstPerson.FirstPersonController FPSController;
    [SerializeField] GameObject ui;
     Camera playerCamera;


    int clipOff = Animator.StringToHash("Base Layer.Off");
    Animator animator;

    void Start()
    {
        playerCamera = GetComponent<Camera>();
        animator = GetComponent<Animator>();
        PlayClip("Intro");
    }

    public void PlayClip(string clipName)
    {
        StartCoroutine(PlayClipCorutine(clipName));
    }

    IEnumerator PlayClipCorutine(string clipName)
    {
        Vector3 initialPosCam = playerCamera.transform.localPosition;
        Quaternion initialRotCam = playerCamera.transform.localRotation;

        animator.enabled = true;
        int clip = Animator.StringToHash(clipName);

        AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);
        if (stateInfo.fullPathHash == clipOff)
        {
            ToggleCutScene(true);
            animator.SetTrigger(clip);

            var seconds = 0f;
            AnimatorClipInfo[] foo = animator.GetNextAnimatorClipInfo(0);

            for (int i = 0; i < foo.Length; i++)
            {
                if (foo[0].clip.length > seconds)
                {
                    seconds = foo[0].clip.length;
                }
            }
     

            yield return new WaitForSeconds(seconds);
            ToggleCutScene(false);
        }
        animator.enabled = false;

        playerCamera.transform.localPosition = initialPosCam;
        playerCamera.transform.localRotation = initialRotCam;
        yield return null;
    }

    void ToggleCutScene(bool on)
    {
        ui.SetActive(!on);
        FPSController.enabled = !on;
    }

}
