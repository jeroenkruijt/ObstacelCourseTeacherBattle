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
        [SerializeField]
        private Animator _anim;


        private void Start()
        {
            setDirection = BridgeMaker.GetComponent<BoxBridges>();
            _anim = GetComponent<Animator>();
        }
        public void OnTriggerEnter2D(Collider2D other)
        {
            //if a player steps on this call the attached box' move function
            if (other.CompareTag("Player"))
            {
                _anim.SetBool("stepped", true);
                FindObjectOfType<AudioManager>().Play("switch");
                setDirection.SendmoveHorizontal += SetmoveHorizontal;
                setDirection.SendmoveVertical += SetmoveVertical;
                plateManager.SendMessage("platePressed");
            }
        }
        public void OnTriggerExit2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                _anim.SetBool("stepped", false);
            }
        }
    }
}
