using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class lose : MonoBehaviour
{
	public Text youLose;
	void Start()
	{
		StartCoroutine(Flash());
	}

    // Update is called once per frame
    public IEnumerator Flash()
    {
        while(true)
        {
        	        youLose.GetComponent<Text>().color = new Color32(82, 183, 203, 255);
        yield return new WaitForSeconds(.5f);
        youLose.GetComponent<Text>().color = new Color32(219, 67, 67, 255);
        yield return new WaitForSeconds(.5f);

        }

    }
}

