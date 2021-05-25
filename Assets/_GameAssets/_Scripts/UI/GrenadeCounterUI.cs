using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GrenadeCounterUI : MonoBehaviour {


    Text text;
   ThrowGrenade throwGrenade;

	// Use this for initialization
	void Awake () {
        throwGrenade = FindObjectOfType<ThrowGrenade>();
        text = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
        text.text = string.Format("{0}/{1}", throwGrenade.currentGrenades, throwGrenade.maxGrenades);
	}
}
