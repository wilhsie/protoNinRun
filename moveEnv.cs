using UnityEngine;
using System.Collections;

public class moveEnv : MonoBehaviour {

	// Speed datatypes
	public float speed = 0.5f;
	public float throttle = 5.0f;
	Vector3 pos;
	float length;

	// Rotate datatypes
	float zRotation = 90.0f;
	public GameObject centerpoint;

	// Use this for initialization
	void Start () {
		pos = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		// Rotate the env
		transform.RotateAround(centerpoint.transform.position, Vector3.forward, zRotation * Time.deltaTime);

		// Move the env along the z axis
		speed += (throttle * Input.GetAxis ("Vertical"));

		pos.z -= speed;

		transform.position = new Vector3 (pos.x, pos.y, pos.z);
		if (pos.z < -100) {
			Destroy(gameObject);
		}
	}
}
