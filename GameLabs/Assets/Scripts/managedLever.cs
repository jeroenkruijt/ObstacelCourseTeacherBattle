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
        public Animator _anim;

        private void Start()
        {
            _anim = GetComponent<Animator>();
        }

        public void DoInteraction()
        {
            if (triggered == false)
            {
                leverManager.SendMessage("LeverAdded");
                triggered = true;
                _anim.SetBool("Interacted", true);
            }
            else
            {
                leverManager.SendMessage("LeverRemoved");
                triggered = false;
                _anim.SetBool("Interacted", false);
            }
        }
    }
}
