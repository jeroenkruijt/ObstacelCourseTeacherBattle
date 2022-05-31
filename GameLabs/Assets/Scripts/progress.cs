using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class progress : MonoBehaviour
{
    // create a bool to see if this room has been counted in progress to prevent people from just walking in and out to get progress
    // establish connection with the managerofgame
    [SerializeField]
    private bool triggered = false;
    public int camSize;
    [SerializeField]
    private GameObject roomMiddle;
    public Vector3 camLocation;

    private void Start()
    {
        camLocation = roomMiddle.transform.position;
        camLocation.z = -15;/* = new Vector3(camLocation.x, camLocation.y, -15);*/
    }
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
