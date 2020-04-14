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

    // Component Reference
    public GameObject detonationEffect;
    public AudioClip detonationSound;
    public AudioSource detonationSpeaker;

    // Start is called before the first frame update
    void Start()
    {
        objectToDetonate = this.transform.gameObject;
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
        Destroy(objectToDetonate);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Enemy"))
        {
            Explode();
        }
    }
}
