using UnityEngine;
using System.Collections;

public class ParticleDestroyEnemy : MonoBehaviour 
{
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
}
