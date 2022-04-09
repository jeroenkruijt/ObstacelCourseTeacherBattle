using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts
{
    public class LeverManager : MonoBehaviour
    {
        [SerializeField]
        private int flippedLevers;
        [SerializeField]
        private GameObject connectedDoor;
        public void LeverAdded()
        {
            flippedLevers++;
            if (flippedLevers == 4)
            {
                door connected = connectedDoor.GetComponent<door>();
                connected.SendMessage("Open");
            }
        }

        public void LeverRemoved()
        {
            flippedLevers--;
        }
    }
}
