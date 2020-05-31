using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyWall : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("destroyObject", 20);
    }

    void destroyObject()
    {
    	Destroy(gameObject); //destroys self
    }
}
