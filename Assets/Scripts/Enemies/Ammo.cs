using UnityEngine;
using System.Collections;

public class Ammo : MonoBehaviour 
{
    Rigidbody2D myrigi;
    public float speed;
	// Use this for initialization
    void Start()
    {
        myrigi = GetComponent<Rigidbody2D>();
    }
    void FixedUpdate()
    {
        myrigi.velocity = this.transform.up.normalized * speed;
    }
    void OnEnable()
    {
        Invoke("Destroy", 2f);
    }
    private void Destroy()
    {
        this.gameObject.SetActive(false);
    }
    void OnDisable()
    {
        CancelInvoke();
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Stone")
        {
            this.gameObject.SetActive(false);
        }
    }
}
