using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyExplotionAttack : TriggerByDistance
{


    [SerializeField]
    GameObject explotion;
    [SerializeField]
    int damage = 1;

    PlayerLife PlayerLife;

    void Awake()
    {
        if (!target)
        {
            target = GameObject.Find("Player").transform;
        }
        PlayerLife = target.GetComponent<PlayerLife>();

    }

    // Update is called once per frame
    void Update()
    {

        CheckTrigger();
        if (isInside)
        {
            GameObject boom = Instantiate(explotion);
            boom.transform.position = transform.position;
            Destroy(boom, 1f);

            PlayerLife.GetDamage(damage);

            Destroy(gameObject);
        }

    }
}
