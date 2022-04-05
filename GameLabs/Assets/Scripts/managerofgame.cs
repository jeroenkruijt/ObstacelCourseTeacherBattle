using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class managerofgame : MonoBehaviour
{
    [SerializeField]
    public int progressScore1 = 0;
    [SerializeField]
    private int progressScore2 = 0;
    [SerializeField]
    private GameObject ProgressBar1;
    private Vector3 placement;
    public float timeValue = 300;
    public Text timerText;
    private bool overtime = false;
    private int winningteam;
    private bool timerActive = true;
    private int suddenDeath1;
    private int suddenDeath2;
    [SerializeField]
    private GameObject spawn;

    private void Start()
    {
        spawn.SetActive(true);
    }
    void Update()
    {
        timer();
    }

    void timer()
    {
        if (timerActive == true)
        {
            if (timeValue > 0)
            {
                timeValue -= Time.deltaTime;
            }
            else if (progressScore1 == progressScore2 && overtime == false)
            {
                timeValue = 60;
                overtime = true;
                suddenDeath1 = progressScore1;
                suddenDeath2 = progressScore2;
            }
            else
            {
                gameEnd();
            }

            DisplayTime(timeValue);
        }
    }
    void DisplayTime(float timeToDisplay)
    {
        if (timeToDisplay < 0)
        {
            timeToDisplay = 0;
        }

        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        timerText.text = string.Format("{0:0}  {1:0 0}", minutes, seconds);

    }
    void progress1()
    {
        progressScore1++;
        float xcoord = (progressScore1 * 0.4f)-4f;
        placement = new Vector3(xcoord, 13, 0);
        Instantiate(ProgressBar1, placement, ProgressBar1.transform.rotation);
        Debug.Log(progressScore1);
        if (progressScore1 > suddenDeath1 && overtime)
        {
            gameEnd();
        }   
    }

    void gameEnd()
    {
        timeValue = 0;
        timerActive = false;
        if (progressScore1 > progressScore2)
        {
            winningteam = 1;
            Debug.Log("the winning team is team 1 !");
        }
        else if (progressScore2 > progressScore1)
        {
            winningteam = 2;
            Debug.Log("the winning team is team 2 !");
        }
        else
        {
            winningteam = 3;
            Debug.Log("It's a tie!");
        }
    }

}
