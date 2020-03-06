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
    private bool jumpable;
    private float horizontal;
    private float vertical;
    private float originalMoveSpeed;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        jumpable = false;
        horizontal = 0;
        vertical = 0;
        originalMoveSpeed = movementSpeed;
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
        vertical = 0;
        horizontal = 0;

        if (Input.GetKey(InputManager.Forward))
        {
            vertical = 1;
        }

        if (Input.GetKey(InputManager.Backward))
        {
            vertical = -1;
        }

        if (Input.GetKey(InputManager.Left))
        {
            horizontal = -1;
        }

        if (Input.GetKey(InputManager.Right))
        {
            horizontal = 1;
        }

        transform.Translate(new Vector3(horizontal, 0, vertical) * movementSpeed * Time.deltaTime);
    }

    void Jump()
    {
        if(jumpable && Input.GetKeyDown(InputManager.Jump))
        {
            rb.AddForce(0, jumpForce, 0);
        }
    }

    void Sprint()
    {
        if(Input.GetKey(InputManager.Sprint))
        {
            movementSpeed = originalMoveSpeed * SprintMult;
        }
        else
        {
            movementSpeed = originalMoveSpeed;
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
