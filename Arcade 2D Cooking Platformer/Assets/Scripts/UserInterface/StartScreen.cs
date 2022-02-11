/* Project Name: Arcade 2D Platformer
 * Team Name: Monstrous Entertainment - Vex Team
 * Authors: Daniel Cox, Ben Topple
 * Created Date: January 30, 2022
 * Latest Update: February 11, 2022
 * Description: The manger for start screen.
 * Notes: 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartScreen : MonoBehaviour
{
	//Class Variables
	[SerializeField] private LevelLoader _levelLoader;

	void Update()
	{
		//If the user press any key or mouse button
		if (Input.anyKeyDown)
		{
			//load the Main Menu 
			_levelLoader.LoadNextLevel("Level 1");
		}
	}
}
