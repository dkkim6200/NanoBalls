using UnityEngine;
using System.Collections;

public class LevelEnd : MonoBehaviour {
	
	public Texture backgroundTexture;
	public Font customFont;
	public string levelScoreName;
	public Texture oneStar;
	public Texture twoStars;
	public Texture threeStars;
	
	public GUIStyle restartButton;
	private GUIStyle titleTextLabel;
	private float ratio;

	void Start () {
		ratio = (float)Screen.height / 768;
	}

	void Update () {
		if (Input.GetKeyDown(KeyCode.Escape)) 
			Application.Quit(); 
	}
	
	void OnGUI () {
		//restartButton = GUI.skin.GetStyle ("button");
		restartButton.fontSize = Mathf.RoundToInt(80 * ratio);
		
		titleTextLabel = GUI.skin.GetStyle ("Label");
		titleTextLabel.fontSize = Mathf.RoundToInt(50 * ratio);
		titleTextLabel.alignment = TextAnchor.UpperCenter;
		titleTextLabel.font = customFont;
		titleTextLabel.normal.textColor = Color.black;
		
		GUI.DrawTexture(new Rect(0 * ratio, 0 * ratio, 1700 * ratio, 1500 * ratio), backgroundTexture, ScaleMode.ScaleToFit, true, 1.133333f);

		if (PlayerPrefs.GetInt (levelScoreName) == 3) {
			GUI.DrawTexture(new Rect(Screen.width / 2 - 300 * ratio, Screen.height / 2 - 200 * ratio, 600 * ratio, 100 * ratio), threeStars, ScaleMode.ScaleToFit, true, 3);
			GUI.Label (new Rect (Screen.width / 2 - 500 * ratio, Screen.height / 2 - 80 * ratio, 1000 * ratio, 150 * ratio), "Excellent!", titleTextLabel);
		}

		if (PlayerPrefs.GetInt (levelScoreName) == 2) {
			GUI.DrawTexture(new Rect(Screen.width / 2 - 300 * ratio, Screen.height / 2 - 200 * ratio, 600 * ratio, 100 * ratio), twoStars, ScaleMode.ScaleToFit, true, 3);
			GUI.Label (new Rect (Screen.width / 2 - 500 * ratio, Screen.height / 2 - 80 * ratio, 1000 * ratio, 150 * ratio), "Good!", titleTextLabel);
		}

		if (PlayerPrefs.GetInt (levelScoreName) == 1) {
			GUI.DrawTexture(new Rect(Screen.width / 2 - 300 * ratio, Screen.height / 2 - 200 * ratio, 600 * ratio, 100 * ratio), oneStar, ScaleMode.ScaleToFit, true, 3);
			GUI.Label (new Rect (Screen.width / 2 - 500 * ratio, Screen.height / 2 - 80 * ratio, 1000 * ratio, 150 * ratio), "Umm... At least you passed...", titleTextLabel);
		}
		
		if (GUI.Button (new Rect (Screen.width / 2 - 150 * ratio, Screen.height / 2 - 10 * ratio, 300 * ratio, 150 * ratio), "Menu", restartButton)) {
			Application.LoadLevel (PlayerPrefs.GetString ("Last Scene Before Option"));
		}
	}
}