﻿using UnityEngine;
using System.Collections;

public class TrackerEnemyBehavior : MonoBehaviour {

	public GameObject tracker_enemy_prefab;

	// Movement
    private GameObject target;
    private Transform targetTrans;
    public int MoveSpeed = 5;
 	public int MaxDist = 10;
 	public int MinDist = 5;
	Vector3 direction;

	// Health
	public float maxHealth = 100f;
	public float currentHealth;
	public float decayRate = 0.1f;

	// Attack
    public int attackDmg = 10;
	public int range = 200;
    PlayerHealth playerHealth;
 
 
	void Start (){
		currentHealth = maxHealth;

        target = GameObject.FindWithTag("Player");
        targetTrans = target.transform;
        playerHealth = target.GetComponent<PlayerHealth>();

		//Physics2D.IgnoreCollision(gameObject.GetComponent<Collider2D>
    }
 
 	void Update (){
		direction = targetTrans.position - transform.position;
		//if (Vector3.Distance(transform.position,targetTrans.position) <= range) {
			//Debug.Log("IN RANGE");
		transform.position += direction.normalized * MoveSpeed * Time.deltaTime;
		//}

		// Destroys tracker after certain amount of time
			// *** ADD HEALTHBAR OR TIMER so that player knows when it'll stop chasing
				// *** Add dmg from explosion or something
			// *** Potentially use "Destroy(GameObject, destroyTime)" instead?
		currentHealth -= Time.deltaTime * decayRate;
		CheckDestroy ();
    }

	void CheckDestroy() {
		if (currentHealth <= 0) {
			Destroy (gameObject);
		}
	}

	public GameObject SpawnTrackerEnemy(Vector3 spawnPos) {
		GameObject enemy;
		enemy = Instantiate (tracker_enemy_prefab, spawnPos, Quaternion.identity) as GameObject;
		return enemy;
	}

/*TURNED OFF COLLIDER TO AVOID COLLISIONS W/ PLATFORMS
	void OnCollisionEnter2D(Collision2D other)
    {
        // If the entering collider is the player...
		if (other.gameObject == target) {
			if (playerHealth.currentHealth > 0) {
				playerHealth.TakeDamage (attackDmg);
			}
		} else if (other.gameObject.tag == "projectile") {
			Destroy (gameObject);
		} else {
			Physics2D.IgnoreCollision (other.collider, collider); //gameObject.GetComponent<Collider2D>);
		}
    }

    void OnCollisionExit()
    {
        // If the exiting collider is the player...
        //if (other.gameObject == target) { }
    }
    */
}
