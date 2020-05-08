using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pointer : MonoBehaviour
{
	public float m_Default = 5.0f; 
	public GameObject dot; 
	//public VRInputmodule m_inputModule; 

	private LineRenderer lineR = null; 
     
    private void Awake() {
    	lineR = GetComponent<LineRenderer>(); 
    }



    // Update is called once per frame
    private void Update()
    {
     	UpdateLine();   
    }

    private void UpdateLine() {
    	// use default length OR distance from input
    	float targetLen = m_Default;

    	//ray cast
    	RaycastHit hit = CreateRaycast(targetLen);

    	//default end
    	Vector3 endPos = transform.position + (transform.forward * targetLen);

    	//or based on hit 
    	if (hit.collider != null) {
    		endPos = hit.point; 
    	}

    	//set position of the dot
    	dot.transform.position = endPos;

    	//setting position of linerenderer
    	lineR.SetPosition(0, transform.position);
    	lineR.SetPosition(0, endPos);

    }

    private RaycastHit CreateRaycast(float length) {
    	RaycastHit hit; 
    	Ray ray = new Ray(transform.position, transform.forward);
    	Physics.Raycast(ray, out hit, m_Default);
    	return hit; 
    }
}
