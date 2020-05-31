using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class healthBar : MonoBehaviour
{
    public Image currentHealthBar;
    public Text percentText;
    public GameObject spawn;
    public BlockSpawner spawnScript;
    private float healthPercent = 0.5f;
    void Awake()
    {
    	spawn = GameObject.Find("BlockSpawner");
        spawnScript = spawn.GetComponent<BlockSpawner>();
    }
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    	int health = spawnScript.health;   
    	healthPercent = health/100f;
        percentText.text = health.ToString() + "%";
        currentHealthBar.rectTransform.localScale = new Vector3(healthPercent, 1, 1);
        if (health>30 && health<60)
        {
        	currentHealthBar.GetComponent<Image>().color = new Color32(180, 190, 80, 245);
        	percentText.GetComponent<Text>().color = Color.black;
        }
        else if (health>=60)
        {
			currentHealthBar.GetComponent<Image>().color = new Color32(4, 168, 13, 255);
        }
        else if (health<30)
        {
        	currentHealthBar.GetComponent<Image>().color = new Color32(180, 16, 14, 245);
        }
    }
}
