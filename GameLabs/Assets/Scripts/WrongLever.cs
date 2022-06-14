using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts
{
    public class WrongLever : MonoBehaviour
    {
        //set the door this should open
        [SerializeField]
        private GameObject gameManager;
        public Animator _anim;
        private bool triggered = false;

        private void Start()
        {
            _anim = GetComponent<Animator>();
            gameManager = GameObject.Find("managerofgame");
        }

        public void DoInteraction()
        {
            //get the door script and tell it to open or close
            Debug.Log("flip");
            if (triggered == false)
            {
                triggered = true;
                _anim.SetBool("Interacted", true);
                FindObjectOfType<AudioManager>().Play("wrong");
                managerofgame managerScript = gameManager.GetComponent<managerofgame>();
                managerScript.timeValue = managerScript.timeValue + 5;
            }
            else
            {
                triggered = false;
                _anim.SetBool("Interacted", false);
            }
        }
    }
}
