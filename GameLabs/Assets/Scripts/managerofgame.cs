using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Scripts
{
    public class managerofgame : MonoBehaviour
{
    
    //create: two ints to keep track of progress, two blocks to use as a progress bar, a vector to place them accordingly, the time in seconds, a text block to display the time, a bool to initiate overtime
    //an int that holds the number of the winning team, a bool to turn off the timer, an int that keeps track of the amount of rooms in play, an int that tells the roomgenerators what room to load
    //an array of said rooms, a list of the spawnpoints so they can be targeted, a list of past seeds to avoid and a bool to disable the seed checker if the seed is unuseable
    [SerializeField]
    public int progressScore1 = 0;
    //[SerializeField]
    //private int progressScore2 = 0;
    public float timeValue = 0;
    public Text timerText;
    private bool overtime = false;
    private int winningteam;
    private bool timerActive = true;
    public int currentRooms;
    public int seed;
    public int readyTeams;
    public GameObject[] Rooms;
    [SerializeField]
    private GameObject[] progressbars;
    public List<GameObject> roomgens;
    public List<int> pastseeds;
    private bool checkFailed;
    [SerializeField]
    private GameObject connectedDoor;
    public float minutes;
    public GameObject[] leverroomvariants;
        //[SerializeField]
        //private GameObject newPlayer;
        void Update()
    {
        //count down the timer and generate seeds;
        if (readyTeams == 1)
        {
            timer();
            door connected = connectedDoor.GetComponent<door>();
            connected.SendMessage("Open");

        }
        generateSeed();

            //if (Input.GetKeyDown("j"))
            //{
            //    Instantiate (newPlayer);
            //}
    }

    public void generateSeed()
    {
        //check if the amount of rooms on one side is 3 (so 6 in total since there are two sides)
        //if not, generate a random seed and check if it has been used before
        //if that is also not the case, generate a room based on the seed
        if (currentRooms < 3)
        {
            seed = Random.Range(0, Rooms.Length - 1);
            seedChecker();
            pastseeds.Add(seed);
        }
        //if there are 3 rooms, generate an endroom instead
        else if (currentRooms == 3)
        {
            seed = Rooms.Length - 1;
        }
        //after the seed has been generated, instantiate the room
        for (int i = 0; i < roomgens.Count; i++)
        {
            if (roomgens[i] != null)
            {
                roomgens[i].SendMessage("Fire");
            }
        }
    }

    void seedChecker()
    {
        //checks if the current seed proposal had already been generated. if so, try again until it's unique
        //Debug.Log(pastseeds.Count);
        checkFailed = false;
        if (pastseeds.Count > 0)
        {
            for (int i = 0; i < pastseeds.Count; i++)
            {
                if (seed == pastseeds[i])
                {
                    seed = Random.Range(0, Rooms.Length - 1);
                    checkFailed = true;
                    seedChecker();
                }
            }
        }
    }

    void timer()
    {
        //as long as the timer is active, the time counts down once per second
        //if the timer is at 0 and both teams have equal progress, start overtime. if not, end the game
        //send the time over to the display function
        if (timerActive == true)
        {
                timeValue += Time.deltaTime;
            //if (timeValue > 0)
            //{
            //    timeValue += Time.deltaTime;
            //}
            //else if (progressScore1 == progressScore2 && overtime == false)
            //{
            //    timeValue = 60;
            //    overtime = true;
            //}
            //else
            //{
            //    gameEnd();
            //}

            DisplayTime(timeValue);
        }
    }
    void DisplayTime(float timeToDisplay)
    {
        //recieves the amount of remaining time from the timer, converts it from one value to an amount of minutes and seconds, then formats that and displays it
        //if (timeToDisplay < 0)
        //{
        //    timeToDisplay = 0;
        //}

        minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        timerText.text = string.Format("{0:0}:{1:00}", minutes, seconds);

    }
    void progress1()
    {
        //called by the progress trackers if one of them is touched by a player from team 1
        //ups the score by one, sets a coordinate for a piece of progressbar to display, then places it
        progressScore1++;
        Debug.Log("Team One has progressed " + progressScore1 + " Room(s)");
        Image image = progressbars[progressScore1 - 1].GetComponent<Image>();
        image.enabled = true;
        //if team 1 has 10 points, the game ends
        if (progressScore1 == 4)
        {
            readyTeams = 0;
        }
    }
    void progress2()
    {
        //called by the progress trackers if one of them is touched by a player from team 2
        //ups the score by one, sets a coordinate for a piece of progressbar to display, then places it
        //progressScore2++;
        //Debug.Log("Team Two has progressed " + progressScore2 + " Room(s)");
        //Image image = progressbars[3 + progressScore2].GetComponent<Image>();
        //image.enabled = true;
        ////if team 2 has 10 points, the game ends
        //if (overtime || progressScore2 == 4)
        //{
        //    gameEnd();
        //}
    }

    //void gameEnd()
    //{
            //sets the time to 0 then turns it off
            //checks which team has more points, then updates the winningteam value accordingly
            //timeValue = 0;
            //timerActive = false;
            //if (progressScore1 > progressScore2)
            //{
            //    winningteam = 1;
            //    Debug.Log("the winning team is team 1 !");
            //}
            //else if (progressScore2 > progressScore1)
            //{
            //    winningteam = 2;
            //    Debug.Log("the winning team is team 2 !");
            //}
            //else
            //{
            //    winningteam = 3;
            //    Debug.Log("It's a tie!");
            //}
            
    //}
}
}
