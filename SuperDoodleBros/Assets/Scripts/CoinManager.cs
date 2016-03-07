using UnityEngine;
using System.Collections;

public class CoinManager : MonoBehaviour {

	public GameObject coin_prefab;
	private float min_x;
	private float max_x;

	// Use this for initialization
	void Start () {
		min_x = Camera.main.transform.position.x - Camera.main.orthographicSize;
		max_x = Camera.main.transform.position.x + Camera.main.orthographicSize;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void SpawnCoin(){
		GameObject coin;
		var generate = Random.Range (1, 100);
		if (generate >= 98) {

			// get y position of camera
			var y = Camera.main.orthographicSize + Camera.main.transform.position.y + 1f;
			var x = Random.Range (min_x, max_x);

			coin = GameObject.Instantiate (coin_prefab);
			coin.transform.position = new Vector3 (x, y, -.1f);

		}
	}
}
