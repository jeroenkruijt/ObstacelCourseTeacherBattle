using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using Mirror;
using UnityEngine;
using Random = System.Random;


namespace Lobby
{

    [System.Serializable]
    public class Match
    {
        public string matchID;

        public List<Player> players = new List<Player> ();
        public Match(string matchID, Player player)
        {
            this.matchID = matchID;
            players.Add(player);
        }

        public Match() { }
    }

    public class MatchMaker : NetworkBehaviour
    {
        public static MatchMaker instance;

        public SyncList<Match> matches = new SyncList<Match> ();
        
        public SyncList<String> matchIDs = new SyncList<String> ();
        
        [SerializeField] int maxMatchPlayers = 12;

        private void Start()
        {
            instance = this;
        }

        #region host game logic

         public bool HostGame(string _matchID, Player _player, out int playerIndex)
                {
                    playerIndex = -1;
                    
                    if (!matchIDs.Contains(_matchID))
                    {
                        matchIDs.Add (_matchID);
                        matches.Add(new Match(_matchID, _player));
                        Debug.Log($"match generated");
                        playerIndex = 1;
                        return true;
                    }
                    else
                    {
                        Debug.Log($"match id already exists");
                        return false;
                    }
                }

        #endregion

        #region join game logic

        public bool JoinGame(string _matchID, Player _player, out int playerIndex)
                {
                    playerIndex = -1;
                    if (matchIDs.Contains(_matchID))
                    {
        
                        for (int i = 0; i < matches.Count; i++)
                        {
                            if (matches[i].matchID == _matchID)
                            {
                                matches[i].players.Add(_player);
        
                                playerIndex = matches[i].players.Count;
                                break;
                            }
                        }
                        Debug.Log ($"Match joined");
                        return true;
                    } else {
                        Debug.Log ($"Match ID does not exist");
                        return false;
                    }
                }

        #endregion

        #region begin game logic

        public void BeginGame()
        {
            
        }

        #endregion

        #region make random lobby code

        public static string GetRandomMatchID()
                {
                    string _id = string.Empty;
                    for (int i = 0; i < 5; i++)
                    {
                        int random = UnityEngine.Random.Range(0, 36);
                        if (random <26)
                        {
                            _id += (char)(random + 65);
                        }
                        else
                        {
                            _id += (random - 26).ToString();
                        }
                    }
                    Debug.Log($"random match ID: {_id} ");
                    return _id;
                }

        #endregion
        
        
    }
    public static class MatchExtensions {
        public static Guid ToGuid (this string id) {
            MD5CryptoServiceProvider provider = new MD5CryptoServiceProvider ();
            byte[] inputBytes = Encoding.Default.GetBytes (id);
            byte[] hashBytes = provider.ComputeHash (inputBytes);

            return new Guid (hashBytes);
        }
    }
}
