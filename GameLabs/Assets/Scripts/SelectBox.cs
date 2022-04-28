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
        private GameObject connectedBox;

        public void DoInteraction()
        {
            BoxBridges manager = bridgeManager.GetComponent<BoxBridges>();
            manager.selectedBox = connectedBox;
        }
    }
}

