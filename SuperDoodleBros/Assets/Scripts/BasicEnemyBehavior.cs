using UnityEngine;
using System.Collections;

public class BasicEnemyBehavior : MonoBehaviour
{
	public GameObject basic_enemy_prefab;

	// Movement
    private Vector3 initialPos;
	public bool dirRight = true;
	public float speed = 0.01f;
	public float range = 0.0001f;

	// Health
    public float maxHealth = 20f;
    public float currentHealth;

    // Use this for initialization
    void Start()
    {
        currentHealth = maxHealth;
        initialPos = transform.position;

    }

    // Update is called once per frame
    void Update()
    {
		// Moves enemy back and forth
		Vector3 pos = new Vector3(initialPos.x - range/2 + Mathf.PingPong(speed * Time.time, range), this.gameObject.transform.position.y, 0f);
		transform.position = pos;
		/*
		if (dirRight) {
			this.transform.Translate (Vector2.right * speed * Time.time);
		} else {
			this.transform.Translate (-Vector2.right * speed * Time.time);
		}
		/*
		if (pos.x == initialPos.x - range / 2 || pos.x == initialPos.x + range / 2) {
			FlipEnemy ();
		}

        
		

		if (this.transform.position.x <= Mathf.Floor(initialPos.x - (range/2))) {
			dirRight = true;
			FlipEnemy ();
		} else if (this.transform.position.x >= Mathf.Floor(initialPos.x + (range/2))) {
			dirRight = false;
			FlipEnemy ();
		}
		*/

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

	private void FlipEnemy(){
		Debug.Log (string.Format ("Flip"));
		this.gameObject.transform.Rotate (new Vector3 (0f, 180f));
	}

	// Either spawn on platform or make prefabs w/ enemies included
	public GameObject SpawnBasicEnemy(Vector3 spawnPos, float platWidth) {
		GameObject enemy;
		enemy = Instantiate (basic_enemy_prefab, spawnPos, Quaternion.identity) as GameObject;
		//my_platform = platform;
		range = platWidth;
		return enemy;
	}
}