using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Scripts 
{
    public class note : MonoBehaviour
    {
        [SerializeField]
        private GameObject notething; 

        public void DoInteraction()
        {
            notething.GetComponent<SpriteRenderer>().enabled = true;
        }
}
}