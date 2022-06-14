using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts
{
    public class managedLever : MonoBehaviour
    {
        [SerializeField]
        private GameObject leverManager;
        public bool triggered = false;
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
                FindObjectOfType<AudioManager>().Play("correct");
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
