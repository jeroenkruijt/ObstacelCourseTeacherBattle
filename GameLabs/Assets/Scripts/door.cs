using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts
{
    public class door : MonoBehaviour
    {
        //get the collider of the door
        BoxCollider2D doorCollider;
    private void OpenClose()
        {
            //called by a lever. if the door is open, close it, and vice versa
            //the door opens and closes by disabling and enabling its collider
            doorCollider = GetComponent<BoxCollider2D>();
            doorCollider.enabled = !doorCollider.enabled;
        }
    }
}
