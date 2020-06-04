using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionButton : MonoBehaviour
{
    // Specification
    public float senseDistance;

    // Inner Active
    int cur;
    GameObject[] foundPlayers;
    AudioSource sound;

    // Component References
    public InteractiveElevatingObject objectToElevate;
    public AudioClip soundEffect;

    // Start is called before the first frame update
    void Start()
    {
        cur = 0;
        sound = this.transform.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        GetPlayers();
        GetInteraction();
    }

    void GetInteraction()
    {
        foreach (GameObject p in foundPlayers)
        {
            float dist = Vector3.Distance(this.transform.position, p.transform.position);
            if (dist <= senseDistance)
            {
                Interact();
            }
        }
    }

    void GetPlayers()
    {
        foundPlayers = GameObject.FindGameObjectsWithTag("Player");
    }

    void Interact()
    {
        if (Input.GetKeyDown(InputManager.Interact))
        {
            if(sound != null && soundEffect != null)
            {
                sound.PlayOneShot(soundEffect);
            }

            cur++;
            objectToElevate.SelectDestPos(cur % objectToElevate.destinationY.Length);
        }
    }
}
