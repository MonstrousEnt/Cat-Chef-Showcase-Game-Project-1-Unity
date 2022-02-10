/* Project Name: Arcade 2D Platformer
 * Team Name: Monstrous Entertainment - Vex Team
 * Authors: Daniel Cox, Ben Topple
 * Created Date: January 30, 2022
 * Latest Update: February 11, 2022
 * Description: The class is the UI class for pause screen.
 * Notes: 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMneu : UIMenuBase
{

    /// <summary>
    /// Enable or disable the menu.
    /// </summary>
    /// <param name="flag"></param>
    public override void activeMenu(bool flag)
    {
        ///Pause the game
        SettingManager.instance.ActivePause(true, 0f);

        //Enable or disable menu
        gameObject.SetActive(flag);
    }
}
