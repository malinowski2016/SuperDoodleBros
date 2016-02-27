using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Score : MonoBehaviour {

	private Text myText;
	public float score = 0;

	// For reporting stat s
	public int numBasic = 0;
	public int numMiddle = 0;
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
		AddScore(Time.deltaTime);
	}

	public void Reset() {
		score = 0f;
		myText.text = "Score: " + score.ToString ("#.00");
	}
		
	public void AddScore(float points) {
		score += points;
		myText.text = "Score: " + score.ToString ("#.00");
	}
}
