using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System; 
using System.IO;

/*this code was written with help from from www.youtube.com/watch?v=3RQmzVGI8tQ,
www.youtube.com/watch?v=1h2yStilBWU, www.youtube.com/watch?v=ydjpNNA5804*/

//the blocks spawn at the position of the spawner, so to create spawns
//in different locations we should either add spawners or randomize location

public class BlockSpawner : MonoBehaviour
{
    public GameObject block;
    private static float MIN_X = -2.0f;
    private static float MAX_X = 2.0f;
    private static float MIN_Y = 1.5f;
    private static float MAX_Y = 3.8f;
    private static int[] X_ROTATIONS = {0, 90, 180, 270}; //angles to rotate blocks
    private static string[] X_TAGS = {"left" , "up", "right", "down"}; //corresponding slice direction
    private static int Y_ROTATION = 90;
    private static int Z_ROTATION = 0;
    public float beat; 
    public AudioSource music;
    private bool startSpawn;
    private bool songLength;
    private Coroutine spawns;
    private string songFileLine;
    private StreamReader reader;
    
    void Start()
    {
        beat = 60f/beat;

        //reader = new StreamReader("Assets/Resources/sampleSong.txt");
        reader = new StreamReader("Assets/Resources/testRotation.txt");
    }

    void Update()
    {
        if (startSpawn == false)
        {
            spawns = StartCoroutine(SpawnBlock());
            startSpawn = true;
        }
        if (music.isPlaying == false && startSpawn == true)
        {
            StopCoroutine(spawns);
            music.Stop();
            //Debug.Log("end");
        }
    }
    IEnumerator SpawnBlock()
    {
            music.Play();
            //sourcehttps://www.dotnetperls.com/readline
            while ((songFileLine = reader.ReadLine()) != null) //makes sure next line is not null (reads each line)
            {
                string[] blockInfo = songFileLine.Split(' '); //puts the info in the line into an array

                int angleIndex = Array.IndexOf(X_TAGS, blockInfo[0]); //direction is the first thing in the array
                Vector3 rotation = new Vector3(X_ROTATIONS[angleIndex], Y_ROTATION, Z_ROTATION);
                block.gameObject.tag = X_TAGS[angleIndex]; //adds tag of direction they need to be sliced
                
                float xPos = float.Parse(blockInfo[1]); //x position is the second thing in the array
                float yPos = float.Parse(blockInfo[2]);
                Vector3 position = new Vector3(xPos, yPos, transform.position.z);
                Instantiate(block, position, Quaternion.Euler(rotation));

                float wait = float.Parse(blockInfo[3]); //multiplier for wait time between blocks
                yield return new WaitForSeconds(beat * wait);
            }
            /*while (true) //spawns with random rotation and position
            {
            	int angleIndex = UnityEngine.Random.Range(0, 4); //never chooses the top num (glitch?)
                Vector3 rotation = new Vector3(X_ROTATIONS[angleIndex], Y_ROTATION, Z_ROTATION);
                block.gameObject.tag = X_TAGS[angleIndex]; //adds tag of direction they need to be sliced
                
                float xPos = UnityEngine.Random.Range(MIN_X, MAX_X);
                float yPos = UnityEngine.Random.Range(MIN_Y, MAX_Y);
                Vector3 position = new Vector3(xPos, yPos, transform.position.z);
                Instantiate(block, position, Quaternion.Euler(rotation));

                yield return new WaitForSeconds(beat);
            }*/
    }
}