using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManage : MonoBehaviour
{
	
	public bool play;
	public BlockSpawner spawn;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
 		
 			if (Input.anyKeyDown)
 			{
 				play = true;
 				spawn.startPlaying = true;
 			}
    }
}
