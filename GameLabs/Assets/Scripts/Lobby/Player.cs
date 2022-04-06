using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using Mirror;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Lobby
{
    public class Player : NetworkBehaviour
    {

        public static Player localPlayer;
        [SyncVar]public string matchID;
        [SyncVar] public int playerIndex;

        
        NetworkMatch networkMatch;


        private void Start()
        {
            
            networkMatch = GetComponent<NetworkMatch> ();

            if (isLocalPlayer)
            {
                localPlayer = this;
            }
            else
            {
                UILobby.instance.SpawnerPlayerUIPrefab(this);
            }
        }

        #region host game
        public void HostGame()
        {
            //gets random 5 diggit code for the game that people could 
            string matchID = MatchMaker.GetRandomMatchID();
            CmdHostGame(matchID);
        }

        [Command]
        void CmdHostGame(string _matchID)
        {
            matchID = _matchID;
            if (MatchMaker.instance.HostGame(_matchID, this, out playerIndex))
            {
                Debug.Log($"<color=green>Game hosted successfully</color>");
                networkMatch.matchId = _matchID.ToGuid ();
                TargetHostGame (true, _matchID);
            }
            else
            {
                Debug.Log($"<color=red>Game hosted failed</color>");
                TargetHostGame (false, _matchID);
            }
        }

        [TargetRpc]
        void TargetHostGame(bool success, string _matchID)
        {
            Debug.Log($"MatchID: {_matchID}");
            UILobby.instance.HostSuccess(success);
        }
        
        #endregion


        #region join game

        public void JoinGame(string _inputID)
        {
            CmdJoinGame (_inputID);
        }

        [Command]
        void CmdJoinGame(string _matchID)
        {
            matchID = _matchID;
            if (MatchMaker.instance.JoinGame(_matchID, this, out playerIndex))
            {
                Debug.Log($"<color=green>Game Joined successfully</color>");
                networkMatch.matchId = _matchID.ToGuid ();
                TargetJoinGame (true, _matchID);
            }
            else
            {
                Debug.Log($"<color=red>Game Joined failed</color>");
                TargetJoinGame (false, _matchID);
            }
        }

        [TargetRpc]
        public void TargetJoinGame(bool success, string _matchID)
        {
            Debug.Log($"MatchID: {matchID} == {_matchID}");
            UILobby.instance.JoinSuccess(success);
        }

        #endregion


        #region start game

                public void BeginGame()
                {
                    CmdBeginGame();
                }
        
                [Command]
                void CmdBeginGame()
                {
                    MatchMaker.instance.BeginGame();
                    Debug.Log ($"<color=red>Game Beginning</color>");
                }

                public void StartGame()
                {
                    TargetBeginGame ();
                }
        
                [TargetRpc]
                void TargetBeginGame () {
                    Debug.Log ($"MatchID: {matchID} | Beginning");
                    //Additively load game scene
                    SceneManager.LoadScene (2, LoadSceneMode.Additive);
                }

        #endregion
        
        
    }
}