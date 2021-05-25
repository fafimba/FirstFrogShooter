using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bilboard : MonoBehaviour {


    Camera playerCam;

    void Start()
    {
        playerCam = Camera.main;
    }
    // Update is called once per frame
    void Update () {
        transform.rotation = playerCam.transform.rotation;
	}
}
