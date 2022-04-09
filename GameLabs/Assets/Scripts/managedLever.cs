using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts
{
    public class managedLever : MonoBehaviour
    {
        [SerializeField]
        private GameObject leverManager;
        [SerializeField]
        private bool triggered = false;
        public void DoInteraction()
        {
            if (triggered == false)
            {
                leverManager.SendMessage("LeverAdded");
                triggered = true;
            }
            else
            {
                leverManager.SendMessage("LeverRemoved");
                triggered = false;
            }
        }
    }
}
