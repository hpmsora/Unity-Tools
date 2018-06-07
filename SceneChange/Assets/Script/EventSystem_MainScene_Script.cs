using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventSystem_MainScene_Script : MonoBehaviour {
	static EventSystem_MainScene_Script instance;

	void Awake() {
		if (instance == null) {
			instance = this;
		} else if (instance != this) {
			Destroy (gameObject);
		}
	}
}
