using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class TriggerByDistance : MonoBehaviour
{
    public Transform target;
    [SerializeField] float distanceToTrigger;

    

    protected bool isEntering { get; set; }
    protected bool isInside { get; set; }

    void Start()
    {
        if (target == null)
        {
            target = GameObject.Find("Player").transform;
        }
    }

   protected  void CheckTrigger()
    {
        float distance = Vector3.Distance(transform.position, target.transform.position);

        if (distance >= distanceToTrigger)
        {
            isInside = false;
            isEntering = false;
        }
        else if (isInside)
        {
            isEntering = false;
        }
        else
        {
            isInside = true;
            isEntering = true;
        }
    }



}
