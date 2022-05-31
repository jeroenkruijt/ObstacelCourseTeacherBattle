using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts
{
    public class Piano : MonoBehaviour
    {
        //for an explanation of the functionality, check the RoundedInteracted script
        public GameObject[] players;
        [SerializeField]
        GameObject culprit;
        GameObject manager;
        public int firstKey;
        public int secondKey;
        public int thirdKey;
        [SerializeField]
        PianoManager managerScript;
        [SerializeField]
        GameObject[] notesDisplay;
        SpriteRenderer visibility;
        [SerializeField] private GameObject soundmans;
        //[SerializeField]
        //SpriteRenderer borderOne;
        //[SerializeField]
        //SpriteRenderer borderTwo;
        //[SerializeField]
        //SpriteRenderer borderThree;   

        void Start()
        {           
            manager = GameObject.FindGameObjectWithTag("PianoManager");
            managerScript = manager.GetComponent<PianoManager>();
            noSprites();
        }
        private void Update()
        {
            players = GameObject.FindGameObjectsWithTag("Player");
        }

        void setSprites()
        {
            for (int i = 0; i < notesDisplay.Length; i++)
            {
                visibility = notesDisplay[i].GetComponent<SpriteRenderer>();
                visibility.enabled = true;
            }
            visibility = notesDisplay[0].GetComponent<SpriteRenderer>();
            visibility.sprite = managerScript.pianoKeySprites[(firstKey*2)-1];

            visibility = notesDisplay[1].GetComponent<SpriteRenderer>();
            visibility.sprite = managerScript.pianoKeySprites[(secondKey*2)+23];

            visibility = notesDisplay[2].GetComponent<SpriteRenderer>();
            visibility.sprite = managerScript.pianoKeySprites[(thirdKey*2)+47];
        }

        void noSprites()
        {
            for (int i = 0; i < notesDisplay.Length; i++)
            {
                visibility = notesDisplay[i].GetComponent<SpriteRenderer>();
                visibility.enabled = false;
            }
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
                setSprites();
            }
            if (culprit != null)
            {
                culprit.SendMessage("playPiano");
            }
        }
        public IEnumerator KeyOne()
        {
            //ClearPiano();
            managerScript.playedNotes.Add(firstKey);
            managerScript.SendMessage("checkcorrectnotes");
            //borderOne.enabled = true;
            visibility = notesDisplay[0].GetComponent<SpriteRenderer>();
            visibility.sprite = managerScript.pianoKeySprites[(firstKey * 2)-2];
            yield return new WaitForSeconds(1.5f);
            //borderOne.enabled = false;
            noSprites();
        }
        public IEnumerator KeyTwo()
        {
            //ClearPiano();
            managerScript.playedNotes.Add(secondKey);
            managerScript.SendMessage("checkcorrectnotes");
            //borderTwo.enabled = true;
            visibility = notesDisplay[1].GetComponent<SpriteRenderer>();
            visibility.sprite = managerScript.pianoKeySprites[(secondKey * 2) + 22];
            yield return new WaitForSeconds(1.5f);
            //borderTwo.enabled = false;
            noSprites();
        }

        public IEnumerator KeyThree()
        {
            //ClearPiano();
            managerScript.playedNotes.Add(thirdKey);
            managerScript.SendMessage("checkcorrectnotes");
            //borderThree.enabled = true;
            visibility = notesDisplay[2].GetComponent<SpriteRenderer>();
            visibility.sprite = managerScript.pianoKeySprites[(thirdKey * 2) + 46];
            yield return new WaitForSeconds(1.5f);
            //borderThree.enabled = false;
            noSprites();
        }

        public void Exit()
        {
            noSprites();
        }

        //private void ClearPiano()
        //{
        //    if (managerScript.playedNotes.Count >= 3)
        //    {              
        //        managerScript.playedNotes.Remove(managerScript.playedNotes[2]);
        //        managerScript.playedNotes.Remove(managerScript.playedNotes[1]);
        //        managerScript.playedNotes.Remove(managerScript.playedNotes[0]);
        //    }
        //}


    }
}

