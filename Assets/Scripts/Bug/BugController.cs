using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BugController : PlayerController
{
    [SerializeField]
    private LayerMask jumpableGround;
    [SerializeField]
    private float jumpForce = 7f;
    [SerializeField]
    private float horForce = 5f;

    private float longJumpForce = 0f;
    [SerializeField] private AudioSource jumph;

    // Update is called once per frame
    void Update()
    {
        // gets the direction of player movement
        float hor = Input.GetAxisRaw("Horizontal");

        // if player doesn't hold, then no need to make the rigidbody static
        if (longJumpForce <= 0.2f)
        {
            rb.velocity = new Vector2(hor * horForce, rb.velocity.y);
        }

        // adds to the longJumpForce if holding space and is on the ground
        // makes body static so you can't move while preparing to jump
        if (Input.GetButton("Jump") && IsGrounded(jumpableGround))
        {
            jumph.Play();
            if (longJumpForce > 0.2f)
            {
                rb.bodyType = RigidbodyType2D.Static;
            }
            longJumpForce += Time.deltaTime * 1.8f;
            if (longJumpForce > 3)
            {
                longJumpForce = 3;
            }
        }

        // when you let go of the jump button and are on the ground
        // turns body back to dynamic
        // reset longjumpforce
        if (Input.GetButtonUp("Jump") && IsGrounded(jumpableGround))
        {
            rb.bodyType = RigidbodyType2D.Dynamic;
            rb.velocity = new Vector2(rb.velocity.x + (longJumpForce / 2), jumpForce + longJumpForce);
            longJumpForce = 0f;
        }


        // make sure the character is facing the correct direction
        // also the running animation
        spriteFlipping(hor);

    }
}
