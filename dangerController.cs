using UnityEngine;
using System.Collections;

public class dangerController : MonoBehaviour
{
	public float speed;             // object's speed: adjust in Inspector

	private Vector3 pos;            // position of rigidbody
	private float length;           // length of object

	
	// Use this for initialization
	void Start()
	{
		// copy our object's default rigidbody position
		pos = rigidbody.position;
		
		// fetch the object's length.  we'll use this to determine
		// if we've past our camera...
		length = renderer.bounds.size.z;
	}
	
	// Update is called once per frame
	void Update()
	{
		speed += Input.GetAxis("Jump");

		// move our z towards the camera
		// to do this, we subject our position by the speed
		pos.z -= speed;
		
		// let's update our rigidbody's position
		// in this exercise, we're just moving the z.  however, we
		// have cached the X and Y in our start function.
		rigidbody.position = new Vector3(pos.x, pos.y, pos.z);
		
		// if our object's length is past our camera (0,0,0), then...
		if (pos.z < -length)
		{
			// delete our object
			Destroy(gameObject);
		}

	}
}