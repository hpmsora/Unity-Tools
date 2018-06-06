using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

	static GameController instance;

	public Text Text_SubmittedText;
	public InputField InputField_NewText;
	public Button Button_SubmitText;
	public Button Button_ChangeScene;

	private static bool created = false;
	private Data String_SubmittedText;

	// Use this for initialization
	void Start () {
		Button btn_SubmitText = Button_SubmitText.GetComponent<Button> ();
		Button btn_ChangeScene = Button_ChangeScene.GetComponent<Button> ();

		btn_SubmitText.onClick.AddListener (Button_Method_SubmitText);
		btn_ChangeScene.onClick.AddListener (Button_Method_ChangeScene);

		Text_SubmittedText.text = String_SubmittedText.Text_String;
	}

	void Awake() {
		if (instance == null) {
			instance = this;
			if (!created) {
				String_SubmittedText = new Data ();
				String_SubmittedText.Text_String = "Start";
				DontDestroyOnLoad (this.gameObject);
				DontDestroyOnLoad (GameObject.Find ("Canvas_MainScene"));
				DontDestroyOnLoad (GameObject.Find ("EventSystem_MainScene"));
				created = true;
			}
		} else if (instance != this) {
			Destroy (gameObject);
		}
	}

	// Update is called once per frame
	void Update () {
		Text_SubmittedText.text = String_SubmittedText.Text_String;
	}

	void Button_Method_SubmitText() {
		Debug.Log ("Submit Text!");
		String_SubmittedText.Text_String += InputField_NewText.text + "\n";
	}

	void Button_Method_ChangeScene() {
		if (SceneManager.GetActiveScene ().name == "MasterScene") {
			Debug.Log("Change Scene");
			GameObject.Find ("Canvas_MainScene").GetComponent<Canvas> ().enabled = false;
			SceneManager.LoadScene ("SubScene", LoadSceneMode.Single);
		}
	}
}
