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
        //if last checkpoint doesn't equal 0, 0, 0
        if (GameManager.instance.GetLastCheckpointPos() != new Vector2(0, 0))
        {
            //Set the players position to our last checkpoint position
            gameObject.transform.position = GameManager.instance.GetLastCheckpointPos();
        }

    }

	private void Update()
	{
		//If the player dies, reload the scene
		if (player.isRespawn)
		{
			//To the last checkpoint position
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

			Debug.Log("Checkpoint loaded.");

			gameObject.transform.position = GameManager.instance.GetLastCheckpointPos();

			Debug.Log(gameObject.transform.position);

			LivesUI.instance.SetLives(LiveSystemManager.instance.GetLivesCount());
			CollectablesUI.instance.SetText(GameManager.instance.GetCoinNum());
			LevelObjectiveCakeIngredientsUI.instance.UpdateImage();


			//Set the boolean flag to false
			player.isRespawn = false;
		}
	}
}
