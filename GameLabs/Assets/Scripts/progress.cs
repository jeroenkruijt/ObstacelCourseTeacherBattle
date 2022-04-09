using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class progress : MonoBehaviour
{
    // create a bool to see if this room has been counted in progress to prevent people from just walking in and out to get progress
    // establish connection with the managerofgame
    [SerializeField]
    private bool triggered = false;
    private void OnTriggerEnter2D(Collider2D other)
    {
        //if a player from team 1 enters up team 1's progress
        //if a player from team 2 enters up team 2's progress
        if (!triggered && other.CompareTag("Player"))
        {
            other.SendMessage("progress");
            triggered = true;
        }
    }
}
