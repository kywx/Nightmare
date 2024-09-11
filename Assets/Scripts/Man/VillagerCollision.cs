using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VillagerCollision : MonoBehaviour
{
    [SerializeField]
    private MansCollectibles mc;

    private Animator anim;
    private int currentSize;
    

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    [SerializeField] private AudioSource die;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            currentSize = mc.get_Size();
            // if the player is small, villagers cannot see, thus cannot kill player
            if (currentSize == 0)
            {
                collision.gameObject.GetComponent<BoxCollider2D>().isTrigger = true;
            }
            // if player is not small, then player dies
            else
            {
                die.Play();
                anim.SetTrigger("death");
                
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            currentSize = mc.get_Size();
            // this is after the villager became a trigger
            // if the character became bigger, then turn on box collider and kill player
            // if the character is still small, nothing changes
            if (currentSize > 0)
            {
                die.Play();
                collision.gameObject.GetComponent<BoxCollider2D>().isTrigger = false;
                anim.SetTrigger("death");
                
            }
        }
    }

    private void RestartLevel()
    {
        // restarts the level
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1.0f;
    }

}
