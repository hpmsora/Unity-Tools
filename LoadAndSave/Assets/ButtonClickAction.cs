using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System;
using UnityEngine;
using UnityEngine.UI;

public class ButtonClickAction : MonoBehaviour {

	public InputField textInputField;
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

		SavingData data = new SavingData ();
		data.text = textInputField.text;

		binaryFormatter.Serialize (savedFile, data);
		savedFile.Close ();

		OutputText.text = "File Saved!\n" + Application.persistentDataPath;
	}

	void loaded() {
		if (File.Exists (Application.persistentDataPath + "/" + userNameInputField.text + ".dat")) {
			BinaryFormatter binaryFormatter = new BinaryFormatter ();
			FileStream loadedFile = File.Open (Application.persistentDataPath + "/" + userNameInputField.text + ".dat", FileMode.Open);

			SavingData data = (SavingData)binaryFormatter.Deserialize (loadedFile);
			loadedFile.Close ();

			OutputText.text = "File Loaded!\n" + data.text;
		} else {
			OutputText.text = "Cannot find the use name";
		}
	}
}

[Serializable]
class SavingData {
	public String text;
}