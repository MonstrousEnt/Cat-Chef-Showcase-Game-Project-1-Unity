/* Project Name: Arcade 2D Platformer
 * Team Name: Monstrous Entertainment - Vex Team
 * Authors: Daniel Cox, Charles Pink
 * Created Date:  July 25, 2021
 * Latest Update: February 11, 2022
 * Description: The class for loading the levels.
 * Notes: The class for manger the game settings.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingManager : MonoBehaviour
{
	//Class Variables 
	public static SettingManager instance { private set; get; }
	[SerializeField] private int _fps;
	[SerializeField] private bool _gameIsPause = false;

	private void Awake()
	{
		//If there is no instance of the object
		if (instance == null)
		{
			//Set an instance of it 
			instance = this;
		}

		//Else, if there's already an instance
		else
		{
			//Destroy it
			Destroy(gameObject);
			return;
		}
	}

	private void Start()
	{
		//Unpause the game
		ActivePause(false, 1f);

		//Locks FPS to 60.
		FPSLock();
	}

	/// <summary>
	/// The fps lock for the game
	/// </summary>
	private void FPSLock()
	{
		//Disable vSync.
		QualitySettings.vSyncCount = 0;

		//Setting application frame rate.
		Application.targetFrameRate = _fps;
	}

	/// <summary>
	/// Pause or Unpause the game
	/// </summary>
	/// <param name="flag"></param>
	/// <param name="timeScale"></param>
	public void ActivePause(bool flag, float timeScale)
	{
		_gameIsPause = flag;
		Time.timeScale = timeScale;
	}

}
