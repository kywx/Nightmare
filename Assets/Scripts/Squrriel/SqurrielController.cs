using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class SqurrielController : PlayerController
{
    [SerializeField]
    private SqurrielsCollectibles sc;
    [SerializeField]
    private LayerMask jumpableGround;
    [SerializeField]
    private float jumpForce = 7f;
    [SerializeField]
    private float more_jumpForce = 10f;
    [SerializeField]
    private float horForce = 5f;
    [SerializeField]
    private bool hidden = false;
    [SerializeField] private AudioSource jumpo;
    [SerializeField] private AudioSource jumph;

    // Update is called once per frame
    void Update()
    {
        // get player direction
        float hor = Input.GetAxisRaw("Horizontal");
        float new_horForce = horForce;
        // choose speed of the squrriel
        if (hidden == false)
        {
            float m_total = sc.get_total() / 10;

            if (m_total == 0)
            {
                new_horForce = 0.5f;
            }
            else if (m_total < 6)
            {
                new_horForce = 4f;
            }
            else if (m_total < 3)
            {
                new_horForce = 2f;
            }
        }

        rb.velocity = new Vector2(hor * new_horForce, rb.velocity.y);
        
        // only jump if grounded
        if (Input.GetButtonDown("Jump") && IsGrounded(jumpableGround))
        {
            float jump = jumpForce;
            // check if squrriel has a jump boost
            if (sc.CanJump())
            {
                jumph.Play();
                jump = more_jumpForce;
                sc.jumpBuffCount--;
            }
            jumpo.Play();
            rb.velocity = new Vector2(rb.velocity.x, jump);
        }

        // set animation and sprite
        spriteFlipping(hor);

        // if rb.velocity.y > 0.1f = jumping animation
        // if rb.velocity.y < -0.1f = falling animation

    }
}