using UnityEngine;
using System.Collections;

public class ObstacleMover : MonoBehaviour {

	public float movingDistance;
	public float speed;

	private float initPosition;
	public int direction = 1;

	// Use this for initialization
	void Start () {
		initPosition = transform.position.x;
	}
	
	// Update is called once per frame
	void Update () {
		if (transform.position.x >= initPosition + movingDistance / 2) {
			direction = -1;
		}

		if (transform.position.x <= initPosition - movingDistance / 2) {
			direction = 1;
		}
		transform.Translate (direction * speed * Time.deltaTime, 0, 0);
	}

	void OnCollisionEnter (Collision col)
	{
		if(col.gameObject.name == "Player" && PlayerPrefs.GetInt("Win?") == 0)
		{
			Application.LoadLevel("_Lost");
		}
	}
}
