using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*this code is adapted from www.youtube.com/watch?v=1h2yStilBWU,
www.youtube.com/watch?v=ydjpNNA5804*/

//the blocks spawn at the position of the spawner, so to create spawns
//in different locations we should either add spawners or randomize location

public class BlockSpawner : MonoBehaviour
{
    public GameObject block;
    private static float MIN_X = -2.0f;
    private static float MAX_X = 2.0f;
    private static float MIN_Y = 1.5f;
    private static float MAX_Y = 3.0f;
    private static int[] X_ROTATIONS = {0, 90, 180, 270}; //angles to rotate blocks
    private static string[] X_TAGS = {"left", "up", "right", "down"}; //corresponding slice direction
    private static int Y_ROTATION = 90;
    private static int Z_ROTATION = 0;
    public float beat; 
    public bool startPlaying = false;
    public AudioSource music;
    private bool startSpawn;
    private bool songLength;
    private Coroutine spawns;

    
    void Start()
    {
        beat = 60f/beat;
    }
    void Update()
    {
        if (startSpawn == false)
        {
            if (startPlaying == true)
            {
                spawns = StartCoroutine(SpawnBlock());
                startSpawn = true;
            }
        }
        if (music.isPlaying == false && startSpawn == true)
        {
            StopCoroutine(spawns);
            music.Stop();
            Debug.Log("end");
        }
    }
    IEnumerator SpawnBlock()
    {
            music.Play();
            while (true)
            {
                float xPos = Random.Range(MIN_X, MAX_X);
                float yPos = Random.Range(MIN_Y, MAX_Y);
                Vector3 position = new Vector3(xPos, yPos, transform.position.z);
                int angleIndex = Random.Range(0, 4); //never chooses the top num (glitch?)
                Vector3 rotation = new Vector3(X_ROTATIONS[angleIndex], Y_ROTATION, Z_ROTATION);
                block.gameObject.tag = X_TAGS[angleIndex]; //adds tag of direction they need to be sliced
                Instantiate(block, position, Quaternion.Euler(rotation));
                yield return new WaitForSeconds(beat);
            }
        
        
    }
}