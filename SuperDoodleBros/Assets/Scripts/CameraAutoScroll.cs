using UnityEngine;
using System.Collections;

public class CameraAutoScroll : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		var cameraPosition = transform.localPosition;

		var maxY = Camera.main.orthographicSize + Camera.main.transform.position.y;
		float camera_speed;

		var maxHeight = 20.0;

		if (GameObject.FindGameObjectWithTag("Player") != null) {
			var player_y = GameObject.FindGameObjectWithTag ("Player").gameObject.transform.position.y;
			if (player_y > (maxY - 2.5f)) {
				camera_speed = 2.5f;
			} else {
				camera_speed = 0.5f;

			}
			transform.Translate ((Vector3.up * (float)(Time.deltaTime * camera_speed)), Space.World);
		} else{
			
		}

	}
}
