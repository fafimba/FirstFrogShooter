using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol : MonoBehaviour {

    [SerializeField]
    GameObject prefabBullet;
    [SerializeField]
    float RateShoot;
    [SerializeField]
    float shootForce;

    [SerializeField]
    AudioClip shootAudioClip;

    AudioSource audioSource;

    private float _ammountRateShoot;
    private Transform _shootSpot;
	// Use this for initialization
	void Awake () {
        _shootSpot = transform.Find("ShootSpot");
        audioSource = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButton("Fire1"))
        {
            if (Time.time > _ammountRateShoot)
            {
                _ammountRateShoot = Time.time + RateShoot;
                var bullet = Instantiate(prefabBullet,_shootSpot.position, transform.rotation);
                bullet.GetComponent<Rigidbody>().AddForce(transform.forward * shootForce, ForceMode.Impulse);
                audioSource.PlayOneShot(shootAudioClip);

            }
        }
	}
}
