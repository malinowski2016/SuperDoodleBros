using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DisplayStats : MonoBehaviour {
	public Text score;
	public Text basic;
	public Text tracker;
	public Text shots;
	public Text hits;
	public Text accuracy;

	// Use this for initialization
	void Start () {
		score.text = "SCORE:\n" + PlayerPrefs.GetInt ("score");
		basic.text = "-Basic: " + PlayerPrefs.GetInt ("basic");
		tracker.text = "-Tracker: " + PlayerPrefs.GetInt ("tracker");

		int numShots = PlayerPrefs.GetInt ("shot");
		int numHits = PlayerPrefs.GetInt ("hit");
		float hitPct = 0f;
		if (numShots != 0)
			hitPct = (float) numHits / numShots * 100;
		shots.text = "-Shots: " + numShots;
		hits.text = "-Hits: " + numHits;
		accuracy.text = ">Accuracy: " + hitPct.ToString("#.00") + "%";
	}

	public void AddScore(Text player_name){
		int newScore;
		string newName;
		int oldScore;
		string oldName;
		newScore = PlayerPrefs.GetInt ("score");
		newName = player_name.text;

		for (int i=1;i<=10;i++) {
			if (PlayerPrefs.HasKey(i+"HScore")) {
				if (PlayerPrefs.GetInt(i+"HScore") < newScore) { 
					// new score is higher than the stored score
					oldScore = PlayerPrefs.GetInt(i+"HScore");
					oldName = PlayerPrefs.GetString(i+"HScoreName");
					PlayerPrefs.SetInt(i+"HScore",newScore);
					PlayerPrefs.SetString(i+"HScoreName",newName);
					newScore = oldScore;
					newName = oldName;
				}
			} else {
				PlayerPrefs.SetInt(i+"HScore",newScore);
				PlayerPrefs.SetString(i+"HScoreName",newName);
				newScore = 0;
				newName = "";
			}
		}
	}
}
