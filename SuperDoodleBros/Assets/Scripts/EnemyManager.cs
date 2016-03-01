using UnityEngine;
using System.Collections;

public class EnemyManager : MonoBehaviour {

	public PlatformManager platformManager;
	public GameObject basicEnemy;
	public GameObject middleEnemy;

	public GameObject trackerEnemy;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void SpawnEnemy(Vector3 spawnPos, float platWidth){
	//public void SpawnEnemy(Vector3 spawnPos, GameObject platform){
		GameObject enemy;
		int enemyType = Random.Range (1, 100);

		if (enemyType <= 70) {					// No enemy
			enemy = null;
		} else if (enemyType <= 92) {			// Basic enemy
			enemy = basicEnemy.GetComponent<BasicEnemyBehavior> ().SpawnBasicEnemy (spawnPos, platWidth);
		} else if (enemyType <= 98) {
			enemy = middleEnemy.GetComponent<BasicEnemyBehavior> ().SpawnBasicEnemy (spawnPos, platWidth);
		} else {								// Tracker enemy					
			trackerEnemy.GetComponent<TrackerEnemyBehavior>().SpawnTrackerEnemy(spawnPos);
		}
	}
}

