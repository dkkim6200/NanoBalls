using UnityEngine;
using System.Collections;

public class StartButton : MonoBehaviour {
	
	public Texture backgroundTexture;
	public Font customFont;
	public GameObject BGMPrefab;
	
	public GUIStyle restartButton;
	private GUIStyle titleTextLabel;
	private float ratio;

	void Start () {
		ratio = (float)Screen.height / 768;
		if (GameObject.Find ("BGM") == null) {
			GameObject clone = Instantiate(BGMPrefab) as GameObject;
			clone.name = "BGM";
		}
	}

	void Update () {
		if (Input.GetKeyDown(KeyCode.Escape)) 
			Application.Quit(); 
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
		
		GUI.Label (new Rect (Screen.width / 2 - 450 * ratio, Screen.height / 2 - 170 * ratio, 900 * ratio, 150 * ratio), "Nano Balls", titleTextLabel);
		
		if (GUI.Button (new Rect (Screen.width / 2 - 150 * ratio, Screen.height / 2 - 10 * ratio, 300 * ratio, 150 * ratio), "Start", restartButton)) {
			PlayerPrefs.SetString ("Last Scene Before Option", "_Level Select 1");
			Application.LoadLevel ("_Level Select 1");
		}

		restartButton.fontSize = Mathf.RoundToInt(40 * ratio);

		if (GUI.Button (new Rect (Screen.width / 2 - 125 * ratio, Screen.height / 2 + 150 * ratio, 250 * ratio, 90 * ratio), "Option", restartButton)) {
			PlayerPrefs.SetString ("Last Scene Before Option", "_Start");
			Application.LoadLevel ("_Option");
		}
	}
}