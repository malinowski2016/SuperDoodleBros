using UnityEngine;
using System.Collections;

public class EnemyManager : MonoBehaviour {
	public PlatformManager platformManager;
	public BasicEnemyBehavior basicEnemy;
	public TrackerEnemyBehavior trackerEnemy;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

	}

	public void SpawnEnemy(Vector3 spawnPos, float platWidth){
		int enemyType = Random.Range (1, 100);

		if (enemyType <= 70) {					// No enemy
			return;
		} else if (enemyType <= 90){			// Basic enemy
			basicEnemy.SpawnBasicEnemy(spawnPos, platWidth);
		} else {								// Tracker enemy					
			trackerEnemy.SpawnTrackerEnemy(spawnPos);
		}

		/*if (enemy != null) {
			MoveEnemyToPosition (enemy);
		}*/
	}

	/*private void MoveEnemyToPosition(GameObject enemy){
		enemy.transform.position = platformManager._LastSpawn;
	}*/
}
