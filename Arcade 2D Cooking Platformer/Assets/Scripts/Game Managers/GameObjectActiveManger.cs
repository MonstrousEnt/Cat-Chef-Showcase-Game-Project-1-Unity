/* Project Name: Arcade 2D Platformer
 * Team Name: Monstrous Entertainment - Vex Team
 * Authors: Daniel Cox, Ben Topple
 * Created Date: January 30, 2022
 * Latest Update: February 11, 2022
 * Description: The class is the manager for game object that been trigger 
 * Notes: Trigger are boolean flag are on or off. On means the game is destroy, off means the game object is live.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameObjectActiveManger : MonoBehaviour
{
    //Class Variables 
    public static GameObjectActiveManger instance; //A static reference of the class

    [Header("Trigger List")]
    [SerializeField] private List<bool> checkpointTriggerList;
    [SerializeField] private List<bool> enemyTriggerList;
    [SerializeField] private List<bool> ingredientsTiggerList;
    [SerializeField] private List<bool> healthPowerUpTriggerList;

    #region Getters and Setters
    public List<bool> GetCheckpointTriggerList() { return checkpointTriggerList; }
    public List<bool> GetEnemyTriggerList() { return enemyTriggerList; }
    public List<bool> GetIngredientsTiggerList() { return ingredientsTiggerList; }
    public List<bool> GetHealthPowerUpTriggerList() { return healthPowerUpTriggerList; }
    #endregion

    /// <summary>
    /// Reset all the game object active Triggers.
    /// </summary>
    /// <param name="CheckPointamount"></param>
    /// <param name="ingredinetAmount"></param>
    /// <param name="healthPowrUpAmount"></param>
    /// <param name="enemyAmount"></param>
    public void ResetAllGameObjectActiveTriggers(int checkpointAmount, int ingredinetAmount, int healthPowrUpAmount, int enemyAmount)
    {
        checkpointTriggerList.Clear();
        AddAllTriggers(checkpointAmount,checkpointTriggerList);

        ingredientsTiggerList.Clear();
        AddAllTriggers(ingredinetAmount,ingredientsTiggerList);

        healthPowerUpTriggerList.Clear();
        AddAllTriggers(healthPowrUpAmount, healthPowerUpTriggerList);

        enemyTriggerList.Clear();
        AddAllTriggers(enemyAmount, enemyTriggerList);
    }

    /// <summary>
    /// Added all Triggest to the trigger list
    /// </summary>
    /// <param name="amount"></param>
    /// <param name="triggerList"></param>
    public void AddAllTriggers(int amount, List<bool> triggerList)
    {
        for (int i = 0; i < amount; i++)
        {
            triggerList.Add(false);
        }
    }

    /// <summary>
    ///  Destroy Game object if already been collected
    /// </summary>
    /// <param name="TriggerList"></param>
    /// <param name="indexTriggerList"></param>
    /// <param name="maxCountTriggerList"></param>
    public void UpdateTrigger(List<bool> TriggerList, int indexTriggerList, int maxCountTriggerList, GameObject TriggergameObject)
    {
        if (TriggerList != null)
        {
            if (TriggerList.Count == maxCountTriggerList)
            {
                if (TriggerList[indexTriggerList] == true)
                {
                    Destroy(TriggergameObject);
                }
            }
        }
    }

    /// <summary>
    /// Game Object has been trigger. Set the boolean to false to destroy the object after the player respwan from a checkpoint.
    /// </summary>
    /// <param name="TriggerList"></param>
    /// <param name="indexTriggerList"></param>
    /// <param name="maxCountTriggerList"></param>
    /// <param name="flag"></param>
    public void SetTrigger(List<bool> TriggerList, int indexTriggerList, int maxCountTriggerList, bool flag)
    {
        if (TriggerList != null)
        {
            if (TriggerList.Count == maxCountTriggerList)
            {
               TriggerList[indexTriggerList] = flag;
            }
        }
    }

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
}
