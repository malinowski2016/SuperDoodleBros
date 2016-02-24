using UnityEngine;
using System.Collections;

public class EnemyManager : MonoBehaviour {
<<<<<<< HEAD
	//public PlatformManager platformManager;
	public BasicEnemyBehavior basicEnemy;
=======
	public PlatformManager platformManager;
	public GameObject basicEnemy;
	public GameObject middleEnemy;
>>>>>>> refs/remotes/origin/master
	public TrackerEnemyBehavior trackerEnemy;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void SpawnEnemy(Vector3 spawnPos, float platWidth){
<<<<<<< HEAD
		int enemyType = Random.Range (1, 100);

		if (enemyType <= 60) {					// No enemy
			return;
		} else if (enemyType <= 90){			// Basic enemy
			basicEnemy.SpawnBasicEnemy(spawnPos, platWidth);
=======
	//public void SpawnEnemy(Vector3 spawnPos, GameObject platform){
		GameObject enemy;
		int enemyType = Random.Range (1, 100);

		if (enemyType <= 70) {					// No enemy
			enemy = null;
		} else if (enemyType <= 90) {			// Basic enemy
			enemy = basicEnemy.GetComponent<BasicEnemyBehavior> ().SpawnBasicEnemy (spawnPos, platWidth);
		} else if (enemyType <= 96) {
			enemy = middleEnemy.GetComponent<BasicEnemyBehavior> ().SpawnBasicEnemy (spawnPos, platWidth);
>>>>>>> refs/remotes/origin/master
		} else {								// Tracker enemy					
			trackerEnemy.SpawnTrackerEnemy(spawnPos);
		}
	}
}

