using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class SqurrielsCollectibles : MonoBehaviour
{
    [SerializeField]
    private Text pointSystemNameTextRef;
    [SerializeField]
    private string pointSystemName;
    [SerializeField]
    private bool hidden = false;
    [SerializeField]
    private int max_herbs = 0;

    private int slow = 0;
    private int acorns = 0;
    private int herbs = 0;
    private float total = 80;
    public int jumpBuffCount = 0;

    [SerializeField] private AudioSource obstcale;
    [SerializeField] private AudioSource booster;
    [SerializeField] private AudioSource acorn;
    [SerializeField] private AudioSource bird;


    private void Start()
    {
        if (hidden == true)
        {
            pointSystemNameTextRef.text = $"{pointSystemName}: " + herbs + " / " + max_herbs;
        } else
        {
            pointSystemNameTextRef.text = $"{pointSystemName}: " + total;
        }
    }

    // check if has jump boost
    public bool CanJump()
    {
        if (jumpBuffCount > 0)
        {
            return true;
        }
        return false;
    }

    public float get_total()
    {
        return total;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Collectible"))
        {
            acorn.Play();
            // when squrriel grabs acorn
            Destroy(collision.gameObject);
            if (hidden == true)
            {
                herbs++;
            }
            else
            {
                acorns++;
            }
        }
        else if (collision.gameObject.CompareTag("Obstacle"))
        {
            // when squrriel hits an obstacle
            slow++;
            obstcale.Play();
        }
        else if (collision.gameObject.CompareTag("JumpBuff"))
        { 
            // when squrriel collects a pogo stick
            Destroy(collision.gameObject);
            jumpBuffCount++;
            booster.Play();
        }
        else if (collision.gameObject.CompareTag("Enemy"))
        {
            bird.Play();
        }

        // calculates the total energy level of the squrriel
        if (hidden == false)
        {
            total = 80 - (slow * 10) + (acorns * 10);
            if (total >= 100)
            {
                total = 100f;
            }
            else if (total <= 0)
            {
                total = 0f;
                
            }
            pointSystemNameTextRef.text = $"{pointSystemName}: " + total;
        }
        else
        {
            pointSystemNameTextRef.text = $"{pointSystemName}: " + herbs + " / " + max_herbs;
        }
    }
 }


