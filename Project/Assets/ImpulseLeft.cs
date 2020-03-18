using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImpulseLeft : MonoBehaviour
{
	public Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>(); //collects rigidbodies of both halves of split cube

        //SOURCEhttps://learn.unity.com/tutorial/3d-physics#5c7f8528edbc2a002053b511
        rb.AddForce(Vector3.left * 3, ForceMode.Impulse); //adds force on cubes
        rb.AddForce(Vector3.up * 3, ForceMode.Impulse); //adds force on cubes
        rb.AddForce(Vector3.back, ForceMode.Impulse); //adds force on cubes
        Invoke("destroyGameObject", 10); //destroys slice after 10 seconds 
    }

    void destroyGameObject()
    {
    	Destroy(gameObject);
    }
}

