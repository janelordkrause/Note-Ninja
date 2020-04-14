using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Threading.Tasks;

public class Lighting : MonoBehaviour
{
	public Material[] materials; 
	//public Material materialOrig; 
    Renderer rend;
    public int count; 
    void Start()
    {
        count = 0; 
        //rend.sharedMaterial = material[;
    }
    

    public void changeBackground()
    {
    	rend = GetComponent<Renderer>();
        rend.enabled = true;

		if (rend != null) {
			rend.material = materials[count%3];
			count += 1; 
			
		} 
    }
}

/*
var t = Task.Run(async delegate{
					await Task.Delay(500);
					rend.material = materialOrig;

				});
			t.Wait();
			Console.WriteLine("status: {0}", t.Status);
			*/
