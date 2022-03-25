using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class managerofgame : MonoBehaviour
{
    public static int progressScore = 0;
    [SerializeField]
    private GameObject moveBarAlong;
    private Vector3 placement;
    private Vector3 timerPlacement;
    private bool done1 = true;
    private bool done2 = true;
    private bool done3 = true;
    private bool done4 = true;
    private bool done5 = true;
    private bool done6 = true;
    private bool done7 = true;
    private bool done8 = true;
    private bool done9 = true;
    private bool done10 = true;

    private void Start()
    {
        StartCoroutine(timer());
    }
    private void Update()
    {
        if (progressScore == 1 && done1 == true)
        {
            placement = new Vector3(0, 16, 0);
            Instantiate(moveBarAlong, placement, moveBarAlong.transform.rotation);
            done1 = false;
        }

        if (progressScore == 2 && done2 == true)
        {
            placement = new Vector3(1, 16, 0);
            Instantiate(moveBarAlong, placement, moveBarAlong.transform.rotation);
            done2 = false;
        }

        if (progressScore == 3 && done3 == true)
        {
            placement = new Vector3(2, 16, 0);
            Instantiate(moveBarAlong, placement, moveBarAlong.transform.rotation);
            done3 = false;
        }

        if (progressScore == 4 && done4 == true)
        {
            placement = new Vector3(3, 16, 0);
            Instantiate(moveBarAlong, placement, moveBarAlong.transform.rotation);
            done4 = false;
        }
        if (progressScore == 5 && done5 == true)
        {
            placement = new Vector3(4, 16, 0);
            Instantiate(moveBarAlong, placement, moveBarAlong.transform.rotation);
            done5 = false;
        }
        if (progressScore == 6 && done6 == true)
        {
            placement = new Vector3(5, 16, 0);
            Instantiate(moveBarAlong, placement, moveBarAlong.transform.rotation);
            done6 = false;
        }
        if (progressScore == 7 && done7 == true)
        {
            placement = new Vector3(6, 16, 0);
            Instantiate(moveBarAlong, placement, moveBarAlong.transform.rotation);
            done7 = false;
        }
        if (progressScore == 8 && done8 == true)
        {
            placement = new Vector3(7, 16, 0);
            Instantiate(moveBarAlong, placement, moveBarAlong.transform.rotation);
            done8 = false;
        }
        if (progressScore == 9 && done9 == true)
        {
            placement = new Vector3(8, 16, 0);
            Instantiate(moveBarAlong, placement, moveBarAlong.transform.rotation);
            done9 = false;
        }
        if (progressScore == 10 && done10 == true)
        {
            placement = new Vector3(9, 16, 0);
            Instantiate(moveBarAlong, placement, moveBarAlong.transform.rotation);
            done10 = false;
        }
    }

    private IEnumerator timer()
    {
        for (int i = 0; i < 30; i++)
        {
            yield return new WaitForSeconds(10);
            timerPlacement = new Vector3(i - 15, 20, 0);
            Instantiate(moveBarAlong, timerPlacement, moveBarAlong.transform.rotation);
        }
    }
}
