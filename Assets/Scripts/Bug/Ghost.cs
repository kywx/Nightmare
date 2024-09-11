using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Ghost : MonoBehaviour
{
    private Rigidbody2D rb;
    private BoxCollider2D boxColl;
    private SpriteRenderer sprite;
    private CircleCollider2D circleColl;

    [SerializeField]
    private float horSpeed = 3f;
    [SerializeField]
    private float descentSpeed = 3f;
    [SerializeField]
    private float dir = -1;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        boxColl = GetComponent<BoxCollider2D>();
        sprite = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        // if the ghost is close to the ground, then disappear
        if (transform.position.y <= -3.5f)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // when the player is in range, fly diagonally towards the ground
        if (collision.gameObject.CompareTag("Player"))
        {
            rb.velocity = new Vector2(dir * horSpeed, -1 * descentSpeed);
            circleColl.enabled = false;
        }
    } 
}
