using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowGrenade : MonoBehaviour {

    [SerializeField]
    float throwForce;
    [SerializeField]
    Rigidbody grenade;
    [SerializeField]
    int _maxGrenades;

    [SerializeField]
    AudioClip shootAudioClip;
    AudioSource audioSource;

    Transform shootSpot;

    public int maxGrenades { get; private set; }
    public int currentGrenades { get; private set; }

    public bool hasMaxGrenades()
    {
        return currentGrenades == maxGrenades;
    }

    // Use this for initialization
    void Awake () {
        maxGrenades = _maxGrenades;

        currentGrenades = maxGrenades;
        shootSpot = transform.Find("GrenadeSpot");
        audioSource = GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("Fire2") && currentGrenades > 0)
        {
            currentGrenades -= 1;
            Rigidbody newGrenade = Instantiate(grenade);
            newGrenade.transform.position = shootSpot.transform.position;
            Vector3 throwDirection = shootSpot.transform.forward;
            newGrenade.AddForce(throwDirection * throwForce, ForceMode.Impulse);
            audioSource.PlayOneShot(shootAudioClip);

        }
	}

    public void AddGrenades(int grenades)
    {
        currentGrenades = Mathf.Clamp(currentGrenades + grenades, 0, maxGrenades);
    }
}
