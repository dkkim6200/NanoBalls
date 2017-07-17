using UnityEngine;
using System.Collections;

public class Muter : MonoBehaviour {

	private AudioSource audio;

	// Use this for initialization
	void Start () {
		audio = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		if (PlayerPrefs.GetInt ("Mute") == 1) {
			audio.mute = true;
		}

		else {
			audio.mute = false;
		}
	}
}
