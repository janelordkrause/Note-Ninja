using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class MainMenu : MonoBehaviour
{
    public void songButton() {
    	SceneManager.LoadScene(1); 
    }

    public void settingsButton() {
    	SceneManager.LoadScene(2); 
    }
    public void quitButton() {
    	Application.Quit(); 
    }
}
