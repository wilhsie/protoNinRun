using UnityEngine;
using System.Collections;

public class playerController : MonoBehaviour {

	public float speed = 10.0f;
	public float tilt = 2.0f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");
		float hmovement = moveHorizontal * speed;
		float vmovement = moveVertical * speed;
		rigidbody.velocity = new Vector3 (hmovement, vmovement, 0.0f);
		float tiltZ = rigidbody.velocity.x * -tilt;
		rigidbody.rotation = Quaternion.Euler (0.0f, 0.0f, tiltZ);

	}
}
