using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts {

    public class GameStartLever : MonoBehaviour
    {
        [SerializeField]
        private bool triggered = false;
        public Animator _anim;

        private void Start()
        {
            _anim = GetComponent<Animator>();
        }

        public void DoInteraction()
        {
            GameObject manager = GameObject.FindGameObjectWithTag("manager");
            managerofgame managerscript = manager.GetComponent<managerofgame>();
            if (!triggered)
            {
                managerscript.readyTeams++;
                triggered = true;
                _anim.SetBool("Interacted", true);
            }
            else
            {
                managerscript.readyTeams--;
                triggered = false;
                _anim.SetBool("Interacted", false);
            }
        }
    }
}
