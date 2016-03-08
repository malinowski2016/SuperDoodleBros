using UnityEngine;
using System;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DoodleBroScript : MonoBehaviour {

	public ScoreTracker score;
	public GameObject popup;

	public event Action CheckPlayerDeath = delegate{};

	public Vector3 Acceleration;
	public Vector3 JumpVelocity;

	public GameObject weapon_prefab;
	public GameObject green_weapon_prefab;

	public int weapon_choice = 0;
	public int unlock_score = 150;

	private bool _OnPlatform;
	private Animator animator;

	// 1 is right, 0 is left
	public int dir_facing = 1;
	private bool weapon_unlocked = false;

	private Rigidbody2D rigidBody;

	void Awake(){
		animator = GetComponent<Animator> ();
	}

	// Use this for initialization

	void Start () {
		rigidBody = gameObject.GetComponent<Rigidbody2D>();
		score = GameObject.FindGameObjectWithTag ("Score").GetComponent<ScoreTracker> ();
		CheckPlayerDeath += CheckDeletePlayer;
	}

	private void CheckDeletePlayer(){
		// FOR NOW, DEATH IS FALLING OFF
		if (this.transform.position.y < 
			(Camera.main.transform.position.y - Camera.main.orthographicSize)) {
			Destroy (this.gameObject);
		}

	}

	// Update is called once per frame
	void Update () {

		if (this.gameObject.GetComponent<Rigidbody2D> ().velocity.y == 0) {
			_OnPlatform = true;
		} else {
			_OnPlatform = false;
		}

		if (!weapon_unlocked && score.curr_score > unlock_score) {
			weapon_unlocked = true;
			Instantiate (popup);
		}

		if (Input.GetKeyDown (KeyCode.RightShift) || Input.GetKeyDown(KeyCode.LeftShift)) {
			if (weapon_choice == 0 && weapon_unlocked) {
				weapon_choice = 1;
			}
			else {
				weapon_choice = 0;
			}
		}

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
		GameObject weapon;
		if (weapon_choice == 0) {
			weapon = Instantiate (weapon_prefab);
		} else if (weapon_choice == 1) {
			weapon = Instantiate (green_weapon_prefab);
		} else {
			weapon = Instantiate (weapon_prefab);
		}
		var doodle_pos = this.gameObject.transform.position;

//		float velo;
		float offset = .15f;

		Vector3 spawn;

		if (dir_facing == 1) {
			spawn = new Vector3 (doodle_pos.x + offset, doodle_pos.y, doodle_pos.z);
		} else {
			spawn = new Vector3 (doodle_pos.x - offset, doodle_pos.y, doodle_pos.z);
		}

		weapon.gameObject.transform.position = spawn;

		score.numShots += 1;
		//Debug.Log (score.numShots);
	}

}
