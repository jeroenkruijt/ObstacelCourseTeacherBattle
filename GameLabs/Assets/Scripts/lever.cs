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
        public Animator _anim;
        private bool triggered = false;

        private void Start()
        {
            _anim = GetComponent<Animator>();
        }

        public void DoInteraction()
        {
            //get the door script and tell it to open or close
            door connected = connectedDoor.GetComponent<door>();
            connected.SendMessage("OpenClose");
            Debug.Log("flip");
            if (triggered == false)
            {
                triggered = true;
                _anim.SetBool("Interacted", true);
            }
            else
            {
                triggered = false;
                _anim.SetBool("Interacted", false);
            }
        }
    }
}
