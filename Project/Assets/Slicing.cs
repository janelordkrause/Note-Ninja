using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slicing : MonoBehaviour
{
    public GameObject Slices; //prefab of the two cut blocks

    //called when block is hit
    //SOURCEhttps://www.youtube.com/watch?v=3g5_8sE18tQ
    void OnTriggerEnter(Collider hit)
    {
        if (hit.tag == "Saber") //checks to make sure it was the saber that hit it
        {
            Instantiate(Slices, transform.position, transform.rotation); //instantiates new split block object, , transform.position, transform.rotation
            Destroy(gameObject); //destroys normal cube
        }
    }
}
