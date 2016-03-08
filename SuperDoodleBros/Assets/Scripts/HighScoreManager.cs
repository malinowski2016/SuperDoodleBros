using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HighScoreManager : MonoBehaviour {
	public Text HS1;
	public Text HS2;
	public Text HS3;
	public Text HS4;
	public Text HS5;
	public Text HS6;
	public Text HS7;
	public Text HS8;
	public Text HS9;
	public Text HS10;

	void Start() {
		DisplayScores ();
	}

	void DisplayScores () {
		HS1.text = "1. " + PlayerPrefs.GetString ("1HScoreName") + " - " + PlayerPrefs.GetInt ("1HScore");
		HS2.text = "2. " + PlayerPrefs.GetString ("2HScoreName") + " - " + PlayerPrefs.GetInt ("2HScore");
		HS3.text = "3. " + PlayerPrefs.GetString ("3HScoreName") + " - " + PlayerPrefs.GetInt ("3HScore");
		HS4.text = "4. " + PlayerPrefs.GetString ("4HScoreName") + " - " + PlayerPrefs.GetInt ("4HScore");
		HS5.text = "5. " + PlayerPrefs.GetString ("5HScoreName") + " - " + PlayerPrefs.GetInt ("5HScore");
		HS6.text = "6. " + PlayerPrefs.GetString ("6HScoreName") + " - " + PlayerPrefs.GetInt ("6HScore");
		HS7.text = "7. " + PlayerPrefs.GetString ("7HScoreName") + " - " + PlayerPrefs.GetInt ("7HScore");
		HS8.text = "8. " + PlayerPrefs.GetString ("8HScoreName") + " - " + PlayerPrefs.GetInt ("8HScore");
		HS9.text = "9. " + PlayerPrefs.GetString ("9HScoreName") + " - " + PlayerPrefs.GetInt ("9HScore");
		HS10.text = "10. " + PlayerPrefs.GetString ("10HScoreName") + " - " + PlayerPrefs.GetInt ("10HScore");
	}
}
