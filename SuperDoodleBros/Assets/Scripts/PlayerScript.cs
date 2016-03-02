using UnityEngine;
using System;
using System.Collections;

public class PlayerScript : MonoBehaviour {
	/*
	public event Action LandedOnPlatform = delegate{};
	public event Action PlayerDeath = delegate{};

	public Vector3 Acceleration;
	public Vector3 JumpVelocity;

	private bool _OnPlatform;

	private Rigidbody rigidBody;

	// Use this for initialization
	void Start () {
		rigidBody = gameObject.GetComponent<Rigidbody>();

		PlayerDeath += DeletePlayer;
	}

	private void DeletePlayer(){
		Destroy (this.gameObject);
	}
	
	// Update is called once per frame
	void Update () {
		if (_OnPlatform) {
			if (Input.GetButtonDown ("Jump")) {
				rigidBody.AddForce (JumpVelocity, ForceMode.VelocityChange);
			}
		}

		if (Input.GetAxis ("Horizontal") == 1) {
			rigidBody.AddForce (Acceleration, ForceMode.Acceleration);
		} else if (Input.GetAxis ("Horizontal") == -1) {
			rigidBody.AddForce (-1 * Acceleration, ForceMode.Acceleration);
		}

		// FOR NOW, DEATH IS FALLING OFF
		if (this.transform.position.y < -10) {
			PlayerDeath.Invoke ();
		}
	}

	void FixedUpdate() {
        // float h = Input.GetAxis("Horizontal");          //-1 if press left, +1 if press right
        // rb.AddForce((Vector2.right * moveSpeed) * h); // Move left/right 

        //Limit speed
		/*
        if (rb.velocity.x > maxSpeed)
            rb.velocity = new Vector2(maxSpeed, rb.velocity.y);
        if (rb.velocity.x < -maxSpeed)
            rb.velocity = new Vector2(-maxSpeed, rb.velocity.y);
        
    }

	void OnCollisionEnter(){

		_OnPlatform = true;

	}

    void OnCollisionExit()
    {
		_OnPlatform = false;
    }
    */
}
