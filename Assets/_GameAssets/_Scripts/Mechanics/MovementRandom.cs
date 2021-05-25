using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementRandom : MonoBehaviour {

    [SerializeField]
    float speed = 5;
    [SerializeField]
    float changeDirectionDelay = 2;
    [SerializeField]
    float rotationSpeedDegrees = 90;
    [SerializeField]
    float mapWith = 100;
    [SerializeField]
    float mapDepth = 100;


    CharacterController _characterController;
    Vector3 _randomDirection;


    void Awake()
    {
        _characterController = GetComponent<CharacterController>();
        InvokeRepeating("NewDestinationPoint", 0, changeDirectionDelay);
    }
	
	// Update is called once per frame
	void Update () {
        Move(_randomDirection);
	}

    /// <summary>
    /// Move the GameObject to the destination point
    /// </summary>
    void Move(Vector3 destinationPoint)
    {

        //set the forward position to make the GameObject look at the destination point
        // transform.forward = Vector3.Lerp(transform.forward, destinationPoint, rotationSpeed * Time.deltaTime);

        transform.forward = Vector3.RotateTowards(transform.forward, destinationPoint, rotationSpeedDegrees * Mathf.Deg2Rad * Time.deltaTime,1f);

        _characterController.SimpleMove(transform.forward * speed);

        Vector3 currentPosition = transform.position;
        currentPosition.x = Mathf.Clamp(currentPosition.x, 1f, mapWith);
        currentPosition.z = Mathf.Clamp(currentPosition.z, 1f, mapDepth);

        transform.position = currentPosition;
    }

    /// <summary>
    /// Create and give a new random destination point
    /// </summary>
    /// <returns>new vector position</returns>
    void NewDestinationPoint()
    {

       Vector2 randomPointCircle = Random.insideUnitCircle;
       float x = randomPointCircle.x;
       float z = randomPointCircle.y;

       _randomDirection = new Vector3(x, 0, z);
       _randomDirection.Normalize();
    }

}
