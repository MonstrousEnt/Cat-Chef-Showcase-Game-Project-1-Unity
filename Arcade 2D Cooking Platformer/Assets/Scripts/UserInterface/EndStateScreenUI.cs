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
    [SerializeField] private Text _pointTotalText;

    private void Start()
    {
        UIEvents.instance.onActiveEndSateMenu.AddListener(ActiveMenu);

        //Disable the menu
        gameObject.SetActive(false);
    }

    /// <summary>
    /// Enable or disable the menu.
    /// </summary>
    /// <param name="flag"></param>
    public override void ActiveMenu(bool flag)
    {
        //Show the full total of points in the UI
        _pointTotalText.text = "Points: " + PointManager.instance.GetTolatPoints();

        //Enable or disable menu
        gameObject.SetActive(flag);
    }

    private void OnDestroy()
    {
        UIEvents.instance.onActiveEndSateMenu.RemoveListener(ActiveMenu);
    }

}