using UnityEngine;
using System.Collections;

public class bpController : MonoBehaviour {

	public float speed = 10.0f;
	public int lives;
	public float forceOfG = -4.8f;
	public int loseIfFallBelow = -4;
	public int loseIfFallBehind = 16;
	public GameObject safePoint;
	public float fly = 250;
	public AudioSource bgMusic;

	public GUIText gameOver;
	public GUIText hiBounceCombo;
	public GUIText displayLives;
	public GUIText displayScore;

	int score;
	int hiBounceBonus;
	float timeElapsed;

	//bool inSafeZone = false;
	
	// Use this for initialization
	void Start () {
		lives = 3;
		rigidbody.velocity = new Vector3 (0, -10, 0);
	}
	
	// Update is called once per frame
	void Update () {
		// Create timeElapsed
		timeElapsed += Time.deltaTime;

		// Calculate high bounce combos
		hiBounceCombo.enabled = false;
		if (rigidbody.position.y > 7) {
			hiBounceCombo.enabled = true;
			hiBounceCombo.text = "High Bounce Bonus! +1 per frame ;)";
			score += 1;
		}
		// Display score and lives left
		displayScore.text = "SCORE: "+ score.ToString ();
		displayLives.text = "LIVES LEFT: " + lives.ToString ();
		gameOver.enabled = false;

		// Check for flying
		if (Input.GetButtonDown ("Jump")) {
			print ("flying");
			print (rigidbody.drag);
			rigidbody.drag = fly;
		}
		if (Input.GetButtonUp ("Jump")){
			rigidbody.drag = 0;
		}

		// Adjust gravity
		float grav = rigidbody.velocity.y - (2 * forceOfG * Time.deltaTime);
		float hmovement = Input.GetAxis ("Horizontal") * speed;
		rigidbody.velocity = new Vector3 (hmovement, grav, 0);

		// Game over condition
		if (transform.position.y < loseIfFallBelow || transform.position.z < loseIfFallBehind) {
			if (lives > 0){
				//if (safePoint.collider.CompareTag("centerpoint")){
					rigidbody.position = new Vector3 (0, 5, 25);
				//}
				lives = lives - 1;
				print ("LIVES LEFT:");
				print (lives);
			}
			else {
				gameOver.enabled = true;
				gameOver.text = "GAME OVER\n press 'r' to replay";
				bgMusic.mute = true;
				print ("GAME OVER");
				if(Input.GetButtonDown ("replay")){
					Application.LoadLevel("ballrunner");
				}
			}

		}
	}
	
	void OnTriggerEnter(Collider col){
		if (col.tag == "centerpoint") {
			score += 1;
		}
	}

	/*
	void OnTriggerStay(Collider col){
		if (col.tag == "centerpoint") {
			inSafeZone = true;
		} 
	}

	void OnTriggerExit(Collider col){
		if (col.tag == "centerpoint") {
			inSafeZone = false;
		}
	}

	/*
	void OnCollisionStay(Collision col){
		if (col.gameObject.tag == "GroundPiece") {
			Vector3 jump = new Vector3 (0, Input.GetAxis ("Vertical") * jforce * Time.deltaTime, 0);
			rigidbody.AddForce (jump);
		}
	}
	*/
}
