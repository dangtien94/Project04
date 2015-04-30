using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class VictoryScoreManager : MonoBehaviour 
{
    public static int victoryscore;
    private Text text;
	// Use this for initialization
	void Start () 
    {
        text = GetComponent<Text>();
        text.text = "Victory: " + victoryscore.ToString();
        victoryscore = 5000;
	}
	
	// Update is called once per frame
	void Update () 
    {
        if (victoryscore <= 0)
        {
            TimeManager.time = 120;
            victoryscore += 5000;
        }
        else
        {
            text.text = "Victory: " + victoryscore.ToString();
        }
	}
}
