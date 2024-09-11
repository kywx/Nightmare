using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    private Transform player;

    private void Update()
    {
        // camera follows the player horizontally
        transform.position = new Vector3(player.position.x, transform.position.y, transform.position.z);
    }
}
