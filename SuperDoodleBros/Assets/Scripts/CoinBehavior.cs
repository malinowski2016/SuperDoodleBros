using UnityEngine;
using System.Collections;

public class CoinBehavior : MonoBehaviour {

	public int score_value = 30;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (this.gameObject.transform.position.y < (Camera.main.transform.position.y - Camera.main.orthographicSize)) {
			Destroy (this.gameObject);
		}
	}

	void OnCollisionEnter2D(Collision2D col){
		//Debug.Log (col.gameObject.tag);
		if (col.gameObject.tag == "Player") {
			GameObject.FindGameObjectWithTag ("Score").GetComponent<ScoreTracker> ().AddScore (score_value);
			Destroy (this.gameObject);
		}
	}
}
