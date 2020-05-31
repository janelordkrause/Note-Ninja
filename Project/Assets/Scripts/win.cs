using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class win : MonoBehaviour
{
	public Text youWin;
	void Start()
	{
		StartCoroutine(Flash());
	}

    // Update is called once per frame
    public IEnumerator Flash()
    {
        while(true)
        {
        	        youWin.GetComponent<Text>().color = Color.black;
        yield return new WaitForSeconds(.5f);
        youWin.GetComponent<Text>().color = Color.white;
        yield return new WaitForSeconds(.5f);

        }

    }
}

