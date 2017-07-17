using UnityEngine;
using System.Collections;

public class BGM : MonoBehaviour {

	private static BGM instance = null;
	public static BGM Instance {
		get
		{
			return instance;
		}
	}

	void Update() {
		instance = this;
		/*
		if (Application.loadedLevelName == "_Option") {
			Destroy (this.gameObject);
		}
		*/
		DontDestroyOnLoad(this.gameObject);
	}

}
