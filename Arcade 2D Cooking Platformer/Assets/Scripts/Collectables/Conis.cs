/* Project Name: Arcade 2D Platformer
 * Team Name: Monstrous Entertainment - Vex Team
 * Authors: Daniel Cox, Ben Topple
 * Created Date: January 30, 2022
 * Latest Update: February 11, 2022
 * Description: The class is the manager for collecting coins.
 * Notes: 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Conis : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            //Coin up go up by one and set it to the game manager
            int tempCoinNum = 1;
            GameManager.instance.SetCoinNum(GameManager.instance.GetCoinNum() + tempCoinNum);

            //Added the Ingredients to the total points
            PointManager.instance.SetTolatPoints(PointManager.instance.GetTolatPoints() + PointManager.instance.GetCoinPointNum());

            //play the sound
            AudioManager.instance.playAudio("coin1");

            //Set UI
            CollectablesUI.instance.SetText(GameManager.instance.GetCoinNum());

            //Destroy the game object
            gameObject.SetActive(false);
        }
    }
}
