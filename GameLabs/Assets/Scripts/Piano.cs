using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts
{
    public class Piano : MonoBehaviour
    {
        //for an explanation of the functionality, check the RoundedInteracted script
        public GameObject[] players;
        GameObject culprit;
        GameObject manager;
        [SerializeField]
        private int firstKey;
        [SerializeField]
        private int secondKey;
        [SerializeField]
        private int thirdKey;
        [SerializeField]
        PianoManager managerScript;

        void Start()
        {
            players = GameObject.FindGameObjectsWithTag("Player");
            manager = GameObject.FindGameObjectWithTag("PianoManager");
            managerScript = manager.GetComponent<PianoManager>();
        }
        public void DoInteraction()
        {
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
                culprit.SendMessage("playPiano");
            }
        }
        public void KeyOne()
        {
            ClearPiano();
            managerScript.playedNotes.Add(firstKey);
        }
        public void KeyTwo()
        {
            ClearPiano();

            managerScript.playedNotes.Add(secondKey);
        }
        public void KeyThree()
        {
            ClearPiano();
            managerScript.playedNotes.Add(thirdKey);
        }

        private void ClearPiano()
        {
            if (managerScript.playedNotes.Count >= 3)
            {              
                managerScript.playedNotes.Remove(managerScript.playedNotes[2]);
                managerScript.playedNotes.Remove(managerScript.playedNotes[1]);
                managerScript.playedNotes.Remove(managerScript.playedNotes[0]);
            }
        }


    }
}

