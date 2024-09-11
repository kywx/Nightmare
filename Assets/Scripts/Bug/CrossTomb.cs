using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrossTomb : MonoBehaviour
{
    private BoxCollider2D boxColl;

    [SerializeField]
    private GameObject Hands_Prefab;


    // Start is called before the first frame update
    void Start()
    {
        boxColl = GetComponent<BoxCollider2D>();        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // if the player gets in range, turn on the hands
        // also delete this collider
        if (collision.gameObject.CompareTag("Player"))
        {
            boxColl.enabled = false;
            Hands_Prefab.SetActive(true);
        }
    }
}
