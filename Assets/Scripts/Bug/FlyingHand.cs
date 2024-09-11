using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingHand : MonoBehaviour
{
    private Rigidbody2D rb;

    [SerializeField]
    private float upForce = 3f;


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2 (0, upForce);
    }
 
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // when it flies past the camera view, it will destory itself
        // theres an invisible box collider above the scene tagged 'Destroy'
        if (collision.gameObject.CompareTag("Destroy"))
        {
            Destroy(gameObject);
        }
    }
}
