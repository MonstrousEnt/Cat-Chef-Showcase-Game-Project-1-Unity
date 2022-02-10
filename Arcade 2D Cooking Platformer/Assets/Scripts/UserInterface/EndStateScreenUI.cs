/* Project Name: Arcade 2D Platformer
 * Team Name: Monstrous Entertainment - Vex Team
 * Authors: Daniel Cox, Ben Topple
 * Created Date: January 30, 2022
 * Latest Update: February 11, 2022
 * Description: The class is the UI class for end state screen.
 * Notes: 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndStateScreenUI : UIMenuBase
{
    //Class Variables 
    public static EndStateScreenUI instance; 

    [SerializeField] private Text pointTotalText;

    private void Awake()
    {
        #region Singleton Reference
        if (instance == null)
        {
            instance = this;
        }
        #endregion
    }

    private void Start()
    {
        //Disable the menu
        gameObject.SetActive(false);
    }


    /// <summary>
    /// Enable or disable the menu.
    /// </summary>
    /// <param name="flag"></param>
    public override void activeMenu(bool flag)
    {
        //Show the full total of points in the UI
        pointTotalText.text = "Points: " + PointManager.instance.GetTolatPoints();

        //Enable or disable menu
        gameObject.SetActive(flag);
    }

    private void OnDestroy()
    {
        //Set the singleton reference to null when the game object destroy
        instance = null;
    }

}