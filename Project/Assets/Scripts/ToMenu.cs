using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System; //for Math
using UnityEngine.SceneManagement;

public class ToMenu : MonoBehaviour
{
    public GameObject Slices; //prefab of the two cut blocks

    public GameObject saber;
    private SaberSplit saberSplit;

    public GameObject head;



    //always called before start function
    void Awake()
    {
        saber = GameObject.FindGameObjectWithTag("Saber"); 
        saberSplit = saber.GetComponent<SaberSplit>(); //connects to script with info about saber movements
 

        //head = GameObject.FindGameObjectWithTag("MainCamera");
        head = GameObject.FindGameObjectWithTag("MainCamera");

    }

    void Start()
    {
        //Debug.Log(head.transform.position);
    }

    void Update()
    {
        //Debug.Log(head.transform.position);
    }

    //called when block is hit
    //SOURCEhttps://www.youtube.com/watch?v=3g5_8sE18tQ
    void OnTriggerEnter(Collider hit)
    {
        if (hit.tag == "Saber") //checks to make sure it was the saber that hit it
        {
            //Debug.Log(saberSplit.rightDirection);
            Instantiate(Slices, transform.position, transform.rotation); //instantiates new split block object, , transform.position, transform.rotation
gameObject.SetActive(false);

            // SceneManager.LoadScene(0);
            Debug.Log("back to menu");
            
        }


    }


    
}
