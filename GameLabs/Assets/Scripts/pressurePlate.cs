using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts
{
    public class pressurePlate : MonoBehaviour
    {
        [SerializeField]
        private GameObject connectedBox;
        public void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                moveable connected = connectedBox.GetComponent<moveable>();
                connected.SendMessage("move");
                Debug.Log("*gets pounced on*");
            }
        }
}
}
