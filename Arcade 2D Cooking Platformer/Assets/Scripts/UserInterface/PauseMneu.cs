using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMneu : MonoBehaviour
{
    [SerializeField] private LevelLoader levelLoader;

    public void activeMenu(bool flag)
    {
        //Enable or disable the game over screen.
        gameObject.SetActive(flag);
    }

    public void BackToGame()
    {
        SettingManager.instance.ActivePause(false, 1f);

        gameObject.SetActive(false);
    }

    public void Restart()
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
