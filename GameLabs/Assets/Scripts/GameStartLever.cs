using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts {

    public class GameStartLever : MonoBehaviour
    {
        [SerializeField]
        private bool triggered = false;
        public void DoInteraction()
        {
            GameObject manager = GameObject.FindGameObjectWithTag("manager");
            managerofgame managerscript = manager.GetComponent<managerofgame>();
            if (!triggered)
            {
                managerscript.readyTeams++;
                triggered = true;
            }
            else
            {
                managerscript.readyTeams--;
                triggered = false;
            }
        }
    }
}
