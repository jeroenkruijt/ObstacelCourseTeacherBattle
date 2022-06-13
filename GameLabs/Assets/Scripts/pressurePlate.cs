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
        public Animator _anim;

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
                moveable connected = connectedBox.GetComponent<moveable>();
                //connected.SendMessage("move");
                Debug.Log("*gets pounced on*");
            }
        }
}
}
