using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class CameraAutoScroll : MonoBehaviour {

	public ScoreTracker score;

	// Use this for initialization
	void Start () {
		score = GameObject.FindGameObjectWithTag ("Score").GetComponent<ScoreTracker> ();
	}
	
	// Update is called once per frame
	void Update () {
	
		var cameraPosition = transform.localPosition;

		var maxY = Camera.main.orthographicSize + Camera.main.transform.position.y;
		float camera_speed;

		var maxHeight = 20.0;

		if (GameObject.FindGameObjectWithTag("Player") != null) {
			var player_y = GameObject.FindGameObjectWithTag ("Player").gameObject.transform.position.y;
			var head_room = maxY - player_y;
			//Add conditions to deal with massive bounces
			if (head_room < 1f) {
				camera_speed = 4f;
			} else if (head_room < 3f) {
				camera_speed = 2.5f;
			} else {
				camera_speed = 0.5f;
			}
			transform.Translate ((Vector3.up * (float)(Time.deltaTime * camera_speed)), Space.World);
		} else{
			PlayerPrefs.SetInt ("score", (int) score.curr_score);
			PlayerPrefs.SetInt ("basic", score.numBasic);
			PlayerPrefs.SetInt ("tracker", score.numTrackers);
			PlayerPrefs.SetInt ("shot", score.numShots);
			PlayerPrefs.SetInt ("hit", score.numHits);
			SceneManager.LoadScene ("Death Screen");
		}

	}
}
