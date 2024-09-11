using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoleCollision : MonoBehaviour
{
    private BoxCollider2D boxColl;
    private Rigidbody2D rb;
    public bool isDead = false;
    [SerializeField] private AudioSource fall;

    private void Start()
    {
        boxColl = GetComponent<BoxCollider2D>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // turn the player into a trigger so he "falls" down the hole
        if (collision.gameObject.CompareTag("Obstacle") && collision.gameObject.name == "Hole")
        {
            fall.Play();
            boxColl.isTrigger = true;
            isDead = true;
        }
    }

}
