﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//using UnityEngine.SceneManagement;

using System; 
using System.IO;


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
    public AudioSource music;
    private bool startSpawn;
    private bool songLength;
    private Coroutine spawns;

    private string songFileLine;
    private StreamReader reader;

    public int score;
    private int pointsPerHit;
    public int health;
    public bool wasHit;
    public int misses;
    
    void Start()
    {
        beat = 60f/beat;

        reader = new StreamReader("Assets/Resources/sampleSong.txt");

        health = 50;
        pointsPerHit = 100;
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
            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        }
    }
    IEnumerator SpawnBlock()
    {
            music.Play();
            //sourcehttps://www.dotnetperls.com/readline
            while ((songFileLine = reader.ReadLine()) != null) //makes sure next line is not null (reads each line)
            {
                int scoreTemp = score;
                int angleIndex = Array.IndexOf(X_TAGS, songFileLine);
                Vector3 rotation = new Vector3(X_ROTATIONS[angleIndex], Y_ROTATION, Z_ROTATION);
                block.gameObject.tag = X_TAGS[angleIndex]; //adds tag of direction they need to be sliced

                float xPos = UnityEngine.Random.Range(MIN_X, MAX_X);
                float yPos = UnityEngine.Random.Range(MIN_Y, MAX_Y);
                Vector3 position = new Vector3(xPos, yPos, transform.position.z);
                //int angleIndex = UnityEngine.Random.Range(0, 4); //never chooses the top num (glitch?)

                Instantiate(block, position, Quaternion.Euler(rotation));

                yield return new WaitForSeconds(beat);

            }
        
        
    }
    public void Hit()
    {
        score+=pointsPerHit;
        if (health != 100)
        {
            double hithealth = health*1.02;
            health=(int) hithealth;
        }
    }
    public void Miss()
    {
        if (health == 0)
        {
            StopCoroutine(spawns);
            music.Stop();
        }
        else
        {
            double misshealth = health*0.70;
            health= (int) misshealth;
            misses++;
        }
    }
}