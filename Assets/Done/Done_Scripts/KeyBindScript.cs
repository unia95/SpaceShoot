using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class KeyBindScript : MonoBehaviour {

	private Dictionary<string, KeyCode> keys= new Dictionary<string, KeyCode>();

	public Text up, left, down, right, attack;

	private GameObject currentKey;

	private Color32 normal = new Color (255, 255, 255, 255);
	private Color32 selected = new Color (255, 255, 255, 255);

	// Use this for initialization
	void Start () {
		keys.Add ("Up",(KeyCode) System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Up", "W")));
		keys.Add ("Down", (KeyCode) System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Down", "S")));
		keys.Add ("Left", (KeyCode) System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Left", "A")));
		keys.Add ("Right", (KeyCode) System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Right", "D")));
		keys.Add ("Attack", (KeyCode) System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Attack", "LeftControl")));

		up.text = keys ["Up"].ToString ();
		down.text = keys ["Down"].ToString ();
		left.text = keys ["Left"].ToString ();
		right.text = keys ["Right"].ToString ();
		attack.text = keys ["Attack"].ToString ();
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (keys ["Up"])) {
		}

		if (Input.GetKeyDown (keys ["Down"])) {
		}

		if (Input.GetKeyDown (keys ["Left"])) {
		}

		if (Input.GetKeyDown (keys ["Right"])) {
		}

		if (Input.GetKeyDown (keys ["Attack"])) {
		}
	}


	void OnGUI(){
		if (currentKey != null) {
			Event e = Event.current;
			if (e.isKey) {
				keys[currentKey.name]= e.keyCode;
				currentKey.transform.GetChild(0).GetComponent<Text> ().text = e.keyCode.ToString ();
				currentKey.GetComponent<Image> ().color = normal;
				currentKey = null;
			}
		}
	}

	public void ChangeKey(GameObject clicked){
		if (currentKey != null) {
			currentKey.GetComponent<Image> ().color = normal;
		}
		currentKey = clicked;
		currentKey.GetComponent<Image> ().color = selected;


	}

	public void SaveKeys(){
		foreach (var key in keys) {
			PlayerPrefs.SetString (key.Key, key.Value.ToString());

		}

		PlayerPrefs.Save ();
	}

}
