using UnityEngine;
using System.Collections;

public class PlatformManager : MonoBehaviour {

	private Vector3 _NextSpawn = new Vector3 (0, -1, 0);

	public GameObject platform_prefab;
	public float SpawnDistance = 5;

	public float MinWidth = 5; 
	public float MaxWidth = 10;

	public float MinDistance = 2;
	public float MaxDistance = 10;

	public float MinX = -10;
	public float MaxX = 10;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		var maxY = Camera.main.orthographicSize + Camera.main.transform.position.y;

		while ((_NextSpawn.y - maxY) < SpawnDistance) {
			SpawnNewPlatform ();
		}

	}

	private void SpawnNewPlatform(){
		var platform = MakePlatform ();
		platform.transform.position = _NextSpawn;

		//var offset = new Vector3 (Random.Range (MinX, MaxX), Random.Range (MinDistance, MaxDistance));
		//_NextSpawn = new Vector3(Random.Range (MinX, MaxX), Random.Range (MinDistance, MaxDistance) + );
		_NextSpawn.x = (Random.Range(MinX, MaxX));
		_NextSpawn.y += (float) System.Math.Round(Random.Range (MinDistance, MaxDistance));
	}

	private GameObject MakePlatform(){
		GameObject new_plat = GameObject.Instantiate (platform_prefab);
		new_plat.transform.localScale = new Vector3 (Random.Range (MinWidth, MaxWidth), 0.1F, 1);

		return new_plat;
	}
}
