using UnityEngine;
using System.Collections;

public class Lost : MonoBehaviour {
	
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
		restartButton.fontSize = Mathf.RoundToInt(80 * ratio);
		
		titleTextLabel = GUI.skin.GetStyle ("Label");
		titleTextLabel.fontSize = Mathf.RoundToInt(150 * ratio);
		titleTextLabel.alignment = TextAnchor.UpperCenter;
		titleTextLabel.font = customFont;
		titleTextLabel.normal.textColor = Color.black;
		
		GUI.DrawTexture(new Rect(0 * ratio, 0 * ratio, 1700 * ratio, 1500 * ratio), backgroundTexture, ScaleMode.ScaleToFit, true, 1.133333f);
		
		GUI.Label (new Rect (Screen.width / 2 - 400 * ratio, Screen.height / 2 - 170 * ratio, 800 * ratio, 150 * ratio), "You Lost...", titleTextLabel);
		
		if (GUI.Button (new Rect (Screen.width / 2 - 150 * ratio, Screen.height / 2 - 10 * ratio, 300 * ratio, 150 * ratio), "Menu", restartButton)) {
			Application.LoadLevel (PlayerPrefs.GetString ("Last Scene Before Option"));
		}
	}
}