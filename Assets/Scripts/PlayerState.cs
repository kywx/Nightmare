using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerState : MonoBehaviour
{
    // private Rigidbody2D rb; just in case we want to add this
    private Animator anim;
    [SerializeField] private AudioSource againq;

    void Start()
    {
        // get this gameobjects components
        anim = GetComponent<Animator>();
        // rb = GetComponent<Rigidbody2D>(); just in case we want to add this
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
           
            // rb.bodyType = RigidbodyType2D.Static; probably don't need this
            // the animation has the restartlevel() so no need to call it here
            anim.SetTrigger("death");
            againq.Play();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Respawn"))
        {
            
            // the animation has the restart level function so no need to call it herr
            anim.SetTrigger("death");
            againq.Play();
        }
    }

    private void RestartLevel()
    {
        // reloads the current scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
