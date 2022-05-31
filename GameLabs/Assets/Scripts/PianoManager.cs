using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts
{
    public class PianoManager : MonoBehaviour
    {
        //set the door this should open
        [SerializeField]
        private GameObject connectedDoor;
        public List<int> playedNotes;
        [SerializeField]
        private int possibleNote;
        [SerializeField]
        private int[] divideNotes;
        //private bool noteUsed;
        [SerializeField]
        private List<int> pastNotes;
        [SerializeField]
        private GameObject[] pianos;
        public Sprite[] pianoKeySprites;
        [SerializeField]
        private int[] correctNotes;
        private int hitNotes;
        [SerializeField]
        managerofgame gameManagerScript;
        [SerializeField]
        private AudioSource[] sounds;
        private void Start()
        {
            for (int i = 0; i < 12; i++)
            {
                possibleNote = Random.Range(0, 12);
                Debug.Log(possibleNote);
                noteChecker();
                pastNotes.Add(possibleNote);
                divideNotes[i] = possibleNote+1;
            }

            for (int i = 0; i < pianos.Length; i++)
            {
                Piano target = pianos[i].GetComponent<Piano>();
                target.firstKey = divideNotes[i];
                target.secondKey = divideNotes[i + 4];
                target.thirdKey = divideNotes[i + 8];
            }
            GameObject gameManager = GameObject.Find("managerofgame");
            gameManagerScript = gameManager.GetComponent<managerofgame>();
            
        }
        void Update()
        {
            //get the door script and tell it to open or close
            door connected = connectedDoor.GetComponent<door>();
            
            //if (playedNotes.Count > 0 && playedNotes[playedNotes.Count-1] != correctNotes[playedNotes.Count-1])
            //{
            //    Debug.Log(playedNotes[playedNotes.Count - 1]);
            //    Debug.Log(correctNotes[playedNotes.Count - 1]);
            //    playedNotes.Clear();
            //}
            if (playedNotes.Count == correctNotes.Length)
            {
                connected.SendMessage("Open");
                //Debug.Log("pling plong");
            }

            //if (playedNotes.Count == correctNotes.Length)
            //{
            //    for (int i = 0; i < correctNotes.Length; i++)
            //    {
            //        if (playedNotes[i] == correctNotes[i])
            //        {
            //            hitNotes++;
            //        }
            //        else
            //        {                     
            //            playedNotes.Clear();
            //            hitNotes = 0;
            //        }
            //    }
            //}
            //if (hitNotes == correctNotes.Length)
            //{
            //    connected.SendMessage("Open");
            //    Debug.Log("pling plong");
            //}



            correctNotes[0] = (divideNotes[6] + divideNotes[3]) / 2;
            correctNotes[1] = correctNotes[0];
            correctNotes[2] = correctNotes[0];
            correctNotes[3] = (int)gameManagerScript.minutes+1;
            correctNotes[4] = correctNotes[3];
            correctNotes[5] = correctNotes[4];
            correctNotes[6] = (correctNotes[0] + correctNotes[2]) / 2 + divideNotes[8];
            if (correctNotes[6] > 12) correctNotes[6] = divideNotes[9];
            correctNotes[7] = correctNotes[6];
            correctNotes[8] = correctNotes[6];

            



            //if (playedNotes.Count == 3 && playedNotes[0] == correctNotes[0] && playedNotes[1] == correctNotes[1] && playedNotes[2] == correctNotes[2])
            //{
            //    connected.SendMessage("Open");
            //    Debug.Log("pling plong");
            //} 
        }

        void checkcorrectnotes()
        {
            Debug.Log(playedNotes[playedNotes.Count - 1]);
            Debug.Log(correctNotes[playedNotes.Count - 1]);
            if (playedNotes[playedNotes.Count - 1] != correctNotes[playedNotes.Count - 1])
            {
                playedNotes.Clear();
            }
        }

        void noteChecker()
        {
            if (pastNotes.Count > 0)
            {
                for (int j = 0; j < pastNotes.Count; j++)
                {
                    if (possibleNote == pastNotes[j])
                    {
                        possibleNote = Random.Range(0, 12);
                        //noteUsed = true;
                        noteChecker();
                    }
                }
            }
        }

    }
}
