using UnityEngine;
using System.Collections;

public class LevelSelect1 : MonoBehaviour {
	
	public Texture backgroundTexture;
	public Font customFont;
	public Texture oneStar;
	public Texture twoStars;
	public Texture threeStars;
	public GameObject BGMPrefab;
	
	public GUIStyle levelButton;
	public GUIStyle arrowButton;
	public GUIStyle lockedLevelButton;
	public GUIStyle boxStyle;

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
		int groupWidth = Mathf.RoundToInt(800 * ratio);
		int groupHeight = Mathf.RoundToInt(450 * ratio);
		
		int screenWidth = Screen.width;
		int screenHeight = Screen.height;
		
		int groupX = ( screenWidth - groupWidth ) / 2;
		int groupY = ( screenHeight - groupHeight ) / 2 + Mathf.RoundToInt(70 * ratio);

		levelButton.fontSize = Mathf.RoundToInt (45 * ratio);
		
		titleTextLabel = GUI.skin.GetStyle ("Label");
		titleTextLabel.fontSize = Mathf.RoundToInt(100 * ratio);
		titleTextLabel.alignment = TextAnchor.UpperCenter;
		titleTextLabel.font = customFont;
		titleTextLabel.normal.textColor = Color.black;
		
		GUI.DrawTexture(new Rect(0 * ratio, 0 * ratio, 1700 * ratio, 1500 * ratio), backgroundTexture, ScaleMode.ScaleToFit, true, 1.133333f);

		if (GUI.Button (new Rect (Screen.width - 240 * ratio, 10 * ratio, 230 * ratio, 100 * ratio), "Option", levelButton)) {
			PlayerPrefs.SetString ("Last Scene Before Option", "_Level Select 1");
			Application.LoadLevel ("_Option");
		}

		levelButton.fontSize = Mathf.RoundToInt(80 * ratio);

		GUI.Label (new Rect (Screen.width / 2 - 250 * ratio, 70 * ratio, 500 * ratio, 150 * ratio), "Sky", titleTextLabel);

		GUI.BeginGroup(new Rect( groupX, groupY, groupWidth, groupHeight));
		GUI.Box(new Rect( 0, 0, groupWidth, groupHeight), new GUIContent(""), boxStyle);


		if (GUI.Button (new Rect (groupWidth / 2 - 50 * ratio, groupHeight - 110 * ratio, 100 * ratio, 100 * ratio), "", arrowButton)) {
			PlayerPrefs.SetString ("Last Scene Before Option", "_Level Select 2");
			Application.LoadLevel("_Level Select 2");
		}


		//________LEVEL 1________//
		if (GUI.Button (new Rect (30 * ratio, 30 * ratio, 130 * ratio, 130 * ratio), "1", levelButton)) {
			Application.LoadLevel ("Level 1");
		}

		if (PlayerPrefs.GetInt ("Level 1 High Score") == 3) {
			GUI.DrawTexture (new Rect (50 * ratio, 120 * ratio, 90 * ratio, 30 * ratio), threeStars, ScaleMode.ScaleToFit, true, 3);
		}
		else if (PlayerPrefs.GetInt ("Level 1 High Score") == 2) {
			GUI.DrawTexture (new Rect (50 * ratio, 120 * ratio, 90 * ratio, 30 * ratio), twoStars, ScaleMode.ScaleToFit, true, 3);
		}
		else if (PlayerPrefs.GetInt ("Level 1 High Score") == 1) {
			GUI.DrawTexture (new Rect (50 * ratio, 120 * ratio, 90 * ratio, 30 * ratio), oneStar, ScaleMode.ScaleToFit, true, 3);
		}

		//________LEVEL 2________//

		if (PlayerPrefs.GetInt ("Level 1 Score") != 0) {
			if (GUI.Button (new Rect (180 * ratio, 30 * ratio, 130 * ratio, 130 * ratio), "2", levelButton)) {
				Application.LoadLevel ("Level 2");
			}
			
			if (PlayerPrefs.GetInt ("Level 2 High Score") == 3) {
				GUI.DrawTexture (new Rect (200 * ratio, 120 * ratio, 90 * ratio, 30 * ratio), threeStars, ScaleMode.ScaleToFit, true, 3);
			}
			else if (PlayerPrefs.GetInt ("Level 2 High Score") == 2) {
				GUI.DrawTexture (new Rect (200 * ratio, 120 * ratio, 90 * ratio, 30 * ratio), twoStars, ScaleMode.ScaleToFit, true, 3);
			}
			else if (PlayerPrefs.GetInt ("Level 2 High Score") == 1) {
				GUI.DrawTexture (new Rect (200 * ratio, 120 * ratio, 90 * ratio, 30 * ratio), oneStar, ScaleMode.ScaleToFit, true, 3);
			}
		}
		
		else if (PlayerPrefs.GetInt ("Level 1 Score") == 0) {
			GUI.Button (new Rect (180 * ratio, 30 * ratio, 130 * ratio, 130 * ratio), "", lockedLevelButton);
		}

		//________LEVEL 3________//

		if (PlayerPrefs.GetInt ("Level 2 Score") != 0) {
			if (GUI.Button (new Rect (330 * ratio, 30 * ratio, 130 * ratio, 130 * ratio), "3", levelButton)) {
				Application.LoadLevel ("Level 3");
			}
			
			if (PlayerPrefs.GetInt ("Level 3 High Score") == 3) {
				GUI.DrawTexture (new Rect (350 * ratio, 120 * ratio, 90 * ratio, 30 * ratio), threeStars, ScaleMode.ScaleToFit, true, 3);
			}
			else if (PlayerPrefs.GetInt ("Level 3 High Score") == 2) {
				GUI.DrawTexture (new Rect (350 * ratio, 120 * ratio, 90 * ratio, 30 * ratio), twoStars, ScaleMode.ScaleToFit, true, 3);
			}
			else if (PlayerPrefs.GetInt ("Level 3 High Score") == 1) {
				GUI.DrawTexture (new Rect (350 * ratio, 120 * ratio, 90 * ratio, 30 * ratio), oneStar, ScaleMode.ScaleToFit, true, 3);
			}
		}
		
		else if (PlayerPrefs.GetInt ("Level 2 Score") == 0) {
			GUI.Button (new Rect (330 * ratio, 30 * ratio, 130 * ratio, 130 * ratio), "", lockedLevelButton);
		}

		//________LEVEL 4________//

		if (PlayerPrefs.GetInt ("Level 3 Score") != 0) {
			if (GUI.Button (new Rect (480 * ratio, 30 * ratio, 130 * ratio, 130 * ratio), "4", levelButton)) {
				Application.LoadLevel ("Level 4");
			}
			
			if (PlayerPrefs.GetInt ("Level 4 High Score") == 3) {
				GUI.DrawTexture (new Rect (500 * ratio, 120 * ratio, 90 * ratio, 30 * ratio), threeStars, ScaleMode.ScaleToFit, true, 3);
			}
			else if (PlayerPrefs.GetInt ("Level 4 High Score") == 2) {
				GUI.DrawTexture (new Rect (500 * ratio, 120 * ratio, 90 * ratio, 30 * ratio), twoStars, ScaleMode.ScaleToFit, true, 3);
			}
			else if (PlayerPrefs.GetInt ("Level 4 High Score") == 1) {
				GUI.DrawTexture (new Rect (500 * ratio, 120 * ratio, 90 * ratio, 30 * ratio), oneStar, ScaleMode.ScaleToFit, true, 3);
			}
		}
		
		else if (PlayerPrefs.GetInt ("Level 3 Score") == 0) {
			GUI.Button (new Rect (480 * ratio, 30 * ratio, 130 * ratio, 130 * ratio), "", lockedLevelButton);
		}

		//________LEVEL 5________//

		if (PlayerPrefs.GetInt ("Level 4 Score") != 0) {
			if (GUI.Button (new Rect (630 * ratio, 30 * ratio, 130 * ratio, 130 * ratio), "5", levelButton)) {
				Application.LoadLevel ("Level 5");
			}
			
			if (PlayerPrefs.GetInt ("Level 5 High Score") == 3) {
				GUI.DrawTexture (new Rect (650 * ratio, 120 * ratio, 90 * ratio, 30 * ratio), threeStars, ScaleMode.ScaleToFit, true, 3);
			}
			else if (PlayerPrefs.GetInt ("Level 5 High Score") == 2) {
				GUI.DrawTexture (new Rect (650 * ratio, 120 * ratio, 90 * ratio, 30 * ratio), twoStars, ScaleMode.ScaleToFit, true, 3);
			}
			else if (PlayerPrefs.GetInt ("Level 5 High Score") == 1) {
				GUI.DrawTexture (new Rect (650 * ratio, 120 * ratio, 90 * ratio, 30 * ratio), oneStar, ScaleMode.ScaleToFit, true, 3);
			}
		}
		
		else if (PlayerPrefs.GetInt ("Level 4 Score") == 0) {
			GUI.Button (new Rect (630 * ratio, 30 * ratio, 130 * ratio, 130 * ratio), "", lockedLevelButton);
		}

		//________LEVEL 6________//

		if (PlayerPrefs.GetInt ("Level 5 Score") != 0) {
			if (GUI.Button (new Rect (30 * ratio, 180 * ratio, 130 * ratio, 130 * ratio), "6", levelButton)) {
				Application.LoadLevel ("Level 6");
			}
			
			if (PlayerPrefs.GetInt ("Level 6 High Score") == 3) {
				GUI.DrawTexture (new Rect (50 * ratio, 270 * ratio, 90 * ratio, 30 * ratio), threeStars, ScaleMode.ScaleToFit, true, 3);
			}
			else if (PlayerPrefs.GetInt ("Level 6 High Score") == 2) {
				GUI.DrawTexture (new Rect (50 * ratio, 270 * ratio, 90 * ratio, 30 * ratio), twoStars, ScaleMode.ScaleToFit, true, 3);
			}
			else if (PlayerPrefs.GetInt ("Level 6 High Score") == 1) {
				GUI.DrawTexture (new Rect (50 * ratio, 270 * ratio, 90 * ratio, 30 * ratio), oneStar, ScaleMode.ScaleToFit, true, 3);
			}
		}
		
		else if (PlayerPrefs.GetInt ("Level 5 Score") == 0) {
			GUI.Button (new Rect (30 * ratio, 180 * ratio, 130 * ratio, 130 * ratio), "", lockedLevelButton);
		}

		//________LEVEL 7________//
		
		if (PlayerPrefs.GetInt ("Level 6 Score") != 0) {
			if (GUI.Button (new Rect (180 * ratio, 180 * ratio, 130 * ratio, 130 * ratio), "7", levelButton)) {
				Application.LoadLevel ("Level 7");
			}
			
			if (PlayerPrefs.GetInt ("Level 7 High Score") == 3) {
				GUI.DrawTexture (new Rect (200 * ratio, 270 * ratio, 90 * ratio, 30 * ratio), threeStars, ScaleMode.ScaleToFit, true, 3);
			}
			else if (PlayerPrefs.GetInt ("Level 7 High Score") == 2) {
				GUI.DrawTexture (new Rect (200 * ratio, 270 * ratio, 90 * ratio, 30 * ratio), twoStars, ScaleMode.ScaleToFit, true, 3);
			}
			else if (PlayerPrefs.GetInt ("Level 7 High Score") == 1) {
				GUI.DrawTexture (new Rect (200 * ratio, 270 * ratio, 90 * ratio, 30 * ratio), oneStar, ScaleMode.ScaleToFit, true, 3);
			}
		}
		
		else if (PlayerPrefs.GetInt ("Level 6 Score") == 0) {
			GUI.Button (new Rect (180 * ratio, 180 * ratio, 130 * ratio, 130 * ratio), "", lockedLevelButton);
		}

		//________LEVEL 8________//
		
		if (PlayerPrefs.GetInt ("Level 7 Score") != 0) {
			if (GUI.Button (new Rect (330 * ratio, 180 * ratio, 130 * ratio, 130 * ratio), "8", levelButton)) {
				Application.LoadLevel ("Level 8");
			}
			
			if (PlayerPrefs.GetInt ("Level 8 High Score") == 3) {
				GUI.DrawTexture (new Rect (350 * ratio, 270 * ratio, 90 * ratio, 30 * ratio), threeStars, ScaleMode.ScaleToFit, true, 3);
			}
			else if (PlayerPrefs.GetInt ("Level 8 High Score") == 2) {
				GUI.DrawTexture (new Rect (350 * ratio, 270 * ratio, 90 * ratio, 30 * ratio), twoStars, ScaleMode.ScaleToFit, true, 3);
			}
			else if (PlayerPrefs.GetInt ("Level 8 High Score") == 1) {
				GUI.DrawTexture (new Rect (350 * ratio, 270 * ratio, 90 * ratio, 30 * ratio), oneStar, ScaleMode.ScaleToFit, true, 3);
			}
		}
		
		else if (PlayerPrefs.GetInt ("Level 7 Score") == 0) {
			GUI.Button (new Rect (330 * ratio, 180 * ratio, 130 * ratio, 130 * ratio), "", lockedLevelButton);
		}

		//________LEVEL 9________//
		
		if (PlayerPrefs.GetInt ("Level 8 Score") != 0) {
			if (GUI.Button (new Rect (480 * ratio, 180 * ratio, 130 * ratio, 130 * ratio), "9", levelButton)) {
				Application.LoadLevel ("Level 9");
			}
			
			if (PlayerPrefs.GetInt ("Level 9 High Score") == 3) {
				GUI.DrawTexture (new Rect (500 * ratio, 270 * ratio, 90 * ratio, 30 * ratio), threeStars, ScaleMode.ScaleToFit, true, 3);
			}
			else if (PlayerPrefs.GetInt ("Level 9 High Score") == 2) {
				GUI.DrawTexture (new Rect (500 * ratio, 270 * ratio, 90 * ratio, 30 * ratio), twoStars, ScaleMode.ScaleToFit, true, 3);
			}
			else if (PlayerPrefs.GetInt ("Level 9 High Score") == 1) {
				GUI.DrawTexture (new Rect (500 * ratio, 270 * ratio, 90 * ratio, 30 * ratio), oneStar, ScaleMode.ScaleToFit, true, 3);
			}
		}
		
		else if (PlayerPrefs.GetInt ("Level 8 Score") == 0) {
			GUI.Button (new Rect (480 * ratio, 180 * ratio, 130 * ratio, 130 * ratio), "", lockedLevelButton);
		}

		//________LEVEL 10________//

		if (PlayerPrefs.GetInt ("Level 9 Score") != 0) {
			if (GUI.Button (new Rect (630 * ratio, 180 * ratio, 130 * ratio, 130 * ratio), "10", levelButton)) {
				Application.LoadLevel ("Level 10");
			}
			
			if (PlayerPrefs.GetInt ("Level 10 High Score") == 3) {
				GUI.DrawTexture (new Rect (650 * ratio, 270 * ratio, 90 * ratio, 30 * ratio), threeStars, ScaleMode.ScaleToFit, true, 3);
			}
			else if (PlayerPrefs.GetInt ("Level 10 High Score") == 2) {
				GUI.DrawTexture (new Rect (650 * ratio, 270 * ratio, 90 * ratio, 30 * ratio), twoStars, ScaleMode.ScaleToFit, true, 3);
			}
			else if (PlayerPrefs.GetInt ("Level 10 High Score") == 1) {
				GUI.DrawTexture (new Rect (650 * ratio, 270 * ratio, 90 * ratio, 30 * ratio), oneStar, ScaleMode.ScaleToFit, true, 3);
			}
		}
		
		else if (PlayerPrefs.GetInt ("Level 9 Score") == 0) {
			GUI.Button (new Rect (630 * ratio, 180 * ratio, 130 * ratio, 130 * ratio), "", lockedLevelButton);
		}

		GUI.EndClip ();
	}
}