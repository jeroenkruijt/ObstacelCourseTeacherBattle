using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts {
public class Roomspawner2electricboogaloo : MonoBehaviour
{
        //need a gameobject and a managerofgame script to pull from it
        [SerializeField]
        private GameObject dragmanagerhere;
        managerofgame manager;
        private void Start()
        {
            //establish communication with the managerofgame, get the managerofgame object, get the script and tell it "hey I exist", respectively
            dragmanagerhere = GameObject.FindGameObjectWithTag("manager");
            manager = dragmanagerhere.GetComponent<managerofgame>();
            manager.roomgens.Add(this.gameObject);
        }

        void Fire()
        {
            //actually generate a room and destroy the room spawnpoint to prevent further rooms from generating here
            Instantiate(manager.Rooms[manager.seed], transform.position, Quaternion.identity);
            //add it to the rooms so we can put a cap on them
            manager.currentRooms++;
            Destroy(this.gameObject);
        }

    }
}
