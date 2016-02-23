using UnityEngine;
using System.Collections;

public class EnemyHealth : MonoBehaviour {
	public float currentHealth;
	public float maxHealth;

	// Use this for initialization
	void Start () {
		currentHealth = maxHealth;
	}
	
	// Update is called once per frame
	void Update () {
		CheckDestroy ();
	}

	void CheckDestroy() {
		var miny = Camera.main.transform.position.y - Camera.main.orthographicSize - 1;
		if (currentHealth <= 0 || transform.position.y < miny) {
			Destroy (gameObject);
		}
	}

	void OnCollisionEnter2D(Collision2D col){
		FireballManager fireball = col.gameObject.GetComponent<FireballManager> ();
		if (fireball) {
			//Debug.Log (fireball.damage);
			currentHealth -= fireball.damage;
		}
	}
}
