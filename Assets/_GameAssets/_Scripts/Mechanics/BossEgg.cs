using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossEgg : EntityLife {

    [SerializeField] int damage=1;

    Boss boss;


    protected override void Dye()
    {
        boss = FindObjectOfType<Boss>();
        if (boss)
        {
            boss.GetDamage(damage);
            Destroy(gameObject);
        }
     
    }

 
}
