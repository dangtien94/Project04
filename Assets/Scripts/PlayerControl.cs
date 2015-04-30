using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerControl : MonoBehaviour 
{
    public Joystick leftjoystick = null;
    public Joystick rightjoystick = null;
    // Healthbar
    public RectTransform healthtransform;
    private float maxXvalue;
    private float minXvalue;
    private int maxhealth = 1000;
    public int currenthealth;// the health of player
    private float yAxis;
    public Image visualimage;
    // Healthbar
    private float movespeed;
    Rigidbody2D myrigi;
	// Use this for initialization
    void Start () 
    {   
        myrigi = GetComponent<Rigidbody2D>();
        // Healthbar
        currenthealth = (int)maxhealth;
        yAxis = healthtransform.position.y;
        maxXvalue = healthtransform.position.x;
        minXvalue = healthtransform.position.x - healthtransform.rect.width;
        // Healthbar
        
        if(leftjoystick == null)
        {
            GameObject gameobjleftjoystick = (GameObject)GameObject.FindGameObjectWithTag("LeftJoystick");
            leftjoystick = gameobjleftjoystick.GetComponent<Joystick>();
        }
        if (rightjoystick == null)
        {
            GameObject gameobjrightjoystick = (GameObject)GameObject.FindGameObjectWithTag("RightJoystick");
            rightjoystick = gameobjrightjoystick.GetComponent<Joystick>();
        }
        
    }
    void FixedUpdate()// Move and rotate game object
    {
        GetCurrentHealthbar();// Healthbar
        if (leftjoystick.position.x == 0 || leftjoystick.position.y == 0)
        {
            //Rigidbody2D myrigi = GetComponent<Rigidbody2D>();
            myrigi.velocity = new Vector2(0, 0);
        }
        else
        {
            movespeed = 2f;
        }
        if (Mathf.Abs(leftjoystick.position.x) > 0)
        {
            //Rigidbody2D myrigi = GetComponent<Rigidbody2D>();
            myrigi.velocity = new Vector2(leftjoystick.position.x * movespeed, myrigi.velocity.y);
        }
        if (Mathf.Abs(leftjoystick.position.y) > 0)
        {
            //Rigidbody2D myrigi = GetComponent<Rigidbody2D>();
            myrigi.velocity = new Vector2(myrigi.velocity.x, leftjoystick.position.y * movespeed);
        }
        Vector3 dir = rightjoystick.position;
        if (dir != Vector3.zero)
        {
            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            this.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
        //float joyrotate = JoystickInput(rightjoystick);
        //this.transform.Rotate(0, 0, joyrotate * rotationspeed);
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Stone"|| other.tag=="TinyStone")
        {
            currenthealth -= 50;
        }
    }
    private float GetCurrentXPos(float x, float inmin, float inmax, float outmin, float outmax)// Healthbar
    {
        return (x - inmin) * (outmax - outmin) / (inmax - inmin) + outmin;
    }
    private void GetCurrentHealthbar()
    {
        float currentxpos = GetCurrentXPos(currenthealth, 0, maxhealth, minXvalue, maxXvalue);
        healthtransform.position = new Vector2(currentxpos, yAxis);
        if (currenthealth > maxhealth / 2)
        {
            visualimage.color = new Color32((byte)GetCurrentXPos(currenthealth, maxhealth / 2, maxhealth, 255, 0), 255, 0, 255);
        }
        else
        {
            visualimage.color = new Color32(255, (byte)GetCurrentXPos(currenthealth, 0, maxhealth / 2, 0, 255), 0, 255);
        }
    }
    //private float JoystickInput(Joystick joy)
    //{
    //    Vector2 absJoyPos = new Vector2(Mathf.Abs(joy.position.x),
    //                             Mathf.Abs(joy.position.y));
    //    int xDirection = (joy.position.x > 0) ? 1 : -1;
    //    int yDirection = (joy.position.y > 0) ? 1 : -1;
    //    return ((absJoyPos.x > absJoyPos.y) ? absJoyPos.x * xDirection : absJoyPos.y * yDirection);
    //}
}
