using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractiveElevatingObject : MonoBehaviour
{
    // Elevator Specification
    public float[] destinationY;
    public float speed;

    // Inner Active
    int destFloor;
    AudioSource sound;

    // Component References
    public AudioClip soundEffect;

    // Start is called before the first frame update
    void Start()
    {
        destFloor = 0;
        sound = this.transform.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    public void SelectDestPos(int dest)
    {
        if (0 <= dest && dest < destinationY.Length)
        {
            destFloor = dest;

            if (sound != null && soundEffect != null)
            {
                sound.PlayOneShot(soundEffect);
            }
        }
    }

    void Move()
    {
        if (transform.position.y < destinationY[destFloor])
        {
            transform.Translate(Vector3.up * speed * Time.deltaTime);

            if (transform.position.y > destinationY[destFloor])
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
