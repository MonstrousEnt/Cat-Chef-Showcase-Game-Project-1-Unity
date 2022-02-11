/* Project Name: Arcade 2D Platformer
 * Team Name: Monstrous Entertainment - Vex Team
 * Authors: Daniel Cox, Ben Topple
 * Created Date: January 30, 2022
 * Latest Update: February 11, 2022
 * Description: The class is the game manger for the level.
 * Notes: 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : GameData
{
    //Class Variables
    public static GameManager instance;

    [Header("Boolean Flags")]
    [SerializeField] private bool _restart = false;
    [SerializeField] private bool _levelStarted = false;

    #region Getters and Setters
    public void SetRestart(bool restart) { this._restart = restart; }
    public bool GetLevelStarted() { return _levelStarted; }
    public void SetLevelStarted(bool levelStarted) { this._levelStarted = levelStarted; }
    #endregion

    #region Reset Game Methods
    /// <summary>
    /// Reset the game when the level starts.
    /// </summary>
    public void ResetGameData()
    {
        //Reset Coins
        coinNum = 0;

        //Reset Lives
        LiveSystemManager.instance.ResetLives();

        //Reset Ingredient
        ingredinetsNum = 0;

        #region reset Ingredient UI
        for (int i = 0; i < ingredinetImagesActive.Count; i++)
        {
            ingredinetImagesActive[i] = false;
        }
        #endregion
    }

    /// <summary>
    /// Reset the boolean flag for the game.
    /// </summary>
    public void ResetBooleanFlags()
    {
        //Turn of the boolean flag for restart the game
        _restart = false;
    }

    /// <summary>
    /// Play the music as long level hasn't restart.
    /// </summary>
    public void PlayLevelMusic(string levelMusicName)
    {
        if (!_restart)
        {
            AudioManager.instance.SetAudioLoop(levelMusicName, false);
            AudioManager.instance.stopAudio(levelMusicName);

            AudioManager.instance.SetAudioLoop(levelMusicName, true);
            AudioManager.instance.playAudio(levelMusicName);
        }
    }
    #endregion

    #region Unity Methods
    private void Awake()
    {
        #region Singleton Reference
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

        //This won't get destroy when you switch scene
        DontDestroyOnLoad(gameObject);
        #endregion
    }
    #endregion
}
