using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System;
using UnityEngine;
using UnityEngine.UI;

public class SaveAndLoadScript : MonoBehaviour {

	public InputField userNameInputField;
	public Text OutputText;

	public void savedButtonPressed() {
		if (userNameInputField.text != "") {
			saved ();
		} else {
			OutputText.text = "Please enter the user name.";
		}
	}

	public void loadedButtonPressed() {
		if (userNameInputField.text != "") {
			loaded ();
		} else {
			OutputText.text = "Please enter the user name.";
		}
	}

	void saved() {
		BinaryFormatter binaryFormatter = new BinaryFormatter ();
		FileStream savedFile = File.Create (Application.persistentDataPath + "/" + userNameInputField.text + ".dat");

		binaryFormatter.Serialize (savedFile, GameControllerScript.Instance.nodeList);
		savedFile.Close ();

		OutputText.text = "File Saved!\n" + Application.persistentDataPath;
	}

	void loaded() {
		if (File.Exists (Application.persistentDataPath + "/" + userNameInputField.text + ".dat")) {
			BinaryFormatter binaryFormatter = new BinaryFormatter ();
			FileStream loadedFile = File.Open (Application.persistentDataPath + "/" + userNameInputField.text + ".dat", FileMode.Open);

			List<NodeInfo> data = (List<NodeInfo>)binaryFormatter.Deserialize (loadedFile);
			loadedFile.Close ();

			OutputText.text += "File Loaded!\n";
			for (int i = 0; i < data.Count; i++) {
				OutputText.text += data[i].ToString() + "\n";
			}
		} else {
			OutputText.text = "Cannot find the use name";
		}
	}
}