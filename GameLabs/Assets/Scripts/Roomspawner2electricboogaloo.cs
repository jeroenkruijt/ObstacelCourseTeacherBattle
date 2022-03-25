using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace scripts {
public class Roomspawner2electricboogaloo : MonoBehaviour
{
        private int seed;
        [SerializeField]
        private GameObject[] Rooms;
        private void Start()
    {
            if (badidea.currentRooms < 10)
            {
                seed = Random.Range(0, Rooms.Length - 1);
            }
            else
            {
                seed = Rooms.Length - 1;
            }
            Instantiate(Rooms[seed], transform.position, Rooms[seed].transform.rotation);
            badidea.currentRooms++;

        }

    }
}
