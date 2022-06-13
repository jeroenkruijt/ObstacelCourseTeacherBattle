using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts
{
    public class pressurePlate : MonoBehaviour
    {
        //attach a box to the pressure plate to move
        [SerializeField]
        private GameObject connectedBox;
        [SerializeField]
        private Animator _anim;

        public void Start()
        {
            _anim = GetComponent<Animator>();
        }
        public void OnTriggerEnter2D(Collider2D other)
        {
            //if a player steps on this call the attached box' move function
            if (other.CompareTag("Player"))
            {
                //FindObjectOfType<AudioManager>().Play("switch");
                _anim.SetBool("stepped", true);
                connectedBox.GetComponent<moveable>().SendMessage("move");
            }
        }
        public void OnTriggerExit2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                FindObjectOfType<AudioManager>().Play("switch");
                _anim.SetBool("stepped", false);
            }
        }

    }
}
