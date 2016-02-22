using UnityEngine;
using System.Collections;

public class BasicEnemyBehavior : MonoBehaviour
{
	public GameObject basic_enemy_prefab;

	// Movement
    private Vector3 initialPos;
	public float speed = 0.01f;
	public float range = 0.0001f;

	// Health
    public int maxHealth = 30;
    public int currentHealth;

	// Attacks
    public int attackDamage = 20;

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

		var miny = Camera.main.transform.position.y - Camera.main.orthographicSize - 1;
		if (transform.position.y < miny) {
			//Debug.Log ("Destroyed Basic Enemy out of view");
			Destroy (gameObject);
		}
    }

	// Either spawn on platform or make prefabs w/ enemies included
	public GameObject SpawnBasicEnemy(Vector3 spawnPos, float platWidth) {
		GameObject enemy;
		enemy = Instantiate (basic_enemy_prefab, spawnPos, Quaternion.identity) as GameObject;
		range = platWidth;
		return enemy;
	}
}