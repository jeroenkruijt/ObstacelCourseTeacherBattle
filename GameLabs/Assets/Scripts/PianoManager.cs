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
        void Update()
        {
            //get the door script and tell it to open or close
            door connected = connectedDoor.GetComponent<door>();
            if (playedNotes[0] == 1 && playedNotes[1] == 2 && playedNotes[2] == 3)
            {
                connected.SendMessage("Open");
                Debug.Log("pling plong");
            }
            else if (playedNotes.Count >= 3)
            {
                for (int i = 0; i < playedNotes.Count; i++)
                {
                    playedNotes.Remove(playedNotes[i]);
                }
            }
        }
    }
}