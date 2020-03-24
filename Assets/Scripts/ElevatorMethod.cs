using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorMethod : MonoBehaviour
{
    // Elevator Specification
    public float[] destinationY;
    public float speed;

    // Inner Active
    int destFloor;

    // Start is called before the first frame update
    void Start()
    {
        destFloor = 0;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    public void SelectDestFloor(int dest)
    {
        if(0 <= dest && dest < destinationY.Length)
        {
            destFloor = dest;
        }
    }

    void Move()
    {
        if(transform.position.y < destinationY[destFloor])
        {
            transform.Translate(Vector3.up * speed * Time.deltaTime);

            if(transform.position.y > destinationY[destFloor])
            {
                transform.Translate(new Vector3(0, destinationY[destFloor] - transform.position.y, 0));
            }
        }

        if (transform.position.y > destinationY[destFloor])
        {
            transform.Translate(Vector3.down * speed * Time.deltaTime);

            if (transform.position.y < destinationY[destFloor])
            {
                transform.Translate(new Vector3(0, destinationY[destFloor] - transform.position.y, 0));
            }
        }
    }
}
