using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*this code was written with help from from www.youtube.com/watch?v=3RQmzVGI8tQ,
www.youtube.com/watch?v=1h2yStilBWU, www.youtube.com/watch?v=ydjpNNA5804*/

//the blocks spawn at the position of the spawner, so to create spawns
//in different locations we should either add spawners or randomize location

public class BlockSpawner : MonoBehaviour
{
	public GameObject block;
	private static float MIN_X = -2.5f;
	private static float MAX_X = 2.5f;
	private static float MIN_Y = 1.5f;
	private static float MAX_Y = 4.0f;
	private static int[] X_ROTATIONS = {0, 90, 180, 270}; //angles to rotate blocks
	//private static int Y_ROTATION = 90;
	//private static int Z_ROTATION = 0;
	public bool stop = false;
	public float beat = 1; //equals 60/bpm;
    
    void Start()
    {
    	StartCoroutine(SpawnBlock());
    }

    IEnumerator SpawnBlock()
    {
    	while (!stop)
    	{
    		float xPos = Random.Range(MIN_X, MAX_X);
    		float yPos = Random.Range(MIN_Y, MAX_Y);
    		Vector3 position = new Vector3(xPos, yPos, transform.position.z);
    		int angleIndex = Random.Range(0, 3);
    		//Vector3 rotation = new Vector3(X_ROTATIONS[angleIndex], Y_ROTATION, Z_ROTATION);
			Vector3 baseRotation = block.transform.localEulerAngles; //gets defaut y and z rotations
    		baseRotation.x = X_ROTATIONS[angleIndex];
    		Instantiate(block, position, Quaternion.Euler(baseRotation));

    		yield return new WaitForSeconds(beat);
    	}
    }
}