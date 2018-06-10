using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	private const string PLAYER_ID = "Player ";

	private static Dictionary <string , Player> players = new Dictionary<string, Player>();

	public static void RegisterPlayer (string _netID, Player player)
	{
		string playerID = PLAYER_ID + _netID;
		players.Add (playerID, player);
		player.transform.name = playerID;
	}

	public static void UnRegisterPlayer(string playerID)
	{
		players.Remove (playerID);
	}

	public static Player GetPlayer(string playerID)
	{
		return players[playerID];
	}

}


