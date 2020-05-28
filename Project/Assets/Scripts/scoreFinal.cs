using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System; //for Math
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class scoreFinal : MonoBehaviour
{
 
    public Text finalScoreText;

    // public GameObject scoreKeep;
    // public KeepScore keeper;
    // public GameObject spawn;
    // public BlockSpawner spawnScript



    //always called before start function
    void Awake()
    {
        // scoreKeep = GameObject.Find("ScoreKeeper");
        // keeper = scoreKeep.GetComponent<KeepScore>();
        //         spawn = GameObject.Find("BlockSpawner");
        // spawnScript = spawn.GetComponent<BlockSpawner>();
        int endScore = PlayerPrefs.GetInt("Score");
        finalScoreText.GetComponent<Text>().text = endScore.ToString();
        //keeper.scoreFinish.ToString();
        Debug.Log("score");

    }


 }


    

    

