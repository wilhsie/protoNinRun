using UnityEngine;
using System.Collections;

public class spawnEnv : MonoBehaviour
{
	public GameObject[] prefab;       // prefab we're spawning
	public float spawnSeconds = 0.675f;      // spawn every # seconds
	public float offs;
	public float amp;

	public float hamp;
	public float hoffs;

	private float timeElapsed;      // time elapsed - used for our timer
	private float counter;          // counter - used for our timer

	public float fuel;
	
	// Use this for initialization
	void Start()
	{
		// default our variables to zero at launch
		timeElapsed = 0.0f;
		counter = 0.0f;
		fuel = 100.0f;
	}
	
	// Update is called once per frame
	void Update()
	{
		print (fuel);
		if (fuel > 0) {
				if (Input.GetButtonDown ("Throttle")) {
						spawnSeconds -= 0.5f;
				} else if (Input.GetButtonUp ("Throttle")) {
						spawnSeconds += 0.5f;
				}
		}
		// spawnSeconds -= (Input.GetAxis ("Jump"));
		// create elapsed time by adding delta time
		timeElapsed += Time.deltaTime;

		print (Time.timeScale);

		Vector3 sineWave = new Vector3 (hamp * Mathf.Sin (timeElapsed + 1) + hoffs, 
		                                amp * Mathf.Sin(timeElapsed + 3) + offs, 
		                                transform.position.z);

		transform.position = sineWave;
		
		// if elapsed time minus counter is greater than spawn secods, do something...
		if (timeElapsed - counter > spawnSeconds)
		{
			// spawn the prefab we referenced in this object's inspector
			// set the prefab's position & rotation to match the spawner
			Instantiate(prefab[Random.Range (0, prefab.Length - 1)], transform.position, transform.rotation);
			
			// sync our counter with elapsed time to reset our timer
			counter = timeElapsed;
		}
	}
}
