using UnityEngine;
using System.Collections;

public class PlatformBehavior : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter2D(Collision2D col){

		if (col.gameObject.tag == "Player") {
			Debug.Log (string.Format ("Enter collision"));
			Object.Destroy (this.gameObject, 3f);
		}
	}
}
