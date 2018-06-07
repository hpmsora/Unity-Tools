using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Canvas_MainScene_Script : MonoBehaviour {
	static Canvas_MainScene_Script instance;

	void Awake() {
		if (instance == null) {
			instance = this;
		} else if (instance != this) {
			Destroy (gameObject);
		}
	}
}
