using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreManager : MonoBehaviour
{
    public static int curentscore;
    Text text;
	// Use this for initialization
	void Start () 
    {
        curentscore = 0;
        text = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () 
    {
        text.text = "Score: " + curentscore.ToString();
	}
}
