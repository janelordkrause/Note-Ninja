using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hitBomb : MonoBehaviour
{
	public GameObject saber;

	public float force = 20.0f;
	public float radius = 5.0f;
	public float upforce = 1.0f;

    void Awake()
    {
    	saber = GameObject.FindGameObjectWithTag("Saber"); //finds saber
    }
    
    void OnTriggerEnter(Collider hit)
    {
        if (hit.tag == "Saber") //checks to make sure it was the saber that hit it
        {
        	Explode();
        	//impulse/explosion animation
            //then goes to game over page
        }
    }

    void Explode()
    {
    	Vector3 bombPosition = gameObject.transform.position;
    	Collider[] colliders = Physics.OverlapSphere(bombPosition, radius); //collects all the surrounding colliders
    	foreach (Collider hit in colliders) //goes through each collider
    	{
    		Rigidbody rb = hit.GetComponent<Rigidbody>();
    		if (rb != null) // check to make sure there is a rigidbody on hit
    		{
    			rb.AddExplosionForce(force, bombPosition, radius, upforce, ForceMode.Impulse);
    		}
    	}
    }
}
