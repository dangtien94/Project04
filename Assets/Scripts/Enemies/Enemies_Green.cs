using UnityEngine;
using System.Collections;

public class Enemies_Green : MonoBehaviour 
{
    private Vector3 dir;
    float angle;
    public Transform player;
    public float speed;// Enemy move speed
    //public float timedelay;// lifetime of Enemy
	// Use this for initialization
	void Start ()
    {
        GameObject pl = (GameObject)GameObject.FindGameObjectWithTag("Player");
        player = pl.transform;
        //Invoke("DestroyEnemies", timedelay);
	}
    //private void DestroyEnemies()
    //{
    //    Destroy(this.gameObject);
    //}
    void Update()
    {
        if (this.gameObject != null)
        {
            dir = player.position - this.transform.position;
            angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle * 1.57f, Vector3.forward);
            this.transform.Rotate(new Vector3(0, 0, -90), Space.Self);
            this.transform.position = Vector2.MoveTowards(this.transform.position, player.position, speed * Time.deltaTime);
        }
    }
}
