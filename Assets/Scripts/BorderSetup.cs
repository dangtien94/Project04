using UnityEngine;
using System.Collections;

public class BorderSetup : MonoBehaviour
{
    public Camera maincamera;
    public BoxCollider2D topborder;
    public BoxCollider2D bottomborder;
    public BoxCollider2D leftborder;
    public BoxCollider2D rightborder;
    void Start()
    {
        // Move the wall to edge location
        topborder.size = new Vector2(maincamera.ScreenToWorldPoint(new Vector3(Screen.width * 2f, 0f, 0f)).x, 1f);
        topborder.offset = new Vector2(0f, maincamera.ScreenToWorldPoint(new Vector3(0f, Screen.height, 0f)).y + 0.5f);

        bottomborder.size = new Vector2(maincamera.ScreenToWorldPoint(new Vector3(Screen.width * 2f, 0f, 0f)).x, 1f);
        bottomborder.offset = new Vector2(0f, maincamera.ScreenToWorldPoint(new Vector3(0f, 0f, 0f)).y - 0.5f);

        leftborder.size = new Vector2(1f, maincamera.ScreenToWorldPoint(new Vector3(0f, Screen.height * 2f, 0f)).y);
        leftborder.offset = new Vector2(maincamera.ScreenToWorldPoint(new Vector3(0f, 0f, 0f)).x - 0.5f, 0f);

        rightborder.size = new Vector2(1f, maincamera.ScreenToWorldPoint(new Vector3(0f, Screen.height * 2f, 0f)).y);
        rightborder.offset = new Vector2(maincamera.ScreenToWorldPoint(new Vector3(Screen.width, 0f, 0f)).x + 0.5f, 0f);
    }
}
