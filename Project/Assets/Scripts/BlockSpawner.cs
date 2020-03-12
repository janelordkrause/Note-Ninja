using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//this code is adapted from www.youtube.com/watch?v=1h2yStilBWU

//the blocks spawn at the position of the spawner, so to create spawns
//in different locations we should either add spawners or randomize location

public class BlockSpawner : MonoBehaviour
{
    public GameObject block;
    public bool stop = false;
    public float beat = 1; //equals 60/bpm;

    void Start()
    {
    	InvokeRepeating("SpawnBlock", 0, beat);	
    }

    public void SpawnBlock()
    {
    	Instantiate(block, transform.position, transform.rotation);
    	if (stop)
    	{
    		CancelInvoke("SpawnBlock");
    	}
    }
}