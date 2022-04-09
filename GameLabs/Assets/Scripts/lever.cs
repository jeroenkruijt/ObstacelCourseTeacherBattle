using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts
{
    public class lever : MonoBehaviour
    {
        //set the door this should open
        [SerializeField]
        private GameObject connectedDoor;
        public void DoInteraction()
        {
            //get the door script and tell it to open or close
            door connected = connectedDoor.GetComponent<door>();
            connected.SendMessage("OpenClose");
            Debug.Log("flip");
        }
    }
}
