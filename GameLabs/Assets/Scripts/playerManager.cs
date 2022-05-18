using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Scripts
{
    public class playerManager : MonoBehaviour
    {
        [SerializeField]
        private GameObject[] players;
        [SerializeField]
        private Sprite[] models;
        [SerializeField]
        private int newest;
        [SerializeField]
        private Slider[] healtbars;
        void joinPlayer()
        {
            players = GameObject.FindGameObjectsWithTag("Player");
            newest = players.Length - 1;
            Debug.Log(newest);
            PlayerSideInteraction PSI = players[newest].GetComponent<PlayerSideInteraction>();
            PSI.playerID = newest;
            //SpriteRenderer SR = players[newest].GetComponent<SpriteRenderer>();
            //SR.sprite = models[newest];
            PSI.healthBar = healtbars[newest];
        }
    }
}

