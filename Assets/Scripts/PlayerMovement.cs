using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Player Specification
    public float movementSpeed;
    public float jumpForce;
    public float SprintMult;

    // Inner Active
    private Rigidbody rb;
    private CharacterController cc;
    private bool jumpable;
    private float horizontal;
    private float vertical;
    private float originalMoveSpeed;
    private bool moving;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        cc = GetComponent<CharacterController>();
        jumpable = false;
        horizontal = 0;
        vertical = 0;
        originalMoveSpeed = movementSpeed;
        moving = false;
    }

    // Update is called once per frame
    void Update()
    {
        Sprint();
        GroundMovement();
        Jump();
    }

    void GroundMovement()
    {
        moving = false;
        vertical = 0;
        horizontal = 0;

        if (Input.GetKey(InputManager.Forward))
        {
            vertical = 1;
            moving = true;
        }

        if (Input.GetKey(InputManager.Backward))
        {
            vertical = -1;
            moving = true;
        }

        if (Input.GetKey(InputManager.Left))
        {
            horizontal = -1;
            moving = true;
        }

        if (Input.GetKey(InputManager.Right))
        {
            horizontal = 1;
            moving = true;
        }

        if(moving)
        {
            //transform.Translate(new Vector3(horizontal, 0, vertical) / Mathf.Sqrt(Mathf.Pow(vertical, 2) + Mathf.Pow(horizontal, 2)) * movementSpeed * Time.deltaTime);
            cc.Move(new Vector3(horizontal, 0, vertical) / Mathf.Sqrt(Mathf.Pow(vertical, 2) + Mathf.Pow(horizontal, 2)) * movementSpeed * Time.deltaTime);
        }
    }

    void Jump()
    {
        if(jumpable && Input.GetKeyDown(InputManager.Jump))
        {
            rb.AddForce(0, jumpForce, 0);
            jumpable = false;
        }
    }

    void Sprint()
    {
        if (SprintMult <= 1)
        {
            // If sprint key makes player slower
            if (Input.GetKey(InputManager.Sprint))
            {
                movementSpeed = originalMoveSpeed * SprintMult;
            }
            else
            {
                movementSpeed = originalMoveSpeed;
            }
        }
        else
        {
            // If sprint key makes player faster
            if (Input.GetKey(InputManager.Sprint) && Input.GetKey(InputManager.Forward))
            {
                movementSpeed = originalMoveSpeed * SprintMult;
            }
            else
            {
                movementSpeed = originalMoveSpeed;
            }
        }
    }

    private void OnCollisionEnter(Collision col)
    {
        // if the player is on the floor
        if(col.gameObject.CompareTag("Floor"))
        {
            jumpable = true;
        }
    }
}
