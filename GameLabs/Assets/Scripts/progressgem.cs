using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class progressgem : MonoBehaviour
{
    // get a vector to move the gem and a direction to start with
    private Vector3 targetPos;
    private bool direction = true;

    private void Start()
    {
        //set a timer
        StartCoroutine(time());
    }
    private void move()
    {
        //move the gem upwards then change the direction
        if (direction == true)
        {
            targetPos = transform.TransformPoint(0, 0.05f, 0);
            transform.position = Vector3.MoveTowards(transform.position, targetPos, 1);
            direction = false;
        }
        //move the gem downwards then change the direction
        else
        {
            targetPos = transform.TransformPoint(0, -0.05f, 0);
            transform.position = Vector3.MoveTowards(transform.position, targetPos, 1);
            direction = true;
        }
        
    }

    private IEnumerator time()
    {
        //wait a second then move the gem and call itself again
        yield return new WaitForSeconds(1);
        move();
        StartCoroutine(time());
    }
}
