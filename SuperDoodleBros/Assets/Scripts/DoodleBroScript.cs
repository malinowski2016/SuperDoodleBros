using UnityEngine;
using System;
using System.Collections;

public class DoodleBroScript : MonoBehaviour {

	public event Action CheckPlayerDeath = delegate{};

	public Vector3 Acceleration;
	public Vector3 JumpVelocity;

	private bool _OnPlatform;
	private Animator animator;

	private Rigidbody2D rigidBody;

	void Awake(){
		animator = GetComponent<Animator> ();
	}

	// Use this for initialization

	void Start () {
		rigidBody = gameObject.GetComponent<Rigidbody2D>();

		CheckPlayerDeath += CheckDeletePlayer;
	}

	private void CheckDeletePlayer(){
		// FOR NOW, DEATH IS FALLING OFF
		if (this.transform.position.y < 
			(Camera.main.transform.position.y - Camera.main.orthographicSize - 1)) {
			Destroy (this.gameObject);
		}

	}

	// Update is called once per frame
	void Update () {
		
		if (_OnPlatform && Input.GetButtonDown ("Jump")) {
			animator.SetInteger ("AnimState", 0);
			rigidBody.AddForce (JumpVelocity, ForceMode2D.Impulse);
			//Debug.Log (string.Format("JUMP"));
			_OnPlatform = false;
		} 

		if (Input.GetAxis ("Horizontal") == 1) {
			rigidBody.AddForce (Acceleration, ForceMode2D.Force);
			animator.SetInteger ("AnimState", 1);
			//Debug.Log(string.Format("Right"));
		} else if (Input.GetAxis ("Horizontal") == -1) {
			rigidBody.AddForce (-1 * Acceleration, ForceMode2D.Force);
			animator.SetInteger ("AnimState", 2);
			//Debug.Log (string.Format ("LEFT"));
		} else {
			animator.SetInteger ("AnimState", 0);
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
