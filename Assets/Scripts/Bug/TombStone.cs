using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TombStone : MonoBehaviour
{
    [SerializeField]
    private GameObject Zombie;
    [SerializeField]
    private float zombie_spawntime = 1;

    private BoxCollider2D boxColl;

    private void Start()
    {
        boxColl = GetComponent<BoxCollider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // if the player is in range, delete this box collider
        // spawn a zombie after a certain time
        if (collision.gameObject.CompareTag("Player"))
        {
            boxColl.enabled = false;
            IEnumerator Wait1Second()
            {
                yield return new WaitForSecondsRealtime(zombie_spawntime);
                GameObject zombie = Instantiate(Zombie, transform.position, Quaternion.identity);
                zombie.GetComponent<ZombieController>().Player = collision.GetComponent<Transform>();
            }

            StartCoroutine(Wait1Second());
        }
    }
}
