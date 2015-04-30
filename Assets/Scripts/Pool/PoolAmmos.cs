using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PoolAmmos : MonoBehaviour
{
    private ObjectsPool objectpool;
	// Use this for initialization
	void Start ()
    {
        objectpool = GameObject.FindGameObjectWithTag("AmmoPool").GetComponent<ObjectsPool>();
        InvokeRepeating("Spawn", 0.15f, 0.15f);
	}
    private void Spawn()
    {
        GameObject obj = objectpool.Spawn();
        if (obj == null)
        {
            return;
        }
        obj.transform.position = this.transform.position;
        obj.transform.rotation = this.transform.rotation;
        obj.SetActive(true);
    }
}
