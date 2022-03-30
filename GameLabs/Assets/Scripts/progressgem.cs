using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class progressgem : MonoBehaviour
{
    // Start is called before the first frame update
    private Vector3 targetPos;
    private bool direction = true;

    private void Start()
    {
        StartCoroutine(time());
    }
    private void move()
    {
        if (direction == true)
        {
            targetPos = transform.TransformPoint(0, 0.05f, 0);
            transform.position = Vector3.MoveTowards(transform.position, targetPos, 1);
            direction = false;
        }
        else
        {
            targetPos = transform.TransformPoint(0, -0.05f, 0);
            transform.position = Vector3.MoveTowards(transform.position, targetPos, 1);
            direction = true;
        }
        
    }

    private IEnumerator time()
    {
        yield return new WaitForSeconds(1);
        move();
        StartCoroutine(time());
    }
}
