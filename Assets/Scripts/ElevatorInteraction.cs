using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorInteraction : MonoBehaviour
{
    // Inner Active
    float timer;
    int cur;

    // Component References
    public ElevatorMethod elevator;

    // Start is called before the first frame update
    void Start()
    {
        timer = 0;
        cur = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if(timer >= 10)
        {
            cur++;
            elevator.SelectDestFloor(cur % 2);
            timer = 0;
        }

        timer += Time.deltaTime;
    }
}
