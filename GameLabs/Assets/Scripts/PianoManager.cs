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

            for (int i = 0; i < Random.Range(1, 100); i++)
            {
                correctNotes[i] = Random.Range(1, 12);               
            }
        }
        void Update()
        {
            //get the door script and tell it to open or close
            door connected = connectedDoor.GetComponent<door>();
            if (playedNotes.Count == correctNotes.Length)
            {
                for (int i = 0; i < correctNotes.Length; i++)
                {
                    if (playedNotes[i] == correctNotes[i])
                    {
                        hitNotes++;
                    }
                    else
                    {                     
                        playedNotes.Clear();
                        hitNotes = 0;
                    }
                }
            }
            if (hitNotes == correctNotes.Length)
            {
                connected.SendMessage("Open");
                Debug.Log("pling plong");
            }
            
                //if (playedNotes.Count == 3 && playedNotes[0] == correctNotes[0] && playedNotes[1] == correctNotes[1] && playedNotes[2] == correctNotes[2])
                //{
                //    connected.SendMessage("Open");
                //    Debug.Log("pling plong");
                //} 
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
