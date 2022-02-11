/* Project Name: Arcade 2D Platformer
 * Team Name: Monstrous Entertainment - Vex Team
 * Authors: Daniel Cox, Ben Topple
 * Created Date: January 30, 2022
 * Latest Update: February 11, 2022
 * Description: The show how many player has left in the UI. 
 * Notes: 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LivesUI : MonoBehaviour
{
    //Class Variables   
    [SerializeField] private Text _livesText;

    private void Start()
    {
        UIEvents.instance.onSetLivesText.AddListener(setLives);

        setLives(LiveSystemManager.instance.GetLivesCount());
    }

    /// <summary>
    /// Update number of player lives in the UI
    /// </summary>
    /// <param name="lives"></param>
    private void setLives(int lives)
	{
		_livesText.text = "x " + lives.ToString();
	}

    private void OnDestroy()
    {
        UIEvents.instance.onSetLivesText.RemoveListener(setLives);
    }
}
