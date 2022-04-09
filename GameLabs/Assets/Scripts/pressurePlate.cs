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
        public void OnTriggerEnter2D(Collider2D other)
        {
            //if a player steps on this call the attached box' move function
            if (other.CompareTag("Player"))
            {
                moveable connected = connectedBox.GetComponent<moveable>();
                connected.SendMessage("move");
                Debug.Log("*gets pounced on*");
            }
        }
}
}
