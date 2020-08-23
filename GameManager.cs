using System.Collections.Generic;
using System.Media;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    private const string PLAYER_ID_PREFIX = "Player";

    private static Dictionary<string, Player> players = new Dictionary<string, Player>();

    public static void RegisterPlayer (string _netId, Player _player)
    {
        string _playerID = PLAYER_ID_PREFIX + _netId;
        players.Add(_playerID, _player);
        _player.transform.name = _playerID;
    }


   public static void UnRegisterPlayer (string _playerID)
   {
        players.Remove(_playerID);
   }

    void OnGUI ()
    {
        GUILayout.BeginArea(new Rect(200, 200, 200, 500));
        GUILayout.BeginVertical();

        foreach (string _playerID in players.Keys)
        {
            GUILayout.Label(_playerID + " " + players[_playerID].transform.name);
        }

        GUILayout.EndVertical();
        GUILayout.EndArea();
    }
}

