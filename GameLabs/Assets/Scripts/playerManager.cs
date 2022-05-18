using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts
{
    public class playerManager : MonoBehaviour
    {
        [SerializeField]
        private GameObject[] players;
        [SerializeField]
        private Sprite[] models;

        void joinPlayer()
        {
            ScuffedPlayerController target = players[players.Length-1].GetComponent<ScuffedPlayerController>();
            target.inputNumber = players.Length-1;
            SpriteRenderer thingy = players[players.Length - 1].GetComponent<SpriteRenderer>();
            thingy.sprite = models[players.Length - 2];
        }

        private void Update()
        {
            players = GameObject.FindGameObjectsWithTag("Player");
        }
    }
}

