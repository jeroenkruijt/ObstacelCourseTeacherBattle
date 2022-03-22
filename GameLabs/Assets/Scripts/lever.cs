using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts
{
    public class lever : MonoBehaviour
    {
        [SerializeField]
        private GameObject connectedDoor;
        public void DoInteraction()
        {
            door connected = connectedDoor.GetComponent<door>();
            connected.SendMessage("OpenClose");
            Debug.Log("flip");
        }
    }
}
