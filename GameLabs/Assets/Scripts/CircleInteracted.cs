using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts
{
    public class CircleInteracted : MonoBehaviour
    {
        //for an explanation of the functionality, check the RoundedInteracted script
        public GameObject[] players;
        GameObject culprit;

        public AudioSource[] soundFX;

        public void Start()
        {
            
        }
        public void DoInteraction()
        {
            players = GameObject.FindGameObjectsWithTag("Player");
            Debug.Log("OwO I'm a circle");
            
            //sound
            soundFX[0].Play();
            
            for (int i = 0; i < players.Length; i++)
            {
                PlayerSideInteraction target = players[i].GetComponent<PlayerSideInteraction>();
                //if (checker != null)
                {
                    GameObject checker = target.inRange;
                    if (checker == gameObject)
                    {
                        culprit = players[i];
                    }
                }
            }
            if (culprit != null)
            {
                culprit.SendMessage("HealthBuff");
            }
        }


    }
}