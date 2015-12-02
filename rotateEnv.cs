using UnityEngine;
using System.Collections;

public class rotateEnv : MonoBehaviour {
	// Use this for initialization
	float zRotation = 90.0f;
	public GameObject centerpoint;
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.RotateAround(centerpoint.transform.position, Vector3.forward, zRotation * Time.deltaTime);
	}
}
