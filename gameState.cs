using UnityEngine;
using System.Collections;

public class gameState : MonoBehaviour {


	// Declare properties
	private static gameState instance;

	// ---------------------------------------------------------------------------------------------------
	// gamestate()
	// --------------------------------------------------------------------------------------------------- 
	// Creates an instance of gamestate as a gameobject if an instance does not exist
	// ---------------------------------------------------------------------------------------------------
	public static gameState Instance
	{
		get
		{
			if(instance == null)
			{
				instance = new GameObject("gameState").AddComponent<gameState>();
			}
			
			return instance;
		}
	}	
	
	// Sets the instance to null when the application quits
	public void OnApplicationQuit()
	{
		instance = null;
	}

	// ---------------------------------------------------------------------------------------------------
	
	
	// ---------------------------------------------------------------------------------------------------
	// startState()
	// --------------------------------------------------------------------------------------------------- 
	// Creates a new game state
	// ---------------------------------------------------------------------------------------------------
	public void startState()
	{
		print ("Creating a new game state");

		Application.LoadLevel ("ballrunner");
	}
}
