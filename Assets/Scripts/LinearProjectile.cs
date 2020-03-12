using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinearProjectile : MonoBehaviour
{
    // Projectile Specification
    public float speed;
    public float damage;
    public float knockback;

    // Inner Active
    // None yet

    // Component Reference
    public GameObject ObjectToDestroy;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision col)
    {
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
}
