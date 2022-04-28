using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts
{
    public class PressurePlateManager : MonoBehaviour
    {
        [SerializeField]
        private int pressed = 0;
        [SerializeField]
        private GameObject bridgeManager;

        private void platePressed()
        {
            pressed++;
            if (pressed == 2)
            {
                bridgeManager.SendMessage("SendMove");
                BoxBridges reset = bridgeManager.GetComponent<BoxBridges>();
                reset.SendmoveHorizontal = 0;
                reset.SendmoveVertical = 0;
                pressed = 0;
            }
        }
    }
}


