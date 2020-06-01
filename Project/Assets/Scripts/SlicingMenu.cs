using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System; //for Math
using UnityEngine.SceneManagement; // for switching scenes 
using System.IO;

public class SlicingMenu : MonoBehaviour
{
    public GameObject Slices; //prefab of the two cut blocks

    public GameObject saber;
    private SaberSplit saberSplit;
    public GameObject world; //to be used for lighting effects
    public Lighting lightScript;
    public string tag; 
    public GameObject head;
    public Renderer rend; 

    //always called before start function
    void Awake()
    {
        saber = GameObject.FindGameObjectWithTag("Saber"); 
        saberSplit = saber.GetComponent<SaberSplit>(); //connects to script with info about saber movements
        world = GameObject.FindGameObjectWithTag("world");
        lightScript = world.GetComponent<Lighting>();
        rend = GetComponent<Renderer>(); 
        head = GameObject.FindGameObjectWithTag("MainCamera");
    }

    void Start()
    {
        Invoke("destroyGameObject", 20); //destroys unhit blocks after 20 seconds
        Debug.Log(head.transform.position);
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
            if (checkBlockDirection() == true) //checks to make sure saber is moving in the right direction before actually cutting 
            {
                Instantiate(Slices, transform.position, transform.rotation); 
                //instantiates new split block object, , transform.position, transform.rotation
                //lightScript.changeBackground();
                transform.localScale = new Vector3(0,0,0);
                StartCoroutine(timeDelay());

                //gameObject.SetActive(false); 
                //Destroy(gameObject); //destroys normal cube

            }
        }
    }

    void tryScene()
    {
        //Debug.Log("Hello"); 
        tag = gameObject.tag;
                
                try {
                    // Invoke("getScene", 2);
                    SceneManager.LoadScene(tag);
                   
                } catch (FileNotFoundException e) {
                    #if UNITY_EDITOR
                        UnityEditor.EditorApplication.isPlaying = false; 
                    #else 
                        Application.Quit();
                    #endif
                }
    }


    void destroyGameObject()
    {
        Destroy(gameObject);
    }

    bool checkBlockDirection()
    {
        Vector3 velocity = saberSplit.velocity; //gets velocity of saber from other script

        //inefficient?
        //gets tag of block and makes sure you are slicing in right direction (euler angles aren't always accurate)
        if (velocity.y < 0 && Math.Abs(velocity.x) < 1) //1 = constant for how much x velocity can change when slicing down
        {
            return true; //cutting down
        } else {
            return false; 
        }
        
    }

    IEnumerator timeDelay() {
        yield return new WaitForSeconds(1);
        tryScene();
    }
}
