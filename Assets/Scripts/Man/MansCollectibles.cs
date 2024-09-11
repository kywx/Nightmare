using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MansCollectibles : MonoBehaviour
{
    // 0 = small, 1 = normal, 2 = big
    private int currentSize = 1;
    private Vector3 m_scale = new Vector3(0.5f, 0.5f, 0.5f);


    public int get_Size()
    {
        return currentSize;
    }

    [SerializeField] private AudioSource bigSound;
    [SerializeField] private AudioSource smallSound;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Collectible"))
        {
            // if apple, make bigger
            if (collision.gameObject.name == "Apple")
            {
                bigSound.Play();
                if (currentSize < 2)
                {
                    currentSize++;
                    transform.localScale += m_scale;
                }
                Destroy(collision.gameObject);
            }
            // if banana, make smaller
            else if (collision.gameObject.name == "Banana")
            {
                smallSound.Play();
                if (currentSize > 0)
                {
                    currentSize--;
                    transform.localScale -= m_scale;
                }
                Destroy(collision.gameObject);
            }

        }

        
        
    }

}
