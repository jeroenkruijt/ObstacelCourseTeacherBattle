using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts
{
    public class SelectBox : MonoBehaviour
    {
        [SerializeField]
        private GameObject bridgeManager;
        [SerializeField]
        private GameObject waterLeverManager;
        [SerializeField]
        private GameObject connectedBox;
        [SerializeField]
        private Animator _anim;
        public bool flipped = false;

        public void DoInteraction()
        {
            BoxBridges manager = bridgeManager.GetComponent<BoxBridges>();
            manager.selectedBox = connectedBox;
            WaterLeverManager WLM = waterLeverManager.GetComponent<WaterLeverManager>();
            WLM.SendMessage("flip");
            flipped = !flipped;
            _anim.SetBool("Interacted", flipped);
        }
    }
}

