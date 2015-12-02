using UnityEngine;
using System.Collections;

public class fallFaster : MonoBehaviour {

	public float forceValue;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		rigidbody.AddForce (-Vector3.up * forceValue);
	}
}
