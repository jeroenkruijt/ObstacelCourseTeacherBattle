using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts
{
    public class moveable : MonoBehaviour
    {
        [SerializeField]
        [Range(-1, 1)]
        private int moveHorizontal;
        [SerializeField]
        [Range(-1, 1)]
        private int moveVertical;
        private Vector3 targetPos;

        private void move()
        {
                targetPos = transform.TransformPoint(moveHorizontal, moveVertical, 0);
                transform.position = Vector3.MoveTowards(transform.position, targetPos, 1); 
        }
    }
}
