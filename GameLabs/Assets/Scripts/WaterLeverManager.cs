using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts
{
    public class WaterLeverManager : MonoBehaviour
    {
        [SerializeField] private GameObject[] levers;
        // Start is called before the first frame update
        void Start()
        {
            levers = GameObject.FindGameObjectsWithTag("lever");
        }

        void flip()
        {
            for (int i = 0; i < levers.Length; i++)
            {
                Animator target = levers[i].GetComponent<Animator>();
                SelectBox SB = levers[i].GetComponent<SelectBox>();
                target.SetBool("Interacted", false);
                SB.flipped = false;
            }
        }
    }

}

