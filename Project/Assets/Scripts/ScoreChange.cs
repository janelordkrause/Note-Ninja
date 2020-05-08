using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreChange : MonoBehaviour
{

	public Text scoreText;
	public GameObject spawn;
    public BlockSpawner spawnScript;

    //always called before start function
    void Awake()
    {
        spawn = GameObject.Find("BlockSpawner");
        spawnScript = spawn.GetComponent<BlockSpawner>();
    }
    // Update is called once per frame
    void Update()
    {
    	int score = spawnScript.score;
    	string message = "Score: " + score.ToString();
    	scoreText.text = message;
    }
}
