using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateNewNode : MonoBehaviour {

	public GameObject node;

	private GameObject newNode;

	public void Generate() {
		Debug.Log ("Generated!");
		newNode = Instantiate(node, new Vector3(transform.position.x + 100, transform.position.y, transform.position.z), Quaternion.identity) as GameObject;
	}

	/*void update() {
		if(Input.GetKeyDown("d")) {
			newNode = Instantiate(node, transform.position, Quaternion.identity) as GameObject;
		}
	}*/
}