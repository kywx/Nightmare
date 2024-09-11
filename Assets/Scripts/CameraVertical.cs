using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraVertical : MonoBehaviour
{
    [SerializeField]
    private Transform player;

    private void Update()
    {
        // camera follows the player vertically
        if (player.position.y <= 0f)
        {
            transform.position = new Vector3(transform.position.x, 0, transform.position.z);
        }
        else
        {
            transform.position = new Vector3(transform.position.x, player.position.y, transform.position.z);
        }
    }
}
