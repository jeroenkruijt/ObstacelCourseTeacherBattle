using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts
{
    public class RoundedInteracted : MonoBehaviour
    {
        public GameObject[] players;
        GameObject culprit;

        public void Start()
        {
            players = GameObject.FindGameObjectsWithTag("Player");
        }
        public void DoInteraction()
        {
            Debug.Log("According to Unity I'm a 9sliced");
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

