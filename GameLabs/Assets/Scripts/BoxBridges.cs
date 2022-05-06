using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts
{
    public class BoxBridges : MonoBehaviour
    {
        [SerializeField]
        [Range(-1, 1)]
        public int SendmoveHorizontal;
        [SerializeField]
        [Range(-1, 1)]
        public int SendmoveVertical;
        [SerializeField]
        private GameObject[] Boxes;
        [SerializeField]
        public GameObject selectedBox;

        private void SendMove()
        {
            moveable direction = selectedBox.GetComponent<moveable>();
            direction.moveHorizontal = SendmoveHorizontal;
            direction.moveVertical = SendmoveVertical;
            selectedBox.SendMessage("move");
        }
    }
}