using UnityEngine;
using System.Collections;

public class followPlayer : MonoBehaviour {

	public GameObject player;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		float playerX = player.transform.position.x;
		float playerY = player.transform.position.y;
		float playerZ = player.transform.position.z;
		transform.position = new Vector3 (playerX, playerY, playerZ - 10);
	}
}
