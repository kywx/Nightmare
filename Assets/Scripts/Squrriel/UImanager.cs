using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UImanager : MonoBehaviour
{
    public GameObject Gameover;

    private void OnEnable ()
    {
        SqurrielHealth.SquDeath += ShowRetry;

    }
    private void OnDisable()
    {
        SqurrielHealth.SquDeath -= ShowRetry;
    }
    public void ShowRetry()
    {
        Gameover.SetActive(true);
    }
}
