using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TimeManager : MonoBehaviour 
{
    public static float time = 120;
    private Text text;
	// Use this for initialization
	void Start ()
    {
        text = GetComponent<Text>();
        string temp;
        temp = (time / 60).ToString() + ":" + (time % 60).ToString() + (time % 60).ToString();
        text.text = temp;
	}
	
	// Update is called once per frame
    void Update()
    {
        if (((int)time) > 0)
        {
            time -= Time.deltaTime;
            string temp;
            temp = ((int)time / 60).ToString() + ":" + ((int)(time % 60)).ToString();
            text.text = temp;
        }
        else
        {

        }
    }
}
