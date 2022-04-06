using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class progress : MonoBehaviour
{
    // create a bool to see if this room has been counted in progress to prevent people from just walking in and out to get progress
    // establish connection with the managerofgame
    [SerializeField]
    private bool triggered = false;
    private GameObject manager;
    private void Start()
    {
        //locate the manager
        manager = GameObject.Find("managerofgame");
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        //if a player from team 1 enters up team 1's progress
        //if a player from team 2 enters up team 2's progress
        if (!triggered && other.CompareTag("Team1Player"))
        {
            manager.SendMessage("progress1");
            triggered = true;
        }
        else if (!triggered && other.CompareTag("Team2Player"))
        {
            manager.SendMessage("progress2");
            triggered = true;
        }
    }
}
