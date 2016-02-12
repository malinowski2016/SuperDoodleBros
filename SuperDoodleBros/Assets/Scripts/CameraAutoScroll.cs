using UnityEngine;
using System.Collections;

public class CameraAutoScroll : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		var cameraPosition = transform.localPosition;

		var maxHeight = 20.0;

		if (cameraPosition.y < maxHeight && GameObject.FindGameObjectWithTag("Player") != null) {
			transform.Translate ((Vector3.up * (float)(Time.deltaTime * 0.5)), Space.World);
		} else {
			
		}

	}
}
