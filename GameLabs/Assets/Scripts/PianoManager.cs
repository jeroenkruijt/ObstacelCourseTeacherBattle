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
                if (playedNotes.Count == 3 && playedNotes[0] == 8 && playedNotes[1] == 10 && playedNotes[2] == 2)
                {
                    connected.SendMessage("Open");
                    Debug.Log("pling plong");
                } 
        }
    }
}
