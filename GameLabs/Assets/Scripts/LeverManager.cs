using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts
{
    public class LeverManager : MonoBehaviour
    {
        [SerializeField]
        private int flippedLevers;
        [SerializeField]
        private GameObject connectedDoor;
        [SerializeField]
        private GameObject[] CorrectLevers;
        [SerializeField]
        private bool countingdown = false;
        public void LeverAdded()
        {
            flippedLevers++;
            if (flippedLevers == 4)
            {
                door connected = connectedDoor.GetComponent<door>();
                connected.SendMessage("Open");
            }
            if (!countingdown) StartCoroutine("countdown");
        }

        private IEnumerator countdown()
        {
            countingdown = true;
            yield return new WaitForSeconds(3);
            countingdown = false;
            unflip();
        }

        private void unflip()
        {
            for (int i = 0; i < CorrectLevers.Length; i++)
            {
                managedLever target = CorrectLevers[i].GetComponent<managedLever>();
                if (target.triggered == true)
                {
                    target.SendMessage("DoInteraction");
                }
            }
        }
        public void LeverRemoved()
        {
            flippedLevers--;
        }
    }
}
