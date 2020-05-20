using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SampleEnemyMovements : MonoBehaviour
{
    // Specification
    public float force;

    // Inner Active
    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        StartCoroutine(Move());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Move()
    {
        while(true)
        {
            float dir1 = Random.Range(0, 1f);
            float dir2 = Random.Range(-1f, 1f);
            float dirV = Random.Range(0, 3f);

            yield return new WaitForSeconds(1);
            rb.velocity = new Vector3(dir1, 0, dir2) * force;
        }
    }
}
