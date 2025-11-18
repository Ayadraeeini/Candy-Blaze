//[Aurthor:Eyad Al Raeeini]
//player movement with dash and wall phase\
// [11/13/2025]
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 5f;
    public bool canDoubleJump = false;
    public float doubleJumpForce = 4f;
    private bool hasDoubleJumped = false;
    public float dashForce = 10f;
    public float dashDuration = 0.2f;
    public float dashCooldown = 1f;
    private bool isDashing = false;
    private float dashTimer = 0f;
    public float boostMultiplier = 1.5f;
    public float boostDuration = 5f;
    private bool isBoosted = false;
    private float boostTimer = 0f;
    private Rigidbody rb;
    private bool isGrounded;
    private DashUI dashUI;
    



    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true; // keeps it from spinning weird
        dashUI = FindObjectOfType<DashUI>();
    }

    void Update()
    {
        if (!isDashing)
        {
            float moveX = Input.GetAxis("Horizontal");
            float moveZ = Input.GetAxis("Vertical");
            Vector3 move = transform.right * moveX + transform.forward * moveZ;
           move *= moveSpeed;
            Vector3 newVel = new Vector3(move.x, rb.velocity.y, move.z);
            rb.velocity = newVel;

            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (isGrounded)
                {
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

        if (dashTimer > 0f)
        {
            dashTimer -= Time.deltaTime;
            if (dashUI != null)
                dashUI.UpdateDashUI(dashCooldown, dashTimer);
        }

        if (Input.GetKeyDown(KeyCode.LeftShift) && dashTimer <= 0f)
        {
           StartCoroutine(Dash());
        }

        if (isBoosted)
        {
            boostTimer -= Time.deltaTime;

            if (boostTimer <= 0f)
            {
               EndSpeedBoost();
            }
        }
    }

    void Jump(float force)
    {
        rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);
       rb.AddForce(Vector3.up * force, ForceMode.Impulse);
        isGrounded = false;
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.contacts[0].normal.y > 0.5f)
        {
           isGrounded = true;
        }
    }

    IEnumerator Dash()
    {
        isDashing = true;
        dashTimer = dashCooldown;
        Vector3 dashDirection = transform.forward;
         rb.velocity = Vector3.zero;
         Physics.IgnoreLayerCollision(gameObject.layer, LayerMask.NameToLayer("PhaseWall"), true);

        rb.AddForce(dashDirection * dashForce, ForceMode.Impulse);
        yield return new WaitForSeconds(dashDuration);
        Physics.IgnoreLayerCollision(gameObject.layer, LayerMask.NameToLayer("PhaseWall"), false);

        isDashing = false;
    }

    public void ActivateSpeedBoost(float duration, float multiplier)
    {
        if (!isBoosted)
        {
            isBoosted = true;
           boostTimer = duration;
            moveSpeed *= multiplier;
            SpeedUI ui = FindObjectOfType<SpeedUI>();
            if (ui != null)
            {
                ui.StartBoostTimer(duration);
            }
        }
    }

    void EndSpeedBoost()
    {
        isBoosted = false;
         moveSpeed /= boostMultiplier;
        SpeedUI ui = FindObjectOfType<SpeedUI>();
        if (ui != null)
        {
            ui.HideBoostTimer();
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