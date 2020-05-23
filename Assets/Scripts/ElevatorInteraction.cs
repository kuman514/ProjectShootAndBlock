using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorInteraction : MonoBehaviour
{
    // Specification
    public float senseDistance;

    // Inner Active
    int cur;
    GameObject[] foundPlayers;

    // Component References
    public ElevatorMethod elevator;

    // Start is called before the first frame update
    void Start()
    {
        cur = 1;
    }

    // Update is called once per frame
    void Update()
    {
        GetPlayers();
        GetInteraction();
    }

    void GetInteraction()
    {
        foreach(GameObject p in foundPlayers)
        {
            float dist = Vector3.Distance(this.transform.position, p.transform.position);
            if(dist <= senseDistance)
            {
                if (Input.GetKeyDown(InputManager.Interact))
                {
                    cur++;
                    elevator.SelectDestFloor(cur % 2);
                }
            }
        }
    }

    void GetPlayers()
    {
        foundPlayers = GameObject.FindGameObjectsWithTag("Player");
    }
}
