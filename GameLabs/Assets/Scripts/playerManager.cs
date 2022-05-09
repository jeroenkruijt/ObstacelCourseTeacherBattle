using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts
{
    public class playerManager : MonoBehaviour
    {
        [SerializeField]
        private GameObject[] players;

        void joinPlayer()
        {
            ScuffedPlayerController target = players[players.Length-1].GetComponent<ScuffedPlayerController>();
            target.inputNumber = players.Length-1;
        }

        private void Update()
        {
            players = GameObject.FindGameObjectsWithTag("Player");
        }
    }
}

