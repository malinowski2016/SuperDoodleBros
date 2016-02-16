using UnityEngine;
using System.Collections.Generic;

public class PlatformManager : MonoBehaviour {

	private Vector3 _NextSpawn = new Vector3 (0, -1, 0);

	public GameObject platform_prefab;
	public float SpawnDistance = 5;

	private Queue<GameObject> _InUse = new Queue<GameObject>();
	private Queue<GameObject> _Available = new Queue<GameObject>();

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
		var minY = Camera.main.transform.position.y - Camera.main.orthographicSize - 1;

		if (_InUse.Count > 0) {
			// if platofrm is below minY, delete it
			float first_y = _InUse.Peek().transform.position.y;
			if (first_y < minY) {
				 RecyclePlatform ();
			}
		}

		if ((_NextSpawn.y - maxY) < SpawnDistance) {
			SpawnNewPlatform ();
		}

	}

	private void RecyclePlatform(){
		GameObject obj = _InUse.Dequeue ();
		obj.SetActive (false);
		_Available.Enqueue (obj);
	}

	private void SpawnNewPlatform(){

		GameObject platform;
		if (_Available.Count > 0) {
			platform = _Available.Dequeue ();
			platform.SetActive (true);
		} else {
			platform = GameObject.Instantiate (platform_prefab);
		}

		_InUse.Enqueue (platform);
		MovePlatformToPosition (platform);
	}

	private void MovePlatformToPosition(GameObject platform){
		platform.transform.position = _NextSpawn;
		platform.transform.localScale = new Vector3 (
			Random.Range (MinWidth, MaxWidth),
			0.1f,
			1f);

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
