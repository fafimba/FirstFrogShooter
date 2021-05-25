using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heal : TriggerByDistance
{

    [SerializeField]int healAmount = 2;

    PlayerLife playerLife;

    // Use this for initialization
    void Awake()
    {
        playerLife = FindObjectOfType<PlayerLife>();
        target = playerLife.transform;
    }

   void Update()
    {
        CheckTrigger();

        if (isEntering && playerLife.IsDamaged())
        {
            playerLife.Heal(healAmount);
            Destroy(gameObject);
        }
    }
    
}
