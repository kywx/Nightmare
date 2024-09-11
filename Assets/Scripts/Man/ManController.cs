using System.Collections;
using System.Collections.Generic;
//using Unity.PlasticSCM.Editor.WebApi;
using UnityEngine;

public class ManController : PlayerController
{

    [SerializeField]
    private MansCollectibles mc;
    [SerializeField]
    private LayerMask jumpableGround;
    [SerializeField]
    private float jumpForce = 5f;
    [SerializeField]
    private float mini_jumpForce = 2.5f;
    [SerializeField]
    private float big_jumpForce = 8f;
    [SerializeField]
    private float horForce = 5f;
    [SerializeField]
    private float big_horForce = 7f;


    [SerializeField] private AudioSource jumpSound;
    
    // Update is called once per frame
    void Update()
    {
        // get the size of the character
        int currentSize = mc.get_Size();
        // get the direction of the player
        float hor = Input.GetAxisRaw("Horizontal");

        // as long as dude is not dead, do this
        if (!GetComponent<HoleCollision>().isDead)
        {
            // if player is big, he moves forward more
            float m_horForce = horForce;
            if (currentSize == 2)
            {
                m_horForce = big_horForce;
            }
            rb.velocity = new Vector2(hor * m_horForce, rb.velocity.y);

            if (Input.GetButtonDown("Jump") && IsGrounded(jumpableGround))
            {
                jumpSound.Play();
                // checks what size, get jumpforce accordingly
                float jump = jumpForce;
                if (currentSize == 0)
                {
                    jump = mini_jumpForce;
                }
                else if (currentSize == 2)
                {
                    jump = big_jumpForce;
                }

                rb.velocity = new Vector2(rb.velocity.x, jump);
            }

        } else
        {
            rb.velocity = new Vector2(0, rb.position.y);
        }

        // sets animation state
        // flips sprite to face the correct way
        spriteFlipping(hor);

        // if rb.velocity.y > 0.1f = jumping animation
        // if rb.velocity.y < -0.1f = falling animation
        // drawing is hard, maybe not

    }
}