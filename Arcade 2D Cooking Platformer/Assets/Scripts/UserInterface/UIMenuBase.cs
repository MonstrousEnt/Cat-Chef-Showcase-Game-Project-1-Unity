/* Project Name: Arcade 2D Platformer
 * Team Name: Monstrous Entertainment - Vex Team
 * Authors: Daniel Cox, Ben Topple
 * Created Date: January 30, 2022
 * Latest Update: February 11, 2022
 * Description: The class is the base class for Menu UI.
 * Notes: 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIMenuBase : MonoBehaviour
{
    //Class Arables 
    [SerializeField] protected LevelLoader levelLoader;

    /// <summary>
    /// Enable or disable the menu.
    /// </summary>
    /// <param name="flag"></param>
    public virtual void  activeMenu(bool flag)
    {
        //Enable or disable menu
        gameObject.SetActive(flag);
    }


    /// <summary>
    /// Go back the current level
    /// </summary>
    public void BackToGame()
    {
        //Unpause the game
        SettingManager.instance.ActivePause(false, 1f);

        //Disable the menu
        gameObject.SetActive(false);
    }

    /// <summary>
    /// Restart the level
    /// </summary>
    public void Restart(string currentLevel)
    {
        //Unpause the game
        SettingManager.instance.ActivePause(false, 1f);

        //restart the level when this boolean flag is true.
        GameManager.instance.SetRestart(true);

        //Re-load the level
        levelLoader.LoadNextLevel(currentLevel);
    }

    /// <summary>
    /// Quit the game
    /// </summary>
    public void QuitGame()
    {
        //Disable the menu
        gameObject.SetActive(false);

        //Quit the game.
        Debug.Log("Quiting Game!");
        Application.Quit();
    }
}
