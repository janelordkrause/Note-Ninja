using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using UnityEngine.SceneManagement;

using System; 
using System.IO;



//the blocks spawn at the position of the spawner, so to create spawns
//in different locations we should either add spawners or randomize location

public class BlockSpawner : MonoBehaviour
{
    public GameObject block;
    public GameObject wall;
    public GameObject bomb;

    //private static float MIN_X = -2.0f;
    //private static float MAX_X = 2.0f;
    //private static float MIN_Y = 1.5f;
    //private static float MAX_Y = 3.8f;
    private static int[] X_ROTATIONS = {0, 90, 180, 270, 45, 135, 225, 315}; //angles to rotate blocks
    private static string[] X_TAGS = {"left" , "up", "right", "down", "leftup", "rightup", "rightdown", "leftdown"}; //corresponding slice direction
    private static int Y_ROTATION = 90;
    private static int Z_ROTATION = 0;
    public float beat; 
    public AudioSource music;
    private bool startSpawn;
    private bool songLength;
    private int beatsBeforeStart; //beats of the song before blocks start spawning
    private Coroutine spawns;
    private string songFileLine;


    private StringReader reader;
    public TextAsset txt;


    public int score;
    private int pointsPerHit;
    public int health;
    public bool wasHit;

    public bool songReady;
    public GameObject entertainer; //gameobjects of songs
    public GameObject crabrave;
    
    void Start()
    {
        beat = 60f/beat;
        string song = txt.ToString(); //converts txt file into string
        reader = new StringReader(song);

        beatsBeforeStart = Int32.Parse(reader.ReadLine()); //first line contains only one number
        
        health = 50;
        pointsPerHit = 100;

        songReady = false;
    }

    void checkForSong()
    {
        if (entertainer.GetComponent<getSong>().nameOfSong != null) //checks to see if user has selected song
        {
            music = entertainer.GetComponent<AudioSource>();
            entertainer.GetComponent<Renderer>().enabled = false;
            GameObject.FindGameObjectWithTag("child").GetComponent<Renderer>().enabled = false;
            GameObject.FindGameObjectWithTag("child2").GetComponent<Renderer>().enabled = false;
            crabrave.GetComponent<Renderer>().enabled = false;

            songReady = true;

        }
        else if (crabrave.GetComponent<getSong>().nameOfSong != null)
        {
            music = crabrave.GetComponent<AudioSource>();
            crabrave.GetComponent<Renderer>().enabled = false;
            entertainer.GetComponent<Renderer>().enabled = false;
            GameObject.FindGameObjectWithTag("child").GetComponent<Renderer>().enabled = false;
            GameObject.FindGameObjectWithTag("child2").GetComponent<Renderer>().enabled = false;

            songReady = true;
        }
    }

    void Update()
    {
        checkForSong();

        if (startSpawn == false && songReady == true) //if spawning hasn't started yet
        {
			music.Play();

            //calculate what the delay between music and block spawn should be
            int blockSpeed = BlockMover.speed; //get speed of block from moving script
    		float distance = transform.position.z; //distance blocks travel to get to player
    		float travelTime = distance/blockSpeed; //time it takes for block to travel from spawner to player
            float delayTime = (beat*beatsBeforeStart) - travelTime; //so the block arrives at the right time
            //add some error catching for if delay time is negative
            if (delayTime < 0) Debug.Log("wait time too short");
            else spawns = StartCoroutine(SpawnBlock(delayTime));

            startSpawn = true;
        }
        if (music.isPlaying == false && startSpawn == true) //if music ended
        {
            StopCoroutine(spawns);
            music.Stop();
            PlayerPrefs.SetInt("Score", score);
            SceneManager.LoadScene(3);
            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        }
    }


    IEnumerator SpawnBlock(float initialDelay)
    {
            //sourcehttps://www.dotnetperls.com/readline
            
            yield return new WaitForSeconds(initialDelay);

            while ((songFileLine = reader.ReadLine()) != null) //makes sure next line is not null (reads each line)
            {

                string[] blockInfo = songFileLine.Split(' '); //puts the info in the line into an array

                //every line will have position info
                float xPos = float.Parse(blockInfo[1]); //x position is the second thing in the array
                float yPos = float.Parse(blockInfo[2]); //y position is the third
                Vector3 position = new Vector3(xPos, yPos, transform.position.z);

                //if it's a wall, it will say so, and it will contain info about size
                if (blockInfo[0] == "wall")
                {
                    float xScale = float.Parse(blockInfo[4]);
                    float yScale = float.Parse(blockInfo[5]);
                    float zScale = float.Parse(blockInfo[6]);

                    //source for how to instatiate with size: answers.unity.com/questions/1578968/how-do-i-instantiate-a-prefab-with-scale.html
                    GameObject go = Instantiate(wall, position, transform.rotation); //has default rotation
                    go.transform.localScale = new Vector3(xScale, yScale, zScale);
                }
                else if (blockInfo[0] == "bomb")
                {
                    Instantiate(bomb, position, transform.rotation);
                }
                
                //if it's not a wall or bomb, it is a block and it has rotation info as well
                else
                {
                    int angleIndex = Array.IndexOf(X_TAGS, blockInfo[0]); //direction is the first thing in the array
                    Vector3 rotation = new Vector3(X_ROTATIONS[angleIndex], Y_ROTATION, Z_ROTATION);
                    block.gameObject.tag = X_TAGS[angleIndex]; //adds tag of direction they need to be sliced
                    
                    Instantiate(block, position, Quaternion.Euler(rotation));
                }


                /*int angleIndex = Array.IndexOf(X_TAGS, blockInfo[0]); //direction is the first thing in the array

                Vector3 rotation = new Vector3(X_ROTATIONS[angleIndex], Y_ROTATION, Z_ROTATION);
                block.gameObject.tag = X_TAGS[angleIndex]; //adds tag of direction they need to be sliced
                
                float xPos = float.Parse(blockInfo[1]); //x position is the second thing in the array
                float yPos = float.Parse(blockInfo[2]);
                Vector3 position = new Vector3(xPos, yPos, transform.position.z);
                Instantiate(block, position, Quaternion.Euler(rotation));*/


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
    public void Hit()
    {
        score+=pointsPerHit;
        if (health != 100)
        {
            double hithealth = health*1.1;
            health=(int) hithealth;
        }
    }
    public void Miss()
    {
        if (health == 0)
        {
            StopCoroutine(spawns);
            music.Stop();
            SceneManager.LoadScene(4);
        }
        else
        {
            double misshealth = health*0.70;
            health= (int) misshealth;
        }
    }
}
