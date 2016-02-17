using UnityEngine;
using System.Collections;

public class FireballManager : MonoBehaviour {

	private Vector3 velocity; 
	public float fireball_velo = 1f;

	// Use this for initialization
	void Start () {

		if (GameObject.FindGameObjectWithTag ("Player").GetComponent<DoodleBroScript> ().dir_facing == 1) {
			velocity = new Vector3 (fireball_velo, 0f, 0f);
		} else {
			velocity = new Vector3 (-1f * fireball_velo,  0f, 0f);

		}

		this.gameObject.GetComponent<Rigidbody2D> ().AddForce (velocity, ForceMode2D.Force);

	}
	
	// Update is called once per frame
	void Update () {
		if (this.gameObject.transform.position.y < (Camera.main.transform.position.y - Camera.main.orthographicSize - 1)) {
			Destroy (this.gameObject);
		}
	}


	void OnCollisionEnter2D(Collision2D col){
		// right now just checks tag and destroys itself
		// eventually need to do damage
		if (col.gameObject.tag == "Enemy") {
			Debug.Log (string.Format ("Hit!"));
			Destroy (this.gameObject);
		}
	}

}
