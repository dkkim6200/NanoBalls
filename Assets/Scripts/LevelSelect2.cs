using UnityEngine;
using System.Collections;

public class LevelSelect2 : MonoBehaviour {
	
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

		levelButton.fontSize = Mathf.RoundToInt(45 * ratio);
		//arrowButton.fontSize = Mathf.RoundToInt (50 * ratio);
		
		titleTextLabel = GUI.skin.GetStyle ("Label");
		titleTextLabel.fontSize = Mathf.RoundToInt(100 * ratio);
		titleTextLabel.alignment = TextAnchor.UpperCenter;
		titleTextLabel.font = customFont;
		titleTextLabel.normal.textColor = Color.black;

		/*
		if (GUI.Button (new Rect (10 * ratio, 10 * ratio, 50 * ratio, 50 * ratio), "", levelButton)) {
			PlayerPrefs.SetInt ("Level 1 Score", 3);
			PlayerPrefs.SetInt ("Level 1 High Score", 3);
			PlayerPrefs.SetInt ("Level 2 Score", 3);
			PlayerPrefs.SetInt ("Level 2 High Score", 3);
			PlayerPrefs.SetInt ("Level 3 Score", 3);
			PlayerPrefs.SetInt ("Level 3 High Score", 3);
			PlayerPrefs.SetInt ("Level 4 Score", 3);
			PlayerPrefs.SetInt ("Level 4 High Score", 3);
			PlayerPrefs.SetInt ("Level 5 Score", 3);
			PlayerPrefs.SetInt ("Level 5 High Score", 3);
			PlayerPrefs.SetInt ("Level 6 Score", 3);
			PlayerPrefs.SetInt ("Level 6 High Score", 3);
			PlayerPrefs.SetInt ("Level 7 Score", 3);
			PlayerPrefs.SetInt ("Level 7 High Score", 3);
			PlayerPrefs.SetInt ("Level 8 Score", 3);
			PlayerPrefs.SetInt ("Level 8 High Score", 3);
			PlayerPrefs.SetInt ("Level 9 Score", 3);
			PlayerPrefs.SetInt ("Level 9 High Score", 3);
			PlayerPrefs.SetInt ("Level 10 Score", 3);
			PlayerPrefs.SetInt ("Level 10 High Score", 3);
			PlayerPrefs.SetInt ("Level 11 Score", 3);
			PlayerPrefs.SetInt ("Level 11 High Score", 3);
			PlayerPrefs.SetInt ("Level 12 Score", 3);
			PlayerPrefs.SetInt ("Level 12 High Score", 3);
			PlayerPrefs.SetInt ("Level 13 Score", 3);
			PlayerPrefs.SetInt ("Level 13 High Score", 3);
			PlayerPrefs.SetInt ("Level 14 Score", 3);
			PlayerPrefs.SetInt ("Level 14 High Score", 3);
			PlayerPrefs.SetInt ("Level 15 Score", 3);
			PlayerPrefs.SetInt ("Level 15 High Score", 3);
			PlayerPrefs.SetInt ("Level 16 Score", 3);
			PlayerPrefs.SetInt ("Level 16 High Score", 3);
			PlayerPrefs.SetInt ("Level 17 Score", 3);
			PlayerPrefs.SetInt ("Level 17 High Score", 3);
			PlayerPrefs.SetInt ("Level 18 Score", 3);
			PlayerPrefs.SetInt ("Level 18 High Score", 3);
			PlayerPrefs.SetInt ("Level 19 Score", 3);
			PlayerPrefs.SetInt ("Level 19 High Score", 3);
			PlayerPrefs.SetInt ("Level 20 Score", 3);
			PlayerPrefs.SetInt ("Level 20 High Score", 3);
		}
		*/

		
		GUI.DrawTexture(new Rect(0 * ratio, 0 * ratio, 1700 * ratio, 1500 * ratio), backgroundTexture, ScaleMode.ScaleToFit, true, 1.133333f);

		if (GUI.Button (new Rect (Screen.width - 240 * ratio, 10 * ratio, 230 * ratio, 100 * ratio), "Option", levelButton)) {
			PlayerPrefs.SetString ("Last Scene Before Option", "_Level Select 2");
			Application.LoadLevel ("_Option");
		}

		levelButton.fontSize = Mathf.RoundToInt(80 * ratio);

		GUI.Label (new Rect (Screen.width / 2 - 250 * ratio, 70 * ratio, 500 * ratio, 150 * ratio), "Ground", titleTextLabel);

		GUI.BeginGroup(new Rect( groupX, groupY, groupWidth, groupHeight));
		GUI.Box(new Rect( 0, 0, groupWidth, groupHeight), new GUIContent(""), boxStyle);


		if (GUI.Button (new Rect (groupWidth / 2 - 50 * ratio, groupHeight - 110 * ratio, 100 * ratio, 100 * ratio), "", arrowButton)) {
			PlayerPrefs.SetString ("Last Scene Before Option", "_Level Select 1");
			Application.LoadLevel("_Level Select 1");
		}

		//________LEVEL 11________//
		if (PlayerPrefs.GetInt ("Level 10 Score") != 0) {
			if (GUI.Button (new Rect (30 * ratio, 30 * ratio, 130 * ratio, 130 * ratio), "11", levelButton)) {
				Application.LoadLevel ("Level 11");
			}
			
			if (PlayerPrefs.GetInt ("Level 11 High Score") == 3) {
				GUI.DrawTexture (new Rect (50 * ratio, 120 * ratio, 90 * ratio, 30 * ratio), threeStars, ScaleMode.ScaleToFit, true, 3);
			}
			else if (PlayerPrefs.GetInt ("Level 11 High Score") == 2) {
				GUI.DrawTexture (new Rect (50 * ratio, 120 * ratio, 90 * ratio, 30 * ratio), twoStars, ScaleMode.ScaleToFit, true, 3);
			}
			else if (PlayerPrefs.GetInt ("Level 11 High Score") == 1) {
				GUI.DrawTexture (new Rect (50 * ratio, 120 * ratio, 90 * ratio, 30 * ratio), oneStar, ScaleMode.ScaleToFit, true, 3);
			}
		}
		else if (PlayerPrefs.GetInt ("Level 10 Score") == 0) {
			GUI.Button (new Rect (30 * ratio, 30 * ratio, 130 * ratio, 130 * ratio), "", lockedLevelButton);
		}

		//________LEVEL 12________//

		if (PlayerPrefs.GetInt ("Level 11 Score") != 0) {
			if (GUI.Button (new Rect (180 * ratio, 30 * ratio, 130 * ratio, 130 * ratio), "12", levelButton)) {
				Application.LoadLevel ("Level 12");
			}
			
			if (PlayerPrefs.GetInt ("Level 12 High Score") == 3) {
				GUI.DrawTexture (new Rect (200 * ratio, 120 * ratio, 90 * ratio, 30 * ratio), threeStars, ScaleMode.ScaleToFit, true, 3);
			}
			else if (PlayerPrefs.GetInt ("Level 12 High Score") == 2) {
				GUI.DrawTexture (new Rect (200 * ratio, 120 * ratio, 90 * ratio, 30 * ratio), twoStars, ScaleMode.ScaleToFit, true, 3);
			}
			else if (PlayerPrefs.GetInt ("Level 12 High Score") == 1) {
				GUI.DrawTexture (new Rect (200 * ratio, 120 * ratio, 90 * ratio, 30 * ratio), oneStar, ScaleMode.ScaleToFit, true, 3);
			}
		}
		else if (PlayerPrefs.GetInt ("Level 11 Score") == 0) {
			GUI.Button (new Rect (180 * ratio, 30 * ratio, 130 * ratio, 130 * ratio), "", lockedLevelButton);
		}

		//________LEVEL 13________//

		if (PlayerPrefs.GetInt ("Level 12 Score") != 0) {
			if (GUI.Button (new Rect (330 * ratio, 30 * ratio, 130 * ratio, 130 * ratio), "13", levelButton)) {
				Application.LoadLevel ("Level 13");
			}
			
			if (PlayerPrefs.GetInt ("Level 13 High Score") == 3) {
				GUI.DrawTexture (new Rect (350 * ratio, 120 * ratio, 90 * ratio, 30 * ratio), threeStars, ScaleMode.ScaleToFit, true, 3);
			}
			else if (PlayerPrefs.GetInt ("Level 13 High Score") == 2) {
				GUI.DrawTexture (new Rect (350 * ratio, 120 * ratio, 90 * ratio, 30 * ratio), twoStars, ScaleMode.ScaleToFit, true, 3);
			}
			else if (PlayerPrefs.GetInt ("Level 13 High Score") == 1) {
				GUI.DrawTexture (new Rect (350 * ratio, 120 * ratio, 90 * ratio, 30 * ratio), oneStar, ScaleMode.ScaleToFit, true, 3);
			}
		}
		else if (PlayerPrefs.GetInt ("Level 12 Score") == 0) {
			GUI.Button (new Rect (330 * ratio, 30 * ratio, 130 * ratio, 130 * ratio), "", lockedLevelButton);
		}

		//________LEVEL 14________//

		if (PlayerPrefs.GetInt ("Level 13 Score") != 0) {
			if (GUI.Button (new Rect (480 * ratio, 30 * ratio, 130 * ratio, 130 * ratio), "14", levelButton)) {
				Application.LoadLevel ("Level 14");
			}
			
			if (PlayerPrefs.GetInt ("Level 14 High Score") == 3) {
				GUI.DrawTexture (new Rect (500 * ratio, 120 * ratio, 90 * ratio, 30 * ratio), threeStars, ScaleMode.ScaleToFit, true, 3);
			}
			else if (PlayerPrefs.GetInt ("Level 14 High Score") == 2) {
				GUI.DrawTexture (new Rect (500 * ratio, 120 * ratio, 90 * ratio, 30 * ratio), twoStars, ScaleMode.ScaleToFit, true, 3);
			}
			else if (PlayerPrefs.GetInt ("Level 14 High Score") == 1) {
				GUI.DrawTexture (new Rect (500 * ratio, 120 * ratio, 90 * ratio, 30 * ratio), oneStar, ScaleMode.ScaleToFit, true, 3);
			}
		}
		else if (PlayerPrefs.GetInt ("Level 13 Score") == 0) {
			GUI.Button (new Rect (480 * ratio, 30 * ratio, 130 * ratio, 130 * ratio), "", lockedLevelButton);
		}

		//________LEVEL 15________//

		if (PlayerPrefs.GetInt ("Level 14 Score") != 0) {
			if (GUI.Button (new Rect (630 * ratio, 30 * ratio, 130 * ratio, 130 * ratio), "15", levelButton)) {
				Application.LoadLevel ("Level 15");
			}
			
			if (PlayerPrefs.GetInt ("Level 15 High Score") == 3) {
				GUI.DrawTexture (new Rect (650 * ratio, 120 * ratio, 90 * ratio, 30 * ratio), threeStars, ScaleMode.ScaleToFit, true, 3);
			}
			else if (PlayerPrefs.GetInt ("Level 15 High Score") == 2) {
				GUI.DrawTexture (new Rect (650 * ratio, 120 * ratio, 90 * ratio, 30 * ratio), twoStars, ScaleMode.ScaleToFit, true, 3);
			}
			else if (PlayerPrefs.GetInt ("Level 15 High Score") == 1) {
				GUI.DrawTexture (new Rect (650 * ratio, 120 * ratio, 90 * ratio, 30 * ratio), oneStar, ScaleMode.ScaleToFit, true, 3);
			}
		}
		else if (PlayerPrefs.GetInt ("Level 14 Score") == 0) {
			GUI.Button (new Rect (630 * ratio, 30 * ratio, 130 * ratio, 130 * ratio), "", lockedLevelButton);
		}

		//________LEVEL 16________//

		if (PlayerPrefs.GetInt ("Level 15 Score") != 0) {
			if (GUI.Button (new Rect (30 * ratio, 180 * ratio, 130 * ratio, 130 * ratio), "16", levelButton)) {
				Application.LoadLevel ("Level 16");
			}
			
			if (PlayerPrefs.GetInt ("Level 16 High Score") == 3) {
				GUI.DrawTexture (new Rect (50 * ratio, 270 * ratio, 90 * ratio, 30 * ratio), threeStars, ScaleMode.ScaleToFit, true, 3);
			}
			else if (PlayerPrefs.GetInt ("Level 16 High Score") == 2) {
				GUI.DrawTexture (new Rect (50 * ratio, 270 * ratio, 90 * ratio, 30 * ratio), twoStars, ScaleMode.ScaleToFit, true, 3);
			}
			else if (PlayerPrefs.GetInt ("Level 16 High Score") == 1) {
				GUI.DrawTexture (new Rect (50 * ratio, 270 * ratio, 90 * ratio, 30 * ratio), oneStar, ScaleMode.ScaleToFit, true, 3);
			}
		}
		else if (PlayerPrefs.GetInt ("Level 15 Score") == 0) {
			GUI.Button (new Rect (30 * ratio, 180 * ratio, 130 * ratio, 130 * ratio), "", lockedLevelButton);
		}

		//________LEVEL 17________//
		
		if (PlayerPrefs.GetInt ("Level 16 Score") != 0) {
			if (GUI.Button (new Rect (180 * ratio, 180 * ratio, 130 * ratio, 130 * ratio), "17", levelButton)) {
				Application.LoadLevel ("Level 17");
			}
			
			if (PlayerPrefs.GetInt ("Level 17 High Score") == 3) {
				GUI.DrawTexture (new Rect (200 * ratio, 270 * ratio, 90 * ratio, 30 * ratio), threeStars, ScaleMode.ScaleToFit, true, 3);
			}
			else if (PlayerPrefs.GetInt ("Level 17 High Score") == 2) {
				GUI.DrawTexture (new Rect (200 * ratio, 270 * ratio, 90 * ratio, 30 * ratio), twoStars, ScaleMode.ScaleToFit, true, 3);
			}
			else if (PlayerPrefs.GetInt ("Level 17 High Score") == 1) {
				GUI.DrawTexture (new Rect (200 * ratio, 270 * ratio, 90 * ratio, 30 * ratio), oneStar, ScaleMode.ScaleToFit, true, 3);
			}
		}
		else if (PlayerPrefs.GetInt ("Level 16 Score") == 0) {
			GUI.Button (new Rect (180 * ratio, 180 * ratio, 130 * ratio, 130 * ratio), "", lockedLevelButton);
		}

		//________LEVEL 18________//
		
		if (PlayerPrefs.GetInt ("Level 17 Score") != 0) {
			if (GUI.Button (new Rect (330 * ratio, 180 * ratio, 130 * ratio, 130 * ratio), "18", levelButton)) {
				Application.LoadLevel ("Level 18");
			}
			
			if (PlayerPrefs.GetInt ("Level 18 High Score") == 3) {
				GUI.DrawTexture (new Rect (350 * ratio, 270 * ratio, 90 * ratio, 30 * ratio), threeStars, ScaleMode.ScaleToFit, true, 3);
			}
			else if (PlayerPrefs.GetInt ("Level 18 High Score") == 2) {
				GUI.DrawTexture (new Rect (350 * ratio, 270 * ratio, 90 * ratio, 30 * ratio), twoStars, ScaleMode.ScaleToFit, true, 3);
			}
			else if (PlayerPrefs.GetInt ("Level 18 High Score") == 1) {
				GUI.DrawTexture (new Rect (350 * ratio, 270 * ratio, 90 * ratio, 30 * ratio), oneStar, ScaleMode.ScaleToFit, true, 3);
			}
		}
		else if (PlayerPrefs.GetInt ("Level 17 Score") == 0) {
			GUI.Button (new Rect (330 * ratio, 180 * ratio, 130 * ratio, 130 * ratio), "", lockedLevelButton);
		}

		//________LEVEL 19________//
		
		if (PlayerPrefs.GetInt ("Level 18 Score") != 0) {
			if (GUI.Button (new Rect (480 * ratio, 180 * ratio, 130 * ratio, 130 * ratio), "19", levelButton)) {
				Application.LoadLevel ("Level 19");
			}
			
			if (PlayerPrefs.GetInt ("Level 19 High Score") == 3) {
				GUI.DrawTexture (new Rect (500 * ratio, 270 * ratio, 90 * ratio, 30 * ratio), threeStars, ScaleMode.ScaleToFit, true, 3);
			}
			else if (PlayerPrefs.GetInt ("Level 19 High Score") == 2) {
				GUI.DrawTexture (new Rect (500 * ratio, 270 * ratio, 90 * ratio, 30 * ratio), twoStars, ScaleMode.ScaleToFit, true, 3);
			}
			else if (PlayerPrefs.GetInt ("Level 19 High Score") == 1) {
				GUI.DrawTexture (new Rect (500 * ratio, 270 * ratio, 90 * ratio, 30 * ratio), oneStar, ScaleMode.ScaleToFit, true, 3);
			}
		}
		else if (PlayerPrefs.GetInt ("Level 18 Score") == 0) {
			GUI.Button (new Rect (480 * ratio, 180 * ratio, 130 * ratio, 130 * ratio), "", lockedLevelButton);
		}

		//________LEVEL 20________//

		if (PlayerPrefs.GetInt ("Level 19 Score") != 0) {
			if (GUI.Button (new Rect (630 * ratio, 180 * ratio, 130 * ratio, 130 * ratio), "20", levelButton)) {
				Application.LoadLevel ("Level 20");
			}
			
			if (PlayerPrefs.GetInt ("Level 20 High Score") == 3) {
				GUI.DrawTexture (new Rect (650 * ratio, 270 * ratio, 90 * ratio, 30 * ratio), threeStars, ScaleMode.ScaleToFit, true, 3);
			}
			else if (PlayerPrefs.GetInt ("Level 20 High Score") == 2) {
				GUI.DrawTexture (new Rect (650 * ratio, 270 * ratio, 90 * ratio, 30 * ratio), twoStars, ScaleMode.ScaleToFit, true, 3);
			}
			else if (PlayerPrefs.GetInt ("Level 20 High Score") == 1) {
				GUI.DrawTexture (new Rect (650 * ratio, 270 * ratio, 90 * ratio, 30 * ratio), oneStar, ScaleMode.ScaleToFit, true, 3);
			}
		}
		else if (PlayerPrefs.GetInt ("Level 19 Score") == 0) {
			GUI.Button (new Rect (630 * ratio, 180 * ratio, 130 * ratio, 130 * ratio), "", lockedLevelButton);
		}

		GUI.EndClip ();
	}
}