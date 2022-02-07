using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverUI : MonoBehaviour
{
    //Class Variables 
    public static GameOverUI instance; //A static reference of the class

    [SerializeField] private LevelLoader levelLoader;

    [SerializeField] private Text pointTotalText;

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

    private void Start()
    {
        gameObject.SetActive(false);
    }

    public void activeMenu(bool flag)
    {
        pointTotalText.text = "Points: " + PointManger.instance.GetTolatPoints();

        //Enable or disable the game over screen.
        gameObject.SetActive(flag);
    }

    public void TryAgain()
    {
        //Close the game over screen.
        gameObject.SetActive(false);

        SettingManager.instance.ActivePause(false, 1f);

        GameManager.instance.SetRestart(true);

        //Re-load the level
        levelLoader.LoadNextLevel("Level 1");
    }

    public void QuitGame()
    {
        //Close the game over screen.
        gameObject.SetActive(false);

        //Quit the game.
        Debug.Log("Quiting Game!");
        Application.Quit();
    }
}
