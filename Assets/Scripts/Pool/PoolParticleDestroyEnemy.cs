using UnityEngine;
using System.Collections;

public class PoolParticleDestroyEnemy : MonoBehaviour 
{
    private ObjectsPool objectpool;
	// Use this for initialization
    void Start()
    {
        objectpool = GameObject.FindGameObjectWithTag("ParticleSTPool").GetComponent<ObjectsPool>();
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Spawn();
            this.gameObject.SetActive(false);
        }
        if (other.tag == "Ammo")
        {
            Spawn();
            this.gameObject.SetActive(false);
            VictoryScoreManager.victoryscore -= 10;
            ScoreManager.curentscore += 10;
        }
    }
    private void Spawn()
    {
        GameObject obj = objectpool.Spawn();
        if (obj == null)
        {
            return;
        }
        obj.transform.position = this.transform.position;
        obj.transform.rotation = Quaternion.identity;
        obj.SetActive(true);
        obj.GetComponent<ParticleSystem>().Play();
        obj.GetComponent<AudioSource>().Play();
    }
}
