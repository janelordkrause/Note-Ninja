using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockMover : MonoBehaviour
{
	[SerializeField]
	private int speed = 1;

    // Update is called once per frame
    void Update()
    {
    	//the blocks move forward, in the positive z direction
        transform.position += Vector3.back * Time.deltaTime * speed;
    }
}
