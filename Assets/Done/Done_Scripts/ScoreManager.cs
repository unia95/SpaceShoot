using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Linq;

public class ScoreManager : MonoBehaviour {


	Dictionary< string,int > playerScores;

	private string player;
	private string path="Assets/score.txt";
	public int[] scores2;
	List<int> scorse;
	int i=0;

	void Start() {
		StreamReader reader = new StreamReader (path);
		scorse = new List<int> ();
		string read;
		read = reader.ReadLine ();
		while (read != null){
			scorse.Add(int.Parse(read));
			read = reader.ReadLine ();

		}
		reader.Close ();
		scorse.Sort ();
		scores2=scorse.ToArray ();

		for (i = 0; i < 4; i++) {
			player = "player" + i.ToString ();
			SetScore(player, scores2[(scores2.Length) -i-1]);
			Debug.Log (scores2[(scores2.Length) -i-1]);
		}
		

	}

	void Init() {
		if(playerScores != null)
			return;

		playerScores = new Dictionary<string, int>();
	}

	public void Reset() {
		playerScores = null;
	}

	public int GetScore(string username) {
		Init ();

		if(playerScores.ContainsKey(username) == false) {
			// We have no score record at all for this username
			return 0;
		}

		return playerScores[username];
	}

	public void SetScore(string username, int value) {
		Init ();
		playerScores[username]= value;
	}

	public void ChangeScore(string username, int amount) {
		Init ();
		int currScore = GetScore(username);
		SetScore(username, currScore + amount);
	}

	public string[] GetPlayerNames() {
		Init ();
		return playerScores.Keys.ToArray();
	}
	
	public string[] GetPlayerNames(string sortingScoreType) {
		Init ();

		return playerScores.Keys.OrderByDescending( n => GetScore(n)).ToArray();
	}


}
