using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class progress : MonoBehaviour
{
    [SerializeField]
    private bool triggered = false;
    private GameObject manager;
    private void Start()
    {
        manager = GameObject.Find("managerofgame");
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && triggered == false)
        {
            manager.SendMessage("progress1");
            triggered = true;
        }
    }
}
