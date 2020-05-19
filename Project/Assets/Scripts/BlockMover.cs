using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockMover : MonoBehaviour
{
	public static int speed = 20;
	void Start()
	{
		
	}

    // Update is called once per frame
    void Update()
    {
    	//the blocks move forward, in the positive z direction
        transform.position += Vector3.back * Time.deltaTime * speed;
    }
}
