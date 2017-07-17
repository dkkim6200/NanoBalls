using UnityEngine;
using System.Collections;

public class ObstacleZMover : MonoBehaviour {

	public float movingDistance;
	public float speed;

	private float initPosition;
	public int direction = 1;

	// Use this for initialization
	void Start () {
		initPosition = transform.position.z;
	}
	
	// Update is called once per frame
	void Update () {
		if (transform.position.z >= initPosition + movingDistance / 2) {
			direction = -1;
		}

		if (transform.position.z <= initPosition - movingDistance / 2) {
			direction = 1;
		}
		transform.Translate (0, 0, direction * speed * Time.deltaTime);
	}

	void OnCollisionEnter (Collision col)
	{
		if(col.gameObject.name == "Player" && PlayerPrefs.GetInt("Win?") == 0)
		{
			Application.LoadLevel("_Lost");
		}
	}
}
