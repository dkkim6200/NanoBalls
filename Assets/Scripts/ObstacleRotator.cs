using UnityEngine;
using System.Collections;

public class ObstacleRotator : MonoBehaviour {
	
	public float speed;
	public Vector3 centerPosition;
	public Vector3 axis;
	public int direction = 1;

	// Update is called once per frame
	void Update () {
		transform.RotateAround (centerPosition, axis, direction * speed * Time.deltaTime);
	}

	void OnCollisionEnter (Collision col)
	{
		if(col.gameObject.name == "Player" && PlayerPrefs.GetInt("Win?") == 0)
		{
			Application.LoadLevel("_Lost");
		}
	}
}
