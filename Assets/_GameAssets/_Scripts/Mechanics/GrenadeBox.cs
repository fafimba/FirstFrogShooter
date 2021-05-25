using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeBox : TriggerByDistance
{


    [SerializeField] int grenades = 4;

    ThrowGrenade throwGrenade;

    void Start()
    {
        throwGrenade = FindObjectOfType<ThrowGrenade>();
        target = throwGrenade.transform;
    }

    void Update()
    {
   
        CheckTrigger();
        if (isInside)
        {
            if (throwGrenade.currentGrenades < throwGrenade.maxGrenades)
            {
                throwGrenade.AddGrenades(grenades);
                Destroy(gameObject);
            }
     
        }
        
    }
}
