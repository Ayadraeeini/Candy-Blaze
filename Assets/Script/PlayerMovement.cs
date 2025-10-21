// [Author: Eyad Al Raeeini]
// Player Movement //
// Date: 09/30/2025 //

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    private Rigidbody rb;
    private bool isGrounded;
    public float jumpForce = 5f;

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
         if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.contacts[0].normal.y > 0.5f)
        {
            isGrounded = true;
        }
    }
}
