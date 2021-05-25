using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spider : TriggerByDistance {


    [SerializeField]GameObject bulletPrefab;
    [SerializeField] float shootForce;
    [SerializeField]float shootingRate;

    Transform shootSpot;

    void Awake()
    {
        shootSpot = transform.Find("ShootSpot");
    }


    // Use this for initialization
    void Start () {
     
        StartCoroutine(Shoot());
	}
	
	// Update is called once per frame
	void Update () {
        CheckTrigger();

        if (isInside)
        {
            transform.LookAt(target);
        }

        GetComponent<CharacterController>().SimpleMove(Vector3.zero); //Included just to add gravity to the gameObject
    }

    IEnumerator Shoot()
    {
        while (true)
        {
            if (isInside)
            {
                GameObject bullet = Instantiate(bulletPrefab, shootSpot.position, transform.rotation);
                Rigidbody rbBullet = bullet.GetComponent<Rigidbody>();
                if (rbBullet)
                {
                    rbBullet.AddForce(transform.forward * shootForce, ForceMode.Impulse);
                }
               
            }
            yield return new WaitForSeconds(shootingRate);
        }

    }
}
