using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WallCollision : MonoBehaviour
{
	public GameObject camera;
	[SerializeField]
	public bool wasHit;

	private float timeHit = 0;

    //runs before start
    void Awake()
    {
    	wasHit = false;
    }

    void Update()
    {
    	if (wasHit == true)
    	{
    		timeHit = timeHit + Time.deltaTime;
    	}
    	else
    	{
    		timeHit = 0; //resets time if you are no longer touching wall
    	}
    	checkTimeHit();
    }

    void OnTriggerEnter(Collider hit)
    {
        if (hit.tag == "MainCamera") //checks to make sure it was the camera that hit it
        {
        	wasHit = true;
        }
    }

    void OnTriggerExit(Collider hit)
    {
    	wasHit = false; //no longer touching wall
    }

    void checkTimeHit()
    {
    	if (timeHit > 1.0f) //if you have been touching the wall for 1+ seconds
    	{
    		SceneManager.LoadScene(1); // loads you lose page
    	}
    }
}
