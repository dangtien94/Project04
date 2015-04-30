using UnityEngine;
using System.Collections;

public class FillCamera : MonoBehaviour 
{
    public Transform target;// Player possition
    public float smooth = 5f;
    private Vector3 offset;// Camera offset
    private Vector3 targetcamerapos;
    private float targetAspect;
	// Use this for initialization
    void Start()
    {
        offset = this.transform.position - target.position;
        targetAspect = 16.0f / 9.0f;
        float windowAspect = (float)Screen.width / (float)Screen.height;
        float scaleHeight = windowAspect / targetAspect;
        Camera camera = GetComponent<Camera>();

        if (scaleHeight < 1.0f)
        {
            camera.orthographicSize = camera.orthographicSize / scaleHeight;
        }
    }
    void FixedUpdate()
    {
        targetcamerapos = target.position + offset;
        this.transform.position = Vector3.Lerp(this.transform.position, targetcamerapos, smooth*Time.deltaTime);
    }
}
