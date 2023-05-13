/* Project Name: Arcade 2D Platformer
 * Team Name: Monstrous Entertainment - Vex Team
 * Authors: Daniel Cox, Ben Topple
 * Created Date: January 30, 2022
 * Latest Update: February 11, 2022
 * Description: The class trigger the player get a health power up.
 * Notes: 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPowerUp : MonoBehaviour
{
    //Class Variables
    [Header("Trigger Reference")]
    [SerializeField] private int indexHealthPowerUpTrigger; 

    private void Start()
    {
        GameObjectActiveManger.instance.UpdateTrigger(GameObjectActiveManger.instance.GetHealthPowerUpTriggers(), indexHealthPowerUpTrigger, GameObjectActiveManger.instance.GetHealthPowerUpTriggerSize(), gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    { 
        if (collision.tag == "Player")
        {
            //Added the power up to the player
            PlayerBase.instance.HealthPowerUp(gameObject, indexHealthPowerUpTrigger, GameObjectActiveManger.instance.GetHealthPowerUpTriggerSize());
        }
    }
}
