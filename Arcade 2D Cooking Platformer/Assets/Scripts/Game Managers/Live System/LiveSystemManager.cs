using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiveSystemManager : MonoBehaviour
{
    public static LiveSystemManager instance; //A static reference of the class

    [SerializeField] private int _livesCount = 4;
    [SerializeField] private int _defauftLives = 4;

    //Getters and Setters
    public int GetLivesCount() { return _livesCount; }
    public void SetLivesCount(int livesCount) { this._livesCount = livesCount; }
    public int GetDefauftLives() { return _defauftLives; }


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


        //This won't get destroy when you switch scene
        DontDestroyOnLoad(gameObject);
    }

    public void LoseALife()
    {
        //Life count goes up by one
        _livesCount--;

        //Set Lives UI
        UIEvents.instance.SetLivesText(_livesCount);
    }


    public void OutOfLives()
    {
        //Set Lives Count to 0
        _livesCount = 0;

        //Pause the game
        SettingManager.instance.ActivePause(true, 0f);

        //Enable the game over screen
        EndStateScreenUI.instance.activeMenu(true);

        //Player can no longer move.
        PlayerBase.instance.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
    }

    /// <summary>
    /// Reset the lives counter to default lives and update the UI.
    /// </summary>
    public void ResetLives()
    {
        //Reset the lives count.
        _livesCount = _defauftLives;

        UIEvents.instance.SetLivesText(_livesCount);
    }
}
