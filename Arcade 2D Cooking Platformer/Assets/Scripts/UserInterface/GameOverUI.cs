using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverUI : MonoBehaviour
{
    //Class Variables 
    [SerializeField] private LevelLoader levelLoader;

    public void activeMenu(bool flag)
    {
        //Enable or disable the game over screen.
        gameObject.SetActive(flag);
    }

    public void TryAgain()
    {
        //Close the game over screen.
        gameObject.SetActive(false);

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
