/* Project Name: Arcade 2D Platformer
 * Team Name: Monstrous Entertainment - Vex Team
 * Authors: Daniel Cox, Ben Topple
 * Created Date: January 30, 2022
 * Latest Update: February 11, 2022
 * Description: The class is the manager for level 1.
 * Notes:  
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level1Manager : MonoBehaviour
{
    [Header("Level 1 Data")]
    [SerializeField] private Vector2 checkpointOnePos;
    [SerializeField] private string level1Music;

    private void Start()
    {
        //If the level has started
        if (GameManager.instance.GetLevelStarted())
        {
            //Reset default game data
            GameManager.instance.PlayLevelMusic(level1Music);

            GameManager.instance.ResetGameData();

            GameManager.instance.ResetBooleanFlags();

            GameObjectActiveManger.instance.ResetAllGameObjectActiveTriggers(GameObjectActiveManger.instance.GetCheckpointTriggerSize(), GameObjectActiveManger.instance.GetIngredientsTiggerSize(), GameObjectActiveManger.instance.GetHealthPowerUpTriggerSize(), GameObjectActiveManger.instance.GetEnemyTriggerSize());

            //Set the player to checkpoint one
            PlayerBase.instance.gameObject.transform.position = checkpointOnePos;

            //Turn of the boolean flag for when the level has started 
            GameManager.instance.SetLevelStarted(false);
        }
       


    }
}
