using UnityEngine;
using System.Collections;

public class spawnDanger : MonoBehaviour
{
	public GameObject prefab;       // prefab we're spawning
	float spawnSeconds;      // spawn every # seconds
	
	private float timeElapsed;      // time elapsed - used for our timer
	private float counter;          // counter - used for our timer
	
	// Use this for initialization
	void Start()
	{
		// default our variables to zero at launch
		timeElapsed = 0.0f;
		counter = 0.0f;
	}
	
	// Update is called once per frame
	void Update()
	{
		spawnSeconds = Random.Range (1, 10);
		// create elapsed time by adding delta time
		timeElapsed += Time.deltaTime;
		
		// if elapsed time minus counter is greater than spawn secods, do something...
		if (timeElapsed - counter > spawnSeconds)
		{
			// spawn the prefab we referenced in this object's inspector
			// set the prefab's position & rotation to match the spawner
			Instantiate(prefab, transform.position, transform.rotation);
			
			// sync our counter with elapsed time to reset our timer
			counter = timeElapsed;
		}
	}
}