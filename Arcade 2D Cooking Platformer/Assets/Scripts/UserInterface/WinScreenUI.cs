using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinScreenUI : MonoBehaviour
{
    //Class Variables 
    [SerializeField] private LevelLoader levelLoader;

    [SerializeField] private Text pointTotalText;

    public void activeMenu(bool flag)
    {
        pointTotalText.text = "Points: " + PointManger.instance.GetTolatPoints();

        //Enable or disable the game over screen.
        gameObject.SetActive(flag);
    }

    public void PlayAgain()
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
