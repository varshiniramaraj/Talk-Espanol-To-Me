﻿using UnityEngine;
using System.Collections;

public class Rotate : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
	{
		transform.Rotate (0,0,100*Time.deltaTime); //rotates 50 degrees per second around z axis
	}
}
