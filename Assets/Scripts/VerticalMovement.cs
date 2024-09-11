using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticalMovement : MonoBehaviour
{
    // vertical movement for the cranes
    [SerializeField]
    private float speed = 1f;
    [SerializeField]
    private float upBoundary = 2f;
    [SerializeField]
    private float downBoundary = -2f;
    [SerializeField]
    private float startingBound = 2f;

    void Update()
    {
        if (transform.position.y >= upBoundary)
        {
            // if its at or above the up bound, move down instead
            startingBound = downBoundary;
        }
        else if (transform.position.y <= downBoundary)
        {
            // if its at or below down bound, move up instead
            startingBound = upBoundary;
        }
        // moves the bird
        Vector2 target = new Vector2(transform.position.x, startingBound);
        transform.position = Vector2.MoveTowards(transform.position, target, Time.deltaTime * speed);
    }
}
