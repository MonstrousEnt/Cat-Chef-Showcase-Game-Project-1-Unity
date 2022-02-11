/* Name: Daniel Cox, Charles Pink
 * Date: July 25, 2021
 * Description: This manager for game settings
 * Notes: 
 */

//Libraries
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingManager : MonoBehaviour
{
	//Class Variables 
	public static SettingManager instance { private set; get; }
	[SerializeField] private int fps;
	[SerializeField] bool gameIsPause = false;


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

	private void FPSLock()
	{
		//Disable vSync.
		QualitySettings.vSyncCount = 0;

		//Setting application frame rate.
		Application.targetFrameRate = fps;
	}

	public void ActivePause(bool flag, float timeScale)
	{
		gameIsPause = flag;
		Time.timeScale = timeScale;
	}

}
