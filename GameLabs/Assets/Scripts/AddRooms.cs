using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts
{
    public class AddRooms : MonoBehaviour
    {
        private RoomTemplates templates;

        void Start()
        {
            //templates = GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomTemplates>();
            //templates.currentRooms.Add(this.gameObject);
           // Debug.Log(templates.currentRooms.Count);
        }
    }
}
