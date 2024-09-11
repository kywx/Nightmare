using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieController : MonoBehaviour
{
    private Rigidbody2D rb;
    private BoxCollider2D boxColl;
    private SpriteRenderer sprite;
    //private Animator anim;

    [SerializeField]
    public Transform Player;
    [SerializeField]
    private float horForce;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        boxColl = GetComponent<BoxCollider2D>();
        //anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        // get the player's location relative to self position
        // if the player is to my right, I will move to the right
        // if the player is to my left, I will move to the left
        float hor = 0;
        if (Player.position.x > transform.position.x)
        {
            hor = 1;
        }
        else if (Player.position.x < transform.position.x)
        {
            hor = -1;
        }
        rb.velocity = new Vector2(hor * horForce, rb.velocity.y);


        // make sure its facing the correct way
        if (hor > 0f)
        {
            sprite.flipX = true;
        }
        else if (hor < 0f)
        {
            sprite.flipX = false;
        }
    }
}
