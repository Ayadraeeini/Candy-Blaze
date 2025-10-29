// [Author: Eyad Al Raeeini]
// Player Movement //
// Date: 09/30/2025 //
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement Settings")]
    public float moveSpeed = 5f;
    [Header("Jump Settings")]
    public float jumpForce = 5f;
    private Rigidbody rb;
    private bool isGrounded;
    private bool canDoubleJump = false;
    public float doubleJumpForce = 4f;
    private bool hasDoubleJumped = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true; // more stable than the inspector tool for some reason. don't change
    }

    void Update()
    {
        float moveX = Input.GetAxis("Horizontal");
       float moveZ = Input.GetAxis("Vertical");
       Vector3 move = transform.right * moveX + transform.forward * moveZ;
       move *= moveSpeed;
        Vector3 newVel = new Vector3(move.x, rb.velocity.y, move.z);
        rb.velocity = newVel;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isGrounded) {
                 Jump(jumpForce);
                hasDoubleJumped = false;
            }
            else if (canDoubleJump && !hasDoubleJumped)
            {
                Jump(doubleJumpForce);

                hasDoubleJumped = true;
            }
        }
    }

    private void Jump(float force)
    {
          rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);
         rb.AddForce(Vector3.up * force, ForceMode.Impulse);
         isGrounded = false;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.contacts[0].normal.y > 0.5f){
            isGrounded = true;
        }
    }

    public void UnlockDoubleJump()
    {
        canDoubleJump = true;
         UIManager ui = FindObjectOfType<UIManager>();
        if (ui != null)
        {
         ui.ShowDoubleJumpMessage();
        }
    }
    }

