using UnityEngine;
using System.Collections;

public class RestartButton : MonoBehaviour {

	private GUIStyle lostTextLabel;
	private GUIStyle restartButton;
	private float ratio;

	void Start () {
		ratio = (float)Screen.height / 768;
	}

	void Update () {
		if (Input.GetKeyDown(KeyCode.Escape)) 
			Application.Quit(); 
	}

	void OnGUI () {
		lostTextLabel = GUI.skin.GetStyle ("Label");
		lostTextLabel.fontSize = Mathf.RoundToInt(100 * ratio);
		lostTextLabel.alignment = TextAnchor.UpperCenter;

		restartButton = GUI.skin.GetStyle ("button");
		restartButton.fontSize = Mathf.RoundToInt(80 * ratio);

		if (Application.loadedLevelName == "_Restart") {
			GUI.Label (new Rect (Screen.width / 2 - 300 * ratio, Screen.height / 2 - 250 * ratio, 600 * ratio, 150 * ratio), "You lost...", lostTextLabel);

			// Make the first button. If it is pressed, Application.Loadlevel (1) will be executed
			if (GUI.Button (new Rect (Screen.width / 2 - 150 * ratio, Screen.height / 2 - 60 * ratio, 300 * ratio, 120 * ratio), "Restart", restartButton)) {
				Application.LoadLevel ("Level 1");
			}
		}

		if (Application.loadedLevelName == "_Ending") {
			GUI.Label (new Rect (Screen.width / 2 - 400 * ratio, Screen.height / 2 - 250 * ratio, 800 * ratio, 150 * ratio), "Congratulations!", lostTextLabel);
			
			// Make the first button. If it is pressed, Application.Loadlevel (1) will be executed
			if (GUI.Button (new Rect (Screen.width / 2 - 150 * ratio, Screen.height / 2 - 60 * ratio, 300 * ratio, 120 * ratio), "Restart", restartButton)) {
				Application.LoadLevel ("_Start");
			}
		}
	}
}