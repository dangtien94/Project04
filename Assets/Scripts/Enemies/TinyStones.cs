using UnityEngine;
using System.Collections;

public class TinyStones : MonoBehaviour {

    public float speed;// Stones speed
    private Rigidbody2D myrigi;
    // Use this for initialization
    void Start()
    {
        myrigi = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        myrigi.velocity = new Vector2(speed, 0);
    }
    void OnEnable()
    {
        Invoke("Destroy", 30f);
    }
    private void Destroy()
    {
        this.gameObject.SetActive(false);
    }
    void OnDisable()
    {
        CancelInvoke();
    }
}
