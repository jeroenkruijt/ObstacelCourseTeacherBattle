using UnityEngine;

namespace Scripts
{
    public class CamBehaviourPlayer : MonoBehaviour
    {
        [Header("Components:")] public Transform target;

        [Header("Smoothing of cam:")] public float smoothing;

        [Header("Max and Min range for cam to go:")]
        public Vector2 maxPos;

        public Vector2 minPos;

        private void FixedUpdate()
        {
            var targetPos = new Vector3(target.position.x, target.position.y, transform.position.z);

            targetPos.x = Mathf.Clamp(targetPos.x, minPos.x, maxPos.x);
            targetPos.y = Mathf.Clamp(targetPos.y, minPos.y, maxPos.y);

            transform.position = Vector3.Lerp(transform.position, targetPos, smoothing);
        }
    }
}