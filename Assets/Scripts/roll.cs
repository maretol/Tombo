﻿using UnityEngine;
using System.Collections;

public class roll : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(new Vector3(0.0f, 1.0f, 0.0f), 10.0f*Time.deltaTime);
	}
}
