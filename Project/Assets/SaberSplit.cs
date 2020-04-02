﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System; //for Math

//script on saber to check that it is moving fast enough to split the block
public class SaberSplit : MonoBehaviour
{	
	BoxCollider bc;
	Vector3 oldPosition; //to track velocity
	Vector3 newPosition;

	public bool rightDirection = false;

	float minSliceSpeed = 0.0004f; //f indicates that it is a float

    void Start()
    {
        bc = GetComponent<BoxCollider>(); //gets rigid body
        oldPosition = transform.position;
    }

    void Update()
    {
    	newPosition = transform.position;
    	checkSpeed(); //makes sure saber is moving fast enough (turns on / off box collider)
    	checkDirection();
    	oldPosition = newPosition;
    }

    void checkSpeed()
    {
    	//note: can't use the built in velocity vector because the Rigidbody is kinematic 
        float saberSpeed = (newPosition - oldPosition).magnitude * Time.deltaTime;
        //Debug.Log(saberSpeed);
		if (saberSpeed > minSliceSpeed) //only turn on box collider if the saber is moving fast enough
        {
        	bc.enabled = true;
        }
        else //saber can't cut if it isn't moving fast enough
        {
        	bc.enabled = false;
        }
    }

    void checkDirection()
    {
    	//up and down block x-rotation = 270 
    	Vector3 velocity = (newPosition - oldPosition) / Time.deltaTime;
    	float blockXRotation = velocity.x - 270; //determines which way the block is turned
    	//Debug.Log(velocity.x);
    	if (velocity.y < 0 && Math.Abs(velocity.x) < 1) //1 = constant for how much x velocity can change when slicing down
    	//next step: make this generalized (so that it takes the rotation of the block as an input and determines what these values must be)
    	{
    		rightDirection = true; //cutting down
    	}
    	else
    	{
    		rightDirection = false; 
    	}
    	//Debug.Log(velocity);
    	//if (velocity.y < 0)
    }
}
