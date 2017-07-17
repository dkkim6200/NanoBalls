using UnityEngine;
using System.Collections;

public class Option : MonoBehaviour {
	
	public Texture backgroundTexture;
	public Font customFont;
	
	public GUIStyle restartButton;
	private GUIStyle titleTextLabel;
	private float ratio;

	void Start () {
		ratio = (float)Screen.height / 768;
	}
	
	void OnGUI () {
		//restartButton = GUI.skin.GetStyle ("button");
		restartButton.fontSize = Mathf.RoundToInt(50 * ratio);
		
		titleTextLabel = GUI.skin.GetStyle ("Label");
		titleTextLabel.fontSize = Mathf.RoundToInt(120 * ratio);
		titleTextLabel.alignment = TextAnchor.UpperCenter;
		titleTextLabel.font = customFont;
		titleTextLabel.normal.textColor = Color.black;
		
		GUI.DrawTexture(new Rect(0 * ratio, 0 * ratio, 1700 * ratio, 1500 * ratio), backgroundTexture, ScaleMode.ScaleToFit, true, 1.133333f);
		
		GUI.Label (new Rect (Screen.width / 2 - 250 * ratio, 70 * ratio, 500 * ratio, 150 * ratio), "Option", titleTextLabel);

		if (PlayerPrefs.GetInt ("Mute") == 0) {
			if (GUI.Button (new Rect (Screen.width / 2 - 190 * ratio, Screen.height / 2 - 120 * ratio, 380 * ratio, 100 * ratio), "O Play Music", restartButton)) {
				PlayerPrefs.SetInt("Mute", 1);
			}
		}

		if (PlayerPrefs.GetInt ("Mute") == 1) {
			if (GUI.Button (new Rect (Screen.width / 2 - 190 * ratio, Screen.height / 2 - 120 * ratio, 380 * ratio, 100 * ratio), "X Play Music", restartButton)) {
				PlayerPrefs.SetInt("Mute", 0);
			}
		}

		if (GUI.Button (new Rect (Screen.width / 2 - 240 * ratio, Screen.height / 2 + 10 * ratio, 480 * ratio, 100 * ratio), "Remove Records", restartButton)) {
			for (int i = 1; i <= 20; i++) {
				PlayerPrefs.DeleteKey("Level " + i + " Score");
				PlayerPrefs.DeleteKey("Level " + i +" High Score");
			}
		}

		if (GUI.Button (new Rect (Screen.width / 2 - 240 * ratio, Screen.height - 140 * ratio, 480 * ratio, 100 * ratio), "Save and Return", restartButton)) {
			Application.LoadLevel(PlayerPrefs.GetString ("Last Scene Before Option"));
		}
	}
}