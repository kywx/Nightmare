using UnityEngine;
using System.Collections;
using System;

public class SqurrielHealth : MonoBehaviour
{
    public static event Action SquDeath;

    public void Health(float total)
    {
        if (total == 0)
        {
            Debug.Log("You die");
            SquDeath?.Invoke();
        }
    }
    
}
