using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Lobby {

    public class UIPlayer : MonoBehaviour
    {

        [SerializeField] private Text text;

        private Player player;

        public void SetPlayer(Player player)
        {
            this.player = player;
            text.text = "player " + player.playerIndex;
        }
        
    }
}