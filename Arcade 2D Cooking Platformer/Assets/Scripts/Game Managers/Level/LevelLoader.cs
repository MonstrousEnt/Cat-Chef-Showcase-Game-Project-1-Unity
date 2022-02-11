/* Project Name: Arcade 2D Platformer
 * Team Name: Monstrous Entertainment - Vex Team
 * Authors: Daniel Cox, Ben Topple
 * Created Date:  December 8, 2021
 * Latest Update: February 11, 2022
 * Description: The class for loading the levels.
 * Notes: Level Load Tutorial Used: https://youtu.be/CE9VOZivb3I
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader: MonoBehaviour
{
	//Class Variables
	//[SerializeField] private Animator _animator; 
	[SerializeField] private float _transtionTime = 1f; 

	/// <summary>
	/// Load the next scene.
	/// </summary>
	/// <param name="sceneName"></param>
	public void LoadNextLevel(string sceneName)
	{
		LoadLevel(sceneName);
	}

	/// <summary>
	/// Load the next scene, and run the cross fade transition before the next level load.
	/// </summary>
	/// <param name="sceneName"></param>
	/// <returns></returns>
	private void LoadLevel(string sceneName)
	{
		////Play the transition
		//_animator.SetTrigger("StartCrossfade");

		////Wait for a couple seconds
		//yield return new WaitForSeconds(_transtionTime);

		//The level has started, set the boolean to true
		GameManager.instance.SetLevelStarted(true);

		//Load the next scene
		SceneManager.LoadScene(sceneName);
	}
}
