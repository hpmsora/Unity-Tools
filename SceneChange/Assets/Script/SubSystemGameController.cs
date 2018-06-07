using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SubSystemGameController : MonoBehaviour {

	public Button Button_BackToMain;

	// Use this for initialization
	void Start () {
		Button btn_BackToMain = Button_BackToMain.GetComponent<Button> ();

		btn_BackToMain.onClick.AddListener (Button_Method_BackToMain);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void Button_Method_BackToMain() {
		if (SceneManager.GetActiveScene ().name == "SubScene") {
			Debug.Log("Back to Main Scene");
			GameObject.Find ("Canvas_MainScene").GetComponent<Canvas> ().enabled = true;
			SceneManager.LoadScene ("MasterScene", LoadSceneMode.Single);
		}
	}
}
