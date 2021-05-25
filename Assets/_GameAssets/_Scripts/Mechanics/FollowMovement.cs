using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowMovement : MonoBehaviour {


    [SerializeField]
    float speed = 5;

    GameObject player;
    CharacterController characterController;

    void Awake()
    {
        player = GameObject.Find("Player");
        characterController = GetComponent<CharacterController>();
    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        Vector3 direction = player.transform.position - transform.position;

        direction.Normalize();

        transform.forward = direction;
        characterController.SimpleMove(direction * speed);
       
	}
}
