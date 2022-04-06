using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Mirror;


namespace Lobby
{
    public class UILobby : MonoBehaviour
    {

        public static UILobby instance;

        [Header("host join bs:")]
        [SerializeField] private InputField joinMatchInputField;

        [SerializeField] private Button joinButton;

        [SerializeField] private Button hostButton;

        [SerializeField] private Canvas lobbyCanvas;

        [Header("Lobby")] 
        [SerializeField] private Transform UIPlayerParent;

        [SerializeField] private GameObject UIPlayerPrefab;

        [SerializeField] private Text matchIDText;
        
        [SerializeField] GameObject beginGameButton;

        
        

        private void Start()
        {
            instance = this;
        }

        public void Host()
        {
            joinMatchInputField.interactable = false;
            joinButton.interactable = false;
            hostButton.interactable = false;
            
            Player.localPlayer.HostGame();
        }

        public void HostSuccess(bool success)
        {
            if (success)
            {
                lobbyCanvas.enabled = true;
                
                SpawnerPlayerUIPrefab(Player.localPlayer);
                matchIDText.text = Player.localPlayer.matchID;
                beginGameButton.SetActive(true);
            }
            else
            {
                joinMatchInputField.interactable = true;
                joinButton.interactable = true;
                hostButton.interactable = true;
            }
        }

        public void Join()
        {
            joinMatchInputField.interactable = false;
            joinButton.interactable = false;
            hostButton.interactable = false;
            
            Player.localPlayer.JoinGame(joinMatchInputField.text.ToUpper ());

        }

        public void JoinSuccess(bool success)
        {
            if (success)
            {
                lobbyCanvas.enabled = true; 
                
                SpawnerPlayerUIPrefab(Player.localPlayer);
                matchIDText.text = Player.localPlayer.matchID;
            }
            else
            {
                joinMatchInputField.interactable = true;
                joinButton.interactable = true;
                hostButton.interactable = true;
            }
        }

        public GameObject SpawnerPlayerUIPrefab (Player player) {
            GameObject newUIPlayer = Instantiate (UIPlayerPrefab, UIPlayerParent);
            newUIPlayer.GetComponent<UIPlayer> ().SetPlayer (player);
            newUIPlayer.transform.SetSiblingIndex (player.playerIndex - 1);

            return newUIPlayer;
        }

        public void BeginGame()
        {
            Player.localPlayer.BeginGame();
        }

    }
}