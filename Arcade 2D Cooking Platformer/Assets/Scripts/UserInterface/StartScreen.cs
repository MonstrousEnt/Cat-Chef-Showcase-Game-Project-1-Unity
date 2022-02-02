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
