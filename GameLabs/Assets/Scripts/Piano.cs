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
        public int firstKey;
        public int secondKey;
        public int thirdKey;
        [SerializeField]
        PianoManager managerScript;
        [SerializeField]
        GameObject notesDisplay;
        SpriteRenderer visibility;
        [SerializeField]
        SpriteRenderer borderOne;
        [SerializeField]
        SpriteRenderer borderTwo;
        [SerializeField]
        SpriteRenderer borderThree;

        void Start()
        {
            players = GameObject.FindGameObjectsWithTag("Player");
            manager = GameObject.FindGameObjectWithTag("PianoManager");
            managerScript = manager.GetComponent<PianoManager>();
            visibility = notesDisplay.GetComponent<SpriteRenderer>();
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
            visibility.enabled = true;
            }
            if (culprit != null)
            {
                culprit.SendMessage("playPiano");
            }
        }
        public IEnumerator KeyOne()
        {
            ClearPiano();
            managerScript.playedNotes.Add(firstKey);
            borderOne.enabled = true;
            yield return new WaitForSeconds(1.5f);
            borderOne.enabled = false;
            visibility.enabled = false;
        }
        public IEnumerator KeyTwo()
        {
            ClearPiano();
            managerScript.playedNotes.Add(secondKey);
            borderTwo.enabled = true;
            yield return new WaitForSeconds(1.5f);
            borderTwo.enabled = false;
            visibility.enabled = false;
        }

        public IEnumerator KeyThree()
        {
            ClearPiano();
            managerScript.playedNotes.Add(thirdKey);
            borderThree.enabled = true;
            yield return new WaitForSeconds(1.5f);
            borderThree.enabled = false;
            visibility.enabled = false;
        }

        public void Exit()
        {
            visibility.enabled = false;
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

