using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slicing : MonoBehaviour
{
    pubic GameObject Slices; //prefab of the two cut blocks
    
    //called when block is hit
    void OnTriggerEnter(Collider hit)
    {
        if (hit.tag == "Saber") //checks to make sure it was the saber that hit it
        {
            Instantiate(Slices, transform.position, transform.rotation); //instantiates new split block object
            Destroy(gameObject); //destroys normal cube
        }
    }
}
