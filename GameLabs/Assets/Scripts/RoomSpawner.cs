using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts
{
    public class RoomSpawner : MonoBehaviour
    {
        private RoomTemplates templates;
        private int seed;
        //private bool spawned = false;
        //private int roomlimit = 10;

        void Start()
        {
            {
                templates = GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomTemplates>();
                GenerateRoom();
            }
        }

        void GenerateRoom()
        {
            //spawned == false &&
            //if (templates.currentRooms.Count < roomlimit)

            //{
            //    seed = Random.Range(0, templates.Rooms.Length - 1);
            //}

            //if (templates.currentRooms.Count == roomlimit)
            //{
            //    seed = templates.Rooms.Length - 1;
            //}
            //else

            
                seed = Random.Range(0, templates.Rooms.Length - 1);
            
            Instantiate(templates.Rooms[seed], transform.position, templates.Rooms[seed].transform.rotation);
            //spawned = true;

        }
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Next room"))
            {
                Destroy(gameObject);
                
            }
        }
    }
}
