/* Project Name: Arcade 2D Platformer
 * Team Name: Monstrous Entertainment - Vex Team
 * Authors: Daniel Cox, Ben Topple
 * Created Date: January 30, 2022
 * Latest Update: February 11, 2022
 * Description: The class load the last checkpoint for the player, and UI data.
 * Notes: 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadCkeckpoint : MonoBehaviour
{
	private void Start()
	{
		//If last checkpoint doesn't equal 0, 0
		if (GameManager.instance.GetLastCheckpointPos() != new Vector2(0, 0))
		{
			//spawn the player at the last checkpoint
			gameObject.transform.position = GameManager.instance.GetLastCheckpointPos();
		}
		
    }

	private void Update()
	{
		//If the player dies, reload the scene
		if (PlayerBase.instance.GetIsRespawn())
		{
			//To the last checkpoint position
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

			//Set the player to the last checkpoint
			gameObject.transform.position = GameManager.instance.GetLastCheckpointPos();

			//Set the boolean flag to false
			PlayerBase.instance.SetIsRespawn(false);
		}
	}
}
