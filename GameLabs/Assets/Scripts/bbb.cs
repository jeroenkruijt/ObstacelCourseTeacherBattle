using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts
{
    public class bbb : MonoBehaviour
    {
        void Start()
        {
            Transform position = gameObject.GetComponent<Transform>();
            position.position += new Vector3 (Random.Range(-2, 2), Random.Range(-3, 2), 0);
        }
    }
}

