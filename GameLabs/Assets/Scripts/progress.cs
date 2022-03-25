using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class progress : MonoBehaviour
{
    private bool triggered = false;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && triggered == false)
        {
            managerofgame.progressScore++;
            triggered = true;
            Debug.Log(managerofgame.progressScore);
        }
    }
}
