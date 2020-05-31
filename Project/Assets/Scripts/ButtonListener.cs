using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System; 
using System.IO;


public class ButtonListener : MonoBehaviour
{
	//GvrControllerInput controller; 
    // Start is called before the first frame update
    GameObject hit; 
    string tag; 

    void Start()
    {
     	   //controller = GetComponent<GvrControllerInput>(); 
    }

    // Update is called once per frame
    void Update()
    {
    	HandleControllerInput();
        
    }

    private void HandleControllerInput() {
    	Debug.Log("method going");
    	if (GvrControllerInput.ClickButton) {
    		Debug.Log("clicked");
			hit = GvrPointerInputModule.CurrentRaycastResult.gameObject; 
			tag = hit.tag; 
			try {
				SceneManager.LoadScene(tag);
			} catch (IOException e) {

			}
    		
    	}
    }
/*
    public override void OnPointerClick(PointerEventData data) {
    	Debug.log("clicked");
    }*/
}
