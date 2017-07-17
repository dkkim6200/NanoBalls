using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerController : MonoBehaviour {

	private string playerDevice;

	public float speed;
	public int goal;
	public float scoreLimit;
	public float timeCount;
	public GameObject player;

	private float ratio;
	private string timeCountText;
	private string winText;
	private GUIStyle timeCountLabel;
	private GUIStyle winTextLabel;
	private Rigidbody rb;
	private int count;
	private Vector3 touchDeltaPosition;
	private bool finish = false;
	private bool state = true;
	private int currentLevel = 1;
	private float moveHorizontal;
	private float moveVertical;

	void Start ()
	{
		PlayerPrefs.SetInt("Win?", 0);
		ratio = (float)Screen.height / 768;

		if (Application.platform == RuntimePlatform.WindowsPlayer || Application.platform == RuntimePlatform.OSXPlayer || Application.platform == RuntimePlatform.LinuxPlayer || Application.platform == RuntimePlatform.OSXEditor || Application.platform == RuntimePlatform.OSXWebPlayer || Application.platform == RuntimePlatform.WindowsWebPlayer) {
			playerDevice = "PC";
		}

		if (Application.platform == RuntimePlatform.IPhonePlayer) {
			playerDevice = "Portable Device";
		}

		if (Application.platform == RuntimePlatform.Android) {
			playerDevice = "Portable Device";
		}
		rb = GetComponent<Rigidbody>();
		count = 0;
		SetCountText ();
		winText = "";
		
		if (Application.loadedLevelName == "_Start")
		{
			winText = "Roll your ball";
			timeCountText = "";
		}
	}
	
	void Update ()
	{
		if (Input.GetKeyDown(KeyCode.Escape)) 
			Application.Quit();

		if (state)
		{
			timeCount = timeCount - Time.deltaTime;
			timeCountText = "Time Left : " + timeCount.ToString ("F1");
		}
		
		if (timeCount <= 0 && finish == false)
		{
			state = false;
			currentLevel = 1;
			Application.LoadLevel ("_Lost");
		}
		
		if (player.transform.position.y <= -5 && finish == false)
		{
			state = false;
			currentLevel = 1;
			Application.LoadLevel ("_Lost");
		}
	}
	
	void FixedUpdate ()
	{

		if (playerDevice == "PC") {
			if (Application.loadedLevelName == "Level 5" || Application.loadedLevelName == "Level 14") {
				moveHorizontal = Input.GetAxis ("Horizontal");
				moveVertical = Input.GetAxis ("Vertical");

				if (moveVertical > 0) {
					moveVertical = 0;
				}
			}

			else {
				moveHorizontal = Input.GetAxis ("Horizontal");
				moveVertical = Input.GetAxis ("Vertical");
			}
			
			Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);
			
			rb.AddForce (movement * speed);
		}
		
		if (playerDevice == "Portable Device")
		{
			if (Application.loadedLevelName == "Level 5" || Application.loadedLevelName == "Level 14") {
				float swipeSpeed = 50F;
				moveHorizontal = 0.0F;
				moveVertical = 0.0F;
			
				if (Input.touchCount > 0 && Input.GetTouch (0).phase == TouchPhase.Moved)
				{
					touchDeltaPosition = Input.GetTouch (0).deltaPosition;                         
					moveHorizontal += touchDeltaPosition.x / Screen.width * swipeSpeed;
					moveVertical += touchDeltaPosition.y / Screen.height * swipeSpeed;
					
					if (moveVertical > 0) {
						moveVertical = 0;
					}
				}
			}

			else {
					float swipeSpeed = 50F;
					moveHorizontal = 0.0F;
					moveVertical = 0.0F;
					
					if (Input.touchCount > 0 && Input.GetTouch (0).phase == TouchPhase.Moved)
					{
						touchDeltaPosition = Input.GetTouch (0).deltaPosition;                         
						moveHorizontal += touchDeltaPosition.x / Screen.width * swipeSpeed;
						moveVertical += touchDeltaPosition.y / Screen.height * swipeSpeed;
					}
			}
			
			Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);
			
			rb.AddForce (movement * speed);
		}

	}

	void OnGUI () {
		timeCountLabel = GUI.skin.GetStyle("Label");
		timeCountLabel.fontSize = Mathf.RoundToInt(60 * ratio);
		timeCountLabel.alignment = TextAnchor.UpperCenter;

		winTextLabel = GUI.skin.GetStyle ("Label");
		winTextLabel.fontSize = Mathf.RoundToInt(60 * ratio);
		winTextLabel.alignment = TextAnchor.UpperCenter;

		GUI.Label (new Rect (10 * ratio, 10 * ratio, 470 * ratio, 100 * ratio), timeCountText, timeCountLabel);
		GUI.Label (new Rect (Screen.width / 2 - 250 * ratio, Screen.height / 2 - 100 * ratio, 500 * ratio, 100 * ratio), winText, winTextLabel);
	}
	
	void OnTriggerEnter (Collider other)
	{
		if (other.gameObject.CompareTag ("Pick Up"))
		{
			other.gameObject.SetActive (false);
			count = count + 1;
			SetCountText ();
		}
	}
	
	void SetCountText ()
	{
		if (count >= goal && timeCount > 0)
		{
			finish = true;
			PlayerPrefs.SetInt("Win?", 1);
			state = false;
			winText = "You Win!";
			if (2 * scoreLimit / 3 < timeCount) {
				PlayerPrefs.SetInt(Application.loadedLevelName + " Score", 3);
			}

			if (2 * scoreLimit / 3 >= timeCount && timeCount > scoreLimit / 3) {
				PlayerPrefs.SetInt(Application.loadedLevelName + " Score", 2);
			}

			if (timeCount <= scoreLimit / 3) {
				PlayerPrefs.SetInt(Application.loadedLevelName + " Score", 1);
			}

			if (PlayerPrefs.GetInt(Application.loadedLevelName + " High Score") == null || PlayerPrefs.GetInt(Application.loadedLevelName + " High Score") < PlayerPrefs.GetInt(Application.loadedLevelName + " Score")) {
				PlayerPrefs.SetInt(Application.loadedLevelName + " High Score", PlayerPrefs.GetInt(Application.loadedLevelName + " Score"));
			}

			StartCoroutine(waitAndLoad(Application.loadedLevelName + " End", 3));
		}
	}
	
	IEnumerator waitAndLoad (string levelName, int delay)
	{
		yield return new WaitForSeconds (delay);
		Application.LoadLevel (levelName);
	}
}