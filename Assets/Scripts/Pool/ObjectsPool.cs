using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ObjectsPool : MonoBehaviour 
{
    public GameObject gameobject;
    public int size;
    public bool willgrow = true;
    private List<GameObject> list;
    // Use this for initialization
    void Start()
    {
        list = new List<GameObject>();
        for (int i = 0; i < size; i++)
        {
            GameObject obj = (GameObject)Instantiate(gameobject);
            obj.SetActive(false);
            list.Add(obj);
        }
    }
    public GameObject Spawn()
    {
        for (int i = 0; i < list.Count; i++)
        {
            if (!list[i].activeInHierarchy)
            {
                return list[i].gameObject;
            }
        }
        if (willgrow)
        {
            GameObject obj = (GameObject)Instantiate(gameobject);
            list.Add(obj);
            return obj;
        }
        return null;
    }
}
