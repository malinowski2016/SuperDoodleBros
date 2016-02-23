using UnityEngine;
using System;
using System.Collections;

public class DoodleBroScript : MonoBehaviour {

	public event Action CheckPlayerDeath = delegate{};

	public Vector3 Acceleration;
	public Vector3 JumpVelocity;

	public GameObject weapon_prefab;

	private bool _OnPlatform;
	private Animator animator;

	// 1 is right, 0 is left
	public int dir_facing = 1;

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

		if (_OnPlatform && Input.GetKeyDown (KeyCode.UpArrow)) {
			animator.SetInteger ("AnimState", 0);
			rigidBody.AddForce (JumpVelocity, ForceMode2D.Impulse);
			//Debug.Log (string.Format("JUMP"));
			_OnPlatform = false;
		} 

		if (Input.GetKey(KeyCode.RightArrow)) {
			rigidBody.AddForce (Acceleration, ForceMode2D.Force);
			animator.SetInteger ("AnimState", 1);

			dir_facing = 1;
			//Debug.Log(string.Format("Right"));
		} else if (Input.GetKey(KeyCode.LeftArrow)) {
			rigidBody.AddForce (-1 * Acceleration, ForceMode2D.Force);
			animator.SetInteger ("AnimState", 2);

			dir_facing = 0;
			//Debug.Log (string.Format ("LEFT"));
		} else {
			animator.SetInteger ("AnimState", 0);
		}

		if (Input.GetKeyDown (KeyCode.Space)) {
			FireWeapon ();
		}

		CheckPlayerDeath.Invoke ();
	}

	void FixedUpdate() {
		
	}
		
	void OnCollisionEnter2D(Collision2D col){

		if (col.gameObject.tag == "Platform")
			_OnPlatform = true;
		else if (col.gameObject.tag == "Enemy")
			Destroy (this.gameObject);			// 1 hit kill
		
//		if (this.gameObject.transform.position.y < col.gameObject.transform.position.y) {
//			col.gameObject.GetComponent<Collider2D> ().enabled = false;
//			Debug.Log (string.Format ("SHOULD GO THROUGH"));
//		} else {
//			this.GetComponent<Collider2D> ().enabled = true;
//		}

	}

	void OnCollisionExit(){
		Debug.Log (string.Format ("Exit collision"));
		//This will get reset if hits an enemy... but player dies anyway so lol
		_OnPlatform = false;

//		col.gameObject.GetComponent<Collider2D> ().enabled = true;
	}

	private void FireWeapon(){
		var weapon = Instantiate (weapon_prefab);
		var doodle_pos = this.gameObject.transform.position;

		float velo;
		float offset = .15f;

		Vector3 spawn;

		if (dir_facing == 1) {
			spawn = new Vector3 (doodle_pos.x + offset, doodle_pos.y, doodle_pos.z);
		} else {
			spawn = new Vector3 (doodle_pos.x - offset, doodle_pos.y, doodle_pos.z);
		}

		weapon.gameObject.transform.position = spawn;
	}

}
