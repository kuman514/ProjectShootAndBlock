using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeDetonation : MonoBehaviour
{
    // Detonation Specification
    public float secondsToDetonate;
    public float damageAtCenter;
    public float damageRange;
    public float knockbackAtCenter;

    // Inner Active
    private GameObject objectToDetonate;
    private AudioSource grenadeAudio;

    // Component Reference
    public GameObject detonationEffect;
    public AudioClip detonationSE;
    public AudioClip collisionSE;

    // Start is called before the first frame update
    void Start()
    {
        objectToDetonate = this.transform.gameObject;
        grenadeAudio = transform.GetComponent<AudioSource>();
        Debug.Log(objectToDetonate.name);
    }

    // Update is called once per frame
    void Update()
    {
        ReduceLifeSpan();
    }

    void ReduceLifeSpan()
    {
        secondsToDetonate -= Time.deltaTime;

        if(secondsToDetonate <= 0)
        {
            Explode();
        }
    }

    void Explode()
    {
        if (grenadeAudio != null && detonationSE != null)
        {
            grenadeAudio.PlayOneShot(detonationSE);
        }
        
        Destroy(objectToDetonate);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Enemy"))
        {
            Explode();
        }

        if (grenadeAudio != null && collisionSE != null)
        {
            grenadeAudio.PlayOneShot(collisionSE);
        }
    }
}
