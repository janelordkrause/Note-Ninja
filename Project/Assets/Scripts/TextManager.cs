using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//for testing headset positionhttps://www.youtube.com/watch?v=wlY5sRewfVQ
public class TextManager : MonoBehaviour
{
	public Vector3 position;
	public GameObject head;
    public GameObject wall;
    public WallCollision script;

	Text text; 

    // Start is called before the first frame update
    void Awake()
    {
    	head = GameObject.FindGameObjectWithTag("MainCamera");
        text = GetComponent<Text>();
        position = head.transform.position;

        wall = GameObject.FindGameObjectWithTag("Wall");
        script = wall.GetComponent<WallCollision>();
    }

    // Update is called once per frame
    void Update()
    {
    	position = (head.transform.position);
        text.text = "Position: " + script.wasHit;
    }
}
