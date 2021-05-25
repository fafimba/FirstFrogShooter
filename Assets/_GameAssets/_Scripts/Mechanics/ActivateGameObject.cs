using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateGameObject : TriggerByDistance {

    [SerializeField]
    GameObject[] goToActivate;

    [SerializeField]
    GameObject[] goToDesactivate;

    void Start()
    {
        target = GameObject.Find("Player").transform;
    }

    void Update () {

    
        CheckTrigger();

        if (isEntering)
        {
            ToggleActivation(goToActivate, true);
            ToggleActivation(goToDesactivate, false);
        }
	}

    void ToggleActivation(GameObject[] goToToggle, bool activate)
    {
        for (int i = 0; i < goToToggle.Length; i++)
        {
            goToToggle[i].SetActive(activate);
        }
    }
}
