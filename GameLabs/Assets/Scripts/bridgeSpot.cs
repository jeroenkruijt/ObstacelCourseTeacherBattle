using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts
{
    public class bridgeSpot : MonoBehaviour
    {
        [SerializeField]
        GameObject correctBox;
        void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject == correctBox)
            {
                //Debug.Log("faka drerrie");
                BoxCollider2D collider = gameObject.GetComponent<BoxCollider2D>();
                collider.enabled = false;
            }
        }

        void OnTriggerExit2D(Collider2D other)
        {
            if (other.gameObject == correctBox)
            {
                //Debug.Log("challas a neef");
                BoxCollider2D collider = gameObject.GetComponent<BoxCollider2D>();
                collider.enabled = true;
            }
        }
    }
}

