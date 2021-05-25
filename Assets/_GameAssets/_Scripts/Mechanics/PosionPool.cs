using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PosionPool : TriggerByDistance {

    [SerializeField] float hitRate;
    [SerializeField] int damage;
    [SerializeField] float deepOffset = .5f;

    PlayerLife PlayerLife;

     void Awake()
    {
        PlayerLife = FindObjectOfType<PlayerLife>();
    }

    // Update is called once per frame
    void Update () {

        CheckTrigger();

        if (isEntering)
        {
            InvokeRepeating("DealDamage", hitRate, hitRate);
        }
        else if (!isInside)
        {
            CancelInvoke("DealDamage");
        }
	}

    void DealDamage()
    {
        if (transform.position.y + deepOffset > PlayerLife.transform.position.y)
        {
            PlayerLife.GetDamage(damage);
        }
     }
}
