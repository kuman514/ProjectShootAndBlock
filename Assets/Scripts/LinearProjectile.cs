using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinearProjectile : MonoBehaviour
{
    // Projectile Specification
    public float speed;
    public float damage;
    public float knockback;
    public float lifeSpan;

    // Inner Active
    private GameObject ObjectToDestroy;

    // Component Reference
    // None yet

    // Start is called before the first frame update
    void Start()
    {
        ObjectToDestroy = this.transform.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
        reduceLifeSpan();
    }

    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.transform.CompareTag("Projectile"))
        {
            return;
        }

        HealthManager hitObjHP = col.gameObject.transform.GetComponent<HealthManager>();
        if (hitObjHP != null)
        {
            hitObjHP.Damage(damage);
        }

        Rigidbody rigidbody = col.gameObject.transform.GetComponent<Rigidbody>();
        if (rigidbody != null)
        {
            rigidbody.AddForceAtPosition(transform.forward * (5f) * knockback, transform.position);
        }

        if(col != null)
        {
            Destroy(ObjectToDestroy);
        }
    }

    void reduceLifeSpan()
    {
        lifeSpan -= Time.deltaTime;
        if(lifeSpan <= 0)
        {
            Destroy(ObjectToDestroy);
        }
    }
}
