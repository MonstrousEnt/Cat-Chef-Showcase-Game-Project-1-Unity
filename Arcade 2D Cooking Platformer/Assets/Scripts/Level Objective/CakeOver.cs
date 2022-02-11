using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/* Project Name: Arcade 2D Platformer
 * Team Name: Monstrous Entertainment - Vex Team
 * Authors: Daniel Cox, Ben Topple
 * Created Date: January 30, 2022
 * Latest Update: February 11, 2022
 * Description: The class for when the player completes the game.
 * Notes: 
 */

public class CakeOver : MonoBehaviour
{
    //Class Variables
    [SerializeField] private Animator animator;
    [SerializeField] private GameObject CakeGameObject;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    /// <summary>
    /// Completed game if the player has collected all Ingredients.
    /// </summary>
    /// <param name="ingredinetsNum"></param>
    /// <param name="maxIngredients"></param>
    private void gameCompleted(int ingredinetsNum, int maxIngredients)
    {
        if (ingredinetsNum == maxIngredients)
        {
            animator.SetTrigger("openOven");
            CakeGameObject.SetActive(true);

            UIEvents.instance.ActiveEndSateMenu(true);
        }           
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            gameCompleted(GameManager.instance.GetIngredinetsNum(), GameManager.instance.GetMaxIngredients());
        }
    }

}
