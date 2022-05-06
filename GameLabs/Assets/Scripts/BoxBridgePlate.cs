using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts
{
    public class BoxBridgePlate : MonoBehaviour
    {
        //attach a box to the pressure plate to move
        [SerializeField]
        private GameObject BridgeMaker;
        [SerializeField]
        [Range(-1, 1)]
        public int SetmoveHorizontal;
        [SerializeField]
        [Range(-1, 1)]
        public int SetmoveVertical;
        BoxBridges setDirection;
        [SerializeField]
        private GameObject plateManager;


        private void Start()
        {
            setDirection = BridgeMaker.GetComponent<BoxBridges>();
        }
        public void OnTriggerEnter2D(Collider2D other)
        {
            //if a player steps on this call the attached box' move function
            if (other.CompareTag("Player"))
            {
                setDirection.SendmoveHorizontal += SetmoveHorizontal;
                setDirection.SendmoveVertical += SetmoveVertical;
                plateManager.SendMessage("platePressed");
            }
        }
    }
}
