using UnityEngine;
using System.Collections;

public class gameStart : MonoBehaviour {
	void OnGUI () 
	{
		if(GUI.Button(new Rect (30, 30, 150, 30), "Start Game"))
		{
			startGame();
		}

		GUI.TextField (new Rect (100, 100, 500, 100), 
		              	"You're a bouncy ball in a tube's world.\n" + 
						"Fall through the cracks and you're dead!\n" +
		               	"How far can you get?\n" +
						"Hold the left and right arrow keys to move.\n" +
						"Use the up arrow key to throttle.\n" +
						"Hold the space bar to float.\n");
	}
	
	private void startGame()
	{
		print("Starting game");
		
		DontDestroyOnLoad(gameState.Instance);
		gameState.Instance.startState();
	}
}