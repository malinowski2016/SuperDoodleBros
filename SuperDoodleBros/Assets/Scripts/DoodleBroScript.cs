using UnityEngine;
using System;
using System.Collections;

public class DoodleBroScript : MonoBehaviour {

	public event Action CheckPlayerDeath = delegate{};

	public Vector3 Acceleration;
	public Vector3 JumpVelocity;

	private bool _OnPlatform;

	private Rigidbody2D rigidBody;

	// Use this for initialization
	void Start () {
		rigidBody = gameObject.GetComponent<Rigidbody2D>();

		CheckPlayerDeath += CheckDeletePlayer;
	}

	private void CheckDeletePlayer(){
		// FOR NOW, DEATH IS FALLING OFF
		if (this.transform.position.y < -10) {
			Destroy (this.gameObject);
		}

	}

	// Update is called once per frame
	void Update () {

		if (_OnPlatform && Input.GetButtonDown ("Jump")) {
			rigidBody.AddForce (JumpVelocity, ForceMode2D.Impulse);
			_OnPlatform = false;
		} 

		if (Input.GetAxis ("Horizontal") == 1) {
			rigidBody.AddForce (Acceleration, ForceMode2D.Force);
		} else if (Input.GetAxis ("Horizontal") == -1) {
			rigidBody.AddForce (-1 * Acceleration, ForceMode2D.Force);
		}

		CheckPlayerDeath.Invoke ();
	}

	void FixedUpdate() {
		
	}
		
	void OnCollisionEnter2D(Collision2D col){

		if(col.gameObject.tag == "Platform") _OnPlatform = true;

//		if (this.gameObject.transform.position.y < col.gameObject.transform.position.y) {
//			col.gameObject.GetComponent<Collider2D> ().enabled = false;
//			Debug.Log (string.Format ("SHOULD GO THROUGH"));
//		} else {
//			this.GetComponent<Collider2D> ().enabled = true;
//		}

	}

	void OnCollisionExit(){

		_OnPlatform = false;

//		col.gameObject.GetComponent<Collider2D> ().enabled = true;
	}

}
