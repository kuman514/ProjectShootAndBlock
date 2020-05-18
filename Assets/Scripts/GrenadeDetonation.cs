using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class GrenadeDetonation : MonoBehaviour
{
    // Detonation Specification
    public float secondsToDetonate;
    public float damageAtCenter;
    public float explodeRange;
    public float knockbackAtCenter;

    // Inner Active
    private GameObject objectToDetonate;

    // Component Reference
    public GameObject detonationEffect;
    public AudioClip detonationSE;
    public AudioClip collisionSE;

    // Start is called before the first frame update
    void Start()
    {
        objectToDetonate = this.transform.gameObject;
        StartCoroutine(ReduceLifeSpan());
    }

    // Update is called once per frame
    void Update()
    {
    }

    IEnumerator ReduceLifeSpan()
    {
        yield return new WaitForSeconds(secondsToDetonate);
        Explode();
    }

    void Explode()
    {
        if (detonationSE != null)
        {
            AudioSource.PlayClipAtPoint(detonationSE, this.transform.position);
        }

        Collider[] aroundObjs = Physics.OverlapSphere(this.transform.position, explodeRange);
        foreach (Collider subject in aroundObjs)
        {
            HealthManager subjectHealth = subject.transform.GetComponent<HealthManager>();
            if (subjectHealth != null)
            {
                float proximity = (this.transform.position - subject.transform.position).magnitude;
                float effect = 1 - (proximity / explodeRange);
                subjectHealth.Damage((int)(damageAtCenter * effect));
            }

            Rigidbody subjectRB = subject.transform.GetComponent<Rigidbody>();
            if (subjectRB != null)
            {
                subjectRB.AddExplosionForce(knockbackAtCenter, this.transform.position, explodeRange);
            }
        }
        
        Destroy(objectToDetonate);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Enemy"))
        {
            Explode();
        }

        if (collisionSE != null)
        {
            AudioSource.PlayClipAtPoint(collisionSE, this.transform.position);
        }
    }
}
