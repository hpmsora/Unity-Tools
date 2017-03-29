using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System;
using UnityEngine;
using UnityEngine.UI;

public class SaveAndLoadScript : MonoBehaviour {

	public InputField userNameInputField;

	public void savedButtonPressed() {
		if (userNameInputField.text != "") {
			saved ();
		} else {
			Debug.Log ("Please enter the user name.");
		}
	}

	public void loadedButtonPressed() {

		if (userNameInputField.text != "") {
			loaded ();
		} else {
			Debug.Log ("Please enter the user name.");
		}
	}

	void saved() {
		BinaryFormatter binaryFormatter = new BinaryFormatter ();
		FileStream savedFile = File.Create (Application.persistentDataPath + "/" + userNameInputField.text + ".dat");

		binaryFormatter.Serialize (savedFile, GameControllerScript.Instance.nodeList);
		savedFile.Close ();

		Debug.Log ("File Saved!\n" + Application.persistentDataPath);
	}

	void loaded() {

		//Destroy the current nodes
		GameObject[] currentNodes = GameObject.FindGameObjectsWithTag ("Node");
		GameObject[] currentNodeConnections = GameObject.FindGameObjectsWithTag ("NodeConnection");

		for (int i = 0; i < currentNodes.Length; i++) {
			Destroy (currentNodes [i]);
		}

		for (int i = 0; i < currentNodeConnections.Length; i++) {
			Destroy (currentNodeConnections [i]);
		}

		//Loading the file
		if (File.Exists (Application.persistentDataPath + "/" + userNameInputField.text + ".dat")) {
			BinaryFormatter binaryFormatter = new BinaryFormatter ();
			FileStream loadedFile = File.Open (Application.persistentDataPath + "/" + userNameInputField.text + ".dat", FileMode.Open);

			List<NodeInfo> data = (List<NodeInfo>)binaryFormatter.Deserialize (loadedFile);
			loadedFile.Close ();

			Debug.Log ("File Loaded!\n");
			for (int i = 0; i < data.Count; i++) {
				Debug.Log (data [i].ToString () + "\n");
			}
			GameControllerScript.Instance.nodeList = data;
		} else {
			Debug.Log ("Cannot find the use name");
		}

		//Reload the node
		GameControllerScript.Instance.Reload ();
	}
}