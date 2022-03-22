using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts
{
    public class door : MonoBehaviour
    {
        BoxCollider2D doorCollider;
    private void OpenClose()
        {
            doorCollider = GetComponent<BoxCollider2D>();
            doorCollider.enabled = !doorCollider.enabled;
        }
    }
}
