using UnityEngine;
using System.Collections;

public class GroundRotator : MonoBehaviour {
	
	public float speed;
	public Vector3 centerPosition;
	public Vector3 axis;
	public int direction = 1;

	// Update is called once per frame
	void Update () {
		transform.RotateAround (centerPosition, axis, direction * speed * Time.deltaTime);
	}
}
