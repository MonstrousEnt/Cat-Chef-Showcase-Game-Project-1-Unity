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
    public static LivesUI instance; //A static reference of the class

    [SerializeField] private Text LivesText;

    private void Awake()
    {
        //---Make sure there is only one instance of this class for each Scene.

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

    /// <summary>
    /// Update number of player lives in the UI
    /// </summary>
    /// <param name="lives"></param>
    public void SetLives(int lives)
	{
		LivesText.text = "x " + lives.ToString();
	}
}
