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
		accuracy.text = ">Accuracy: " + hitPct + "%";
	}
}
