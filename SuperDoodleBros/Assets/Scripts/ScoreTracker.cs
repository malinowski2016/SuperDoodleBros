using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreTracker : MonoBehaviour {

	public Text myText;
	public float curr_score = 0;

	// For reporting stat s
	public int numBasic = 0;		//combining the two for now
	//public int numMiddle = 0;
	public int numTrackers = 0;

	public int numShots = 0;
	public int numHits = 0;


	// Use this for initialization
	void Start () {
		myText = GetComponent<Text> ();
		Reset ();
	}

	void Update() {
		//WaitForSeconds(1);
		if (GameObject.FindGameObjectWithTag ("Player") != null) {
			AddScore (Time.deltaTime);
		}
	}

	public void Reset() {
		curr_score = 0f;
		myText.text = "Score: " + curr_score.ToString ("#.0");
	}
		
	public void AddScore(float points) {
		curr_score += points;
		myText.text = "Score: " + curr_score.ToString ("#.0");
	}
}
