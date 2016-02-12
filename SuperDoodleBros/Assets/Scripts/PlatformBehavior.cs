using UnityEngine;
using System.Collections;

public class PlatformBehavior : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	/*
	void OnCollisionEnter(Collision col){
		Debug.Log (string.Format ("Enter collision"));
		if (this.gameObject.transform.position.y >= col.gameObject.transform.position.y) {
			this.GetComponent<Collider2D> ().enabled = false;
			Debug.Log (string.Format ("SHOULD GO THROUGH"));
		} else {
			this.GetComponent<Collider2D> ().enabled = true;
		}
	}

	void OnCollisionExit(){
		this.GetComponent<Collider2D> ().enabled = true;
	}
	*/
}
