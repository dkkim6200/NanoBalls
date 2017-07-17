using UnityEngine;
using System.Collections;

public class QuitButton : MonoBehaviour {

	private GUIStyle quitButton;
	private float ratio = Screen.width / 1235.0f;
	private bool isDevicePC;

	// Use this for initialization
	void Start () {

		if (Application.platform == RuntimePlatform.IPhonePlayer || Application.platform == RuntimePlatform.Android || Application.platform == RuntimePlatform.OSXWebPlayer || Application.platform == RuntimePlatform.WindowsWebPlayer) {
			isDevicePC = false;
		}

		else {
			isDevicePC = true;
		}
	}

	void OnGUI () {
		quitButton = GUI.skin.GetStyle ("button");
		quitButton.fontSize = Mathf.RoundToInt(50 * ratio);
		
		if (isDevicePC)
		{
			if (GUI.Button (new Rect (Screen.width - 140 * ratio, 10 * ratio, 130 * ratio, 60 * ratio), "Quit", quitButton)) {
				Application.Quit();
			}
		}
	}
}