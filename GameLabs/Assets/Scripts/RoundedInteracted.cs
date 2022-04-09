using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts
{
    public class RoundedInteracted : MonoBehaviour
    {
        //we need an array to store all the players so we can send one of them a message later
        //we also need a gameobject to store who interacted with it to send it to them specifically
        public GameObject[] players;
        GameObject culprit;

        public void Start()
        {
            //find all of the players and add them to the array
            players = GameObject.FindGameObjectsWithTag("Player");

        }
        public void DoInteraction()
        {
            //debug for testing
            //Debug.Log("According to Unity I'm a 9sliced");
            //get all of the players' interaction scripts, check if the 9sliced is their target for interaction and if so call their speedbuff function
            for (int i = 0; i < players.Length; i++)
            {
                PlayerSideInteraction target = players[i].GetComponent<PlayerSideInteraction>();
                //if (checker != null)
                {
                    GameObject checker = target.inRange;
                    if (checker = gameObject)
                    {
                        culprit = players[i];
                    }
                }
            }
            if (culprit != null)
            {
                culprit.SendMessage("SpeedBuff");
            }
        }


    }
}

