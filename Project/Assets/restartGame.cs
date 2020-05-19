using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class restartGame : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("returnToGame", 8); //restarts game after 8 seconds
    }

    // Update is called once per frame
    void returnToGame()
    {
        SceneManager.LoadScene(0); // TEMPORARAY: returns to first scene
    }
}
