using UnityEngine;
using System.Collections;

public class TrackerEnemyBehavior : MonoBehaviour {

	public GameObject tracker_enemy_prefab;
	//private EnemyManager enemyManager;
	public ScoreTracker score;

	// Movement
    private GameObject target;
    private Transform targetTrans;
    public int MoveSpeed = 5;
 	public int MaxDist = 10;
 	public int MinDist = 5;
	Vector3 direction;

	// Health
	public float maxHealth = 10f; //number of seconds before expiration if decayRate==1 
	public float currentHealth;
	public float decayRate = 1f;
 
 
	void Start (){
		currentHealth = maxHealth;

        target = GameObject.FindWithTag("Player");
        targetTrans = target.transform;
		score = GameObject.FindGameObjectWithTag ("Score").GetComponent<ScoreTracker> ();
    }
 
 	void Update (){
		if (target != null) {
			direction = targetTrans.position - transform.position;
			transform.position += direction.normalized * MoveSpeed * Time.deltaTime;

			// Destroys tracker after certain amount of time
			// *** ADD HEALTHBAR OR TIMER so that player knows when it'll stop chasing
			// *** Add dmg from explosion or a slow or something
			// *** Potentially use "Destroy(GameObject, destroyTime)" instead?

	//***********COMMENT OUT UNTIL COLLIDER IGNORE FIXED
			currentHealth -= Time.deltaTime * decayRate;

			CheckDestroy ();
		}
    }

	void CheckDestroy() {
		if (currentHealth <= 0) {
			score.numTrackers += 1;
			Debug.Log (score.numTrackers);
			score.AddScore (10f);
			Destroy (gameObject);
		}
	}

	public GameObject SpawnTrackerEnemy(Vector3 spawnPos) {
		GameObject enemy;
		enemy = Instantiate (tracker_enemy_prefab, spawnPos, Quaternion.identity) as GameObject;
		return enemy;
	}

	void OnCollisionEnter2D(Collision2D col){
		FireballManager fireball = col.gameObject.GetComponent<FireballManager> ();
		if (fireball) {
			currentHealth -= fireball.damage;
		}
			
		//	Destroy (target);
		//		if (this.gameObject.transform.position.y < col.gameObject.transform.position.y) {
		//			col.gameObject.GetComponent<Collider2D> ().enabled = false;
		//			Debug.Log (string.Format ("SHOULD GO THROUGH"));
		//		} else {
		//			this.GetComponent<Collider2D> ().enabled = true;
		//		}

	}

	void OnCollisionExit(){
		//Debug.Log (string.Format ("Exit collision"));

		//		col.gameObject.GetComponent<Collider2D> ().enabled = true;
	}
}
