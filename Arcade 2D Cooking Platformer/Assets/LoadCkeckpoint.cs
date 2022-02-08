using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadCkeckpoint : MonoBehaviour
{
	//Class Variables 
	private PlayerBase player; //Reference to the base player class

	private void Awake()
	{
		//Get the reference to  the base player class
		player = GetComponent<PlayerBase>();
	}

	private void Start()
	{
		////if last checkpoint doesn't equal 0, 0, 0
		//if (LevelEvents.instance.GetLastCheckPointPos() != new Vector3(0, 0, 0))
		//{
		//	//Set the players position to our last checkpoint position
		//	transform.position = LevelEvents.instance.GetLastCheckPointPos();
		//}

	}

	private void Update()
	{
		//If the player dies, reload the scene
		if (player.isRespawn)
		{
			//To the last checkpoint position
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

			Debug.Log("Checkpoint loaded.");

			//Set the boolean flag to false
			player.isRespawn = false;
		}
	}
}
