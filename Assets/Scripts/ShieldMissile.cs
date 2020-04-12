using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldMissile : MonoBehaviour
{
    // Missile Specification
    public float speed;
    public float damage;

    // Inner Active
    // None Yet

    // Component References
    public Transform target;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        TraceTarget();
        Forward();
    }

    void TraceTarget()
    {
        if(target != null)
        {
            transform.LookAt(target);
        }
    }

    void Forward()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.transform.CompareTag("Player"))
        {
            return;
        }

        HealthManager hitHP = collision.gameObject.transform.GetComponent<HealthManager>();
        if(hitHP != null)
        {
            hitHP.Damage(damage);
        }

        Destroy(this.transform.gameObject);
    }
}
