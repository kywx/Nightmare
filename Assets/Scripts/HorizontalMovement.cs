using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorizontalMovement : MonoBehaviour
{
    // horizontal movement for the cranes
    [SerializeField]
    private float speed = 2f;
    [SerializeField]
    private float leftBoundary = -10f;
    [SerializeField]
    private float rightBoundary = 1000f;
    [SerializeField]
    private float startingBound = -10f;

    private SpriteRenderer sprite;

    private void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
    }


    private void Update()
    {
        if (transform.position.x <= leftBoundary)
        {
            // if the bird is at the left boundary, set it to move to the right
            startingBound = rightBoundary;
            // changes the way that the crane is facing
            sprite.flipX = true;
        }
        else if (transform.position.x >= rightBoundary)
        {
            // if bird is at right boundry, set to move bird to the left
            startingBound = leftBoundary;
            // changes the way that the crane is facing
            sprite.flipX = false;
        }
        // move bird
        Vector2 target = new Vector2(startingBound, transform.position.y);
        transform.position = Vector2.MoveTowards(transform.position, target, Time.deltaTime * speed);
    }
}
