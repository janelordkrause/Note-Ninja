using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class SongMenu : MonoBehaviour
{
 	public void entertainerButton() {
    	SceneManager.LoadScene(3); 
    }
    public void quitButton() {
    	Application.Quit(); 
    }   
}
