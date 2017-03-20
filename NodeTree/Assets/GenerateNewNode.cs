using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GenerateNewNode : MonoBehaviour {

	public Transform button;
	public GameObject node;

	private GameObject newNode;
	private int nodeTrim = 50;

	void Start() {
		button.GetComponent<Button> ().interactable = true;
	}

	public void Generate() {
		Debug.Log ("Generated!");

		int numberOfNode = Random.Range (1, 4);

		Debug.Log (numberOfNode + " Generating");

		float[,] positions = new float[numberOfNode,2];

		int order = Mathf.Abs((int)transform.position.x) / nodeTrim;

		order++;

		//Button unpressable
		if (button.GetComponent<Button> ().IsInteractable () == true) {
			button.GetComponent<Button> ().interactable = false;
			//button.GetComponent<Renderer> ().material.color = Color.black;
		} else {
			button.GetComponent<Button> ().interactable = true;
			//button.GetComponent<Renderer> ().material.color = Color.white;
		}

		for (int i = 0; i < numberOfNode; i++) {
			int x, y;
			if (Random.Range (0, 2) == 0) {
				x = Random.Range (1, 100) + nodeTrim * order;
			} else {
				x = Random.Range (-100, -1) - nodeTrim * order;
			}
			if (Random.Range (0, 2) == 0) {
				y = Random.Range (1, 100) + nodeTrim * order;
			} else {
				y = Random.Range (-100, -1) - nodeTrim * order;
			}
			if (isNodeContainOkay (positions, x, y, i)) {
				positions[i,0] = x;
				positions[i,1] = y;
			} else {
				Debug.Log ("Again");
				i--;
			}
		}

		for (int i = 0; i < numberOfNode; i++) {
			Debug.Log (positions[i,0]+" : " + positions[i,1]);

			newNode = Instantiate (node, new Vector3 (transform.position.x + positions [i, 0], transform.position.y + positions [i, 1], transform.position.z), Quaternion.identity) as GameObject;
			Debug.Log ("Generate " + i);
		}
	}

	public bool isNodeContainOkay(float[,] arrays, int x, int y, int num) {
		for (int i = 0; i < num; i++) {
			if ((x < (arrays[i,0] + 50) && x > (arrays[i,0] - 50)) && (y < (arrays[i,1] + 50) || y > (arrays[i,1] - 50))) {
				return false;
			}
		}
		return true;
	}
}