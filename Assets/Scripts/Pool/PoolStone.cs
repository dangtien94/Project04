using UnityEngine;
using System.Collections;

public class PoolStone : MonoBehaviour 
{
    private ObjectsPool objectpool;
	// Use this for initialization
    void Start()
    {
        objectpool = GameObject.FindGameObjectWithTag("StonesPool").GetComponent<ObjectsPool>();
        InvokeRepeating("Spawn", 0.5f, 0.5f);
    }
    private void Spawn()
    {
        GameObject obj = objectpool.Spawn();
        if (obj == null)
        {
            return;
        }
        obj.transform.position = new Vector3(17.38f, (float)Random.Range(-8.65f, 8.65f), 0f);
        obj.transform.rotation = this.transform.rotation;
        obj.SetActive(true);
    }
}
