﻿using UnityEngine;
using System.Collections;

public class ShowMessage : MonoBehaviour {

	public float time = 5f;

	void Start () {
		Destroy (gameObject, time);
	}

 } 