using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdvancedEnemy : MonoBehaviour {
    
    [SerializeField]
    float followPlayerDistance;
    
    MovementRandom randomMovement;
    FollowMovement followMovement;
    GameObject player;

    void Awake()
    {
        player = GameObject.Find("Player");
        randomMovement = GetComponent<MovementRandom>();
        followMovement = GetComponent<FollowMovement>();
    }

	
	// Update is called once per frame
	void Update () {
        float distance = Vector3.Distance(player.transform.position, transform.position);
        if (distance<followPlayerDistance)
        {
            randomMovement.enabled = false;
            followMovement.enabled = true;
        }
        else
        {

            randomMovement.enabled = true;
            followMovement.enabled = false;
        }

	}
}
