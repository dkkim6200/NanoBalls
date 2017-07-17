using UnityEngine;
using System.Collections;

public class ObstacleMoverPositive : MonoBehaviour {

	public float movingDistance;
	public float speed;

	private float initPosition;
	public int direction = 1;

	// Use this for initialization
	void Start () {
		initPosition = transform.position.y;
	}
	
	// Update is called once per frame
	void Update () {
		if (transform.position.y > initPosition + movingDistance) {
			direction = -1;
		}

		if (transform.position.y < initPosition) {
			direction = 1;
		}
		transform.Translate (0, direction * speed * Time.deltaTime, 0);
	}

	void OnCollisionEnter (Collision col)
	{
		if(col.gameObject.name == "Player" && PlayerPrefs.GetInt("Win?") == 0)
		{
			Application.LoadLevel("_Lost");
		}
	}
}
