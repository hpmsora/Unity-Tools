using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GenerateNewNode : MonoBehaviour {

	public Transform button;
	public GameObject node;

	private GameObject newNode;
	private float nodeTrim;

	public void Generate() {
		Debug.Log ("Generated!");

		//int numberOfNode = Random.Range (1, 4);
		int numberOfNode = 100;

		double[,] positions = new double[numberOfNode,2];

		for (int i = 0; i < numberOfNode; i++) {
			int x, y;
			if (Random.Range (0, 2) == 0) {
				x = Random.Range (1, 300);
			} else {
				x = Random.Range (-300, -1);
			}
			if (Random.Range (0, 2) == 0) {
				y = Random.Range (1, 300);
			} else {
				y = Random.Range (-300, -1);
			}
			if (isNodeContainOkay (positions, x, y, i)) {
				positions[i,0] = x;
				positions[i,1] = y;
			} else {
				Debug.Log ("G :" +isNodeContainOkay (positions, x, y, i));
				positions[i,0] = 0;
				positions[i,1] = 0;
			}
		}

		for (int i = 0; i < numberOfNode; i++) {
			Debug.Log (positions[i,0]+" : " + positions[i,1]);
		}

		while (numberOfNode > 0) {
			newNode = Instantiate (node, new Vector3 (transform.position.x + nodeTrim, transform.position.y, transform.position.z), Quaternion.identity) as GameObject;
			if (button.GetComponent<Button> ().IsInteractable () == true) {
				button.GetComponent<Button> ().interactable = false;
				button.GetComponent<Renderer> ().material.color = Color.gray;
			} else {
				button.GetComponent<Button> ().interactable = true;
				button.GetComponent<Renderer> ().material.color = Color.white;
			}
			numberOfNode++;
		}
	}

	public bool isNodeContainOkay(double[,] arrays, int x, int y, int num) {
		for (int i = 0; i < num; i++) {
			if ((x < (arrays[i,0] + 50) && x > (arrays[i,0] - 50)) || (y < (arrays[i,1] + 50) || y > (arrays[i,1] - 50))) {
				return false;
			}
		}
		return true;
	}
}