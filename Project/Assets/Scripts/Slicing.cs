﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System; //for Math

public class Slicing : MonoBehaviour
{
    public GameObject Slices; //prefab of the two cut blocks

    public GameObject saber;
    private SaberSplit saberSplit;
    public GameObject world; //to be used for lighting effects
    public Lighting lightScript;

    //always called before start function
    void Awake()
    {
        saber = GameObject.FindGameObjectWithTag("Saber"); 
        saberSplit = saber.GetComponent<SaberSplit>(); //connects to script with info about saber movements
        world = GameObject.FindGameObjectWithTag("world");
        lightScript = world.GetComponent<Lighting>();
    }

    void Start()
    {
        Invoke("destroyGameObject", 20); //destroys unhit blocks after 20 seconds
    }

    //called when block is hit
    //SOURCEhttps://www.youtube.com/watch?v=3g5_8sE18tQ
    void OnTriggerEnter(Collider hit)
    {
        if (hit.tag == "Saber") //checks to make sure it was the saber that hit it
        {
            //Debug.Log(saberSplit.rightDirection);
            if (checkBlockDirection() == true) //checks to make sure saber is moving in the right direction before actually cutting 
            {
                Instantiate(Slices, transform.position, transform.rotation); //instantiates new split block object, , transform.position, transform.rotation
                Destroy(gameObject); //destroys normal cube
                lightScript.changeBackground();
            }
        }
    }

    void destroyGameObject()
    {
        Destroy(gameObject);
    }

    bool checkBlockDirection()
    {
        Vector3 velocity = saberSplit.velocity; //gets velocity of saber from other script

        //inefficient?
        //gets tag of block and makes sure you are slicing in right direction (euler angles aren't always accurate)
        if (gameObject.tag == "down" && velocity.y < 0 && Math.Abs(velocity.x) < 1) //1 = constant for how much x velocity can change when slicing down
        {
            return true; //cutting down
        }
        else if (gameObject.tag == "up" && velocity.y > 0 && Math.Abs(velocity.x) < 1)
        {
            return true;
        }
        else if (gameObject.tag == "left" && velocity.x < 0 && Math.Abs(velocity.y) < 1)
        {
            return true;
        }
        else if (gameObject.tag == "right" && velocity.x > 0 && Math.Abs(velocity.y) < 1)
        {
            return true;
        }
        else
        {
            return false; 
        }
    }
}
