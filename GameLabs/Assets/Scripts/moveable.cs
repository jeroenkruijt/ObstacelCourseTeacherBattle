using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts
{
    public class moveable : MonoBehaviour
    {
        //create a slider in the inspector so people can set the direction this should move in
        //create a vector to move the gameobject
        [SerializeField]
        [Range(-1, 1)]
        public int moveHorizontal;
        [SerializeField]
        [Range(-1, 1)]
        public int moveVertical;
        private Vector3 targetPos;

        private void move()
        {
            //move the object based on the values of the slider
                targetPos = transform.TransformPoint(moveHorizontal*2, moveVertical*2, 0);
                transform.position = Vector3.MoveTowards(transform.position, targetPos, 1); 
        }
    }
}
