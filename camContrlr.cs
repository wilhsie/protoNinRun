﻿using UnityEngine;
using System.Collections;

public class camContrlr : MonoBehaviour {

	public GameObject player;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		transform.position = new Vector3 (player.rigidbody.position.x, transform.position.y, transform.position.z);
	}
}
