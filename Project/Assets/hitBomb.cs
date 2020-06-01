using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class hitBomb : MonoBehaviour
{
	public GameObject saber;

	public GameObject explosion;

	public float force = 20.0f;
	public float radius = 5.0f;
	public float upforce = 1.0f;

	bool hasExploded = false;

    void Awake()
    {
    	saber = GameObject.FindGameObjectWithTag("Saber"); //finds saber
    }
    
    void OnTriggerEnter(Collider hit)
    {
        if (hit.tag == "Saber" && hasExploded == false) //checks to make sure it was the saber that hit it
        {
        	Explode();
        	hasExploded = true;
        	//impulse/explosion animation
            //then goes to game over page
        }
    }

    void Explode()
    {
    	Instantiate(explosion, transform.position, transform.rotation);

    	//Destroy(gameObject); //destroys bomb

    	Invoke("loadYouLose", 2);

    }

    void loadYouLose()
    {
    	SceneManager.LoadScene(4); // loads you lose page
    }
}
