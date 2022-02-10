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
    [SerializeField] private List<bool> _checkpointTrigger;
    [SerializeField] private List<bool> _enemyTrigger;
    [SerializeField] private List<bool> _ingredientsTigger;
    [SerializeField] private List<bool> _healthPowerUpTrigger;

    [Header("Trigger List Size")]
    [SerializeField] private int _checkpointTriggerSize;
    [SerializeField] private int _enemyTriggerSize;
    [SerializeField] private int _ingredientsTiggerSize;
    [SerializeField] private int _healthPowerUpTriggerSize;

    #region Getters and Setters
    public List<bool> GetCheckpointTrigger() { return _checkpointTrigger; }
    public List<bool> GetEnemyTrigger() { return _enemyTrigger; }
    public List<bool> GetIngredientsTigger() { return _ingredientsTigger; }
    public List<bool> GetHealthPowerUpTrigger() { return _healthPowerUpTrigger; }
    public int GetCheckpointTriggerSize() { return _checkpointTriggerSize; }
    public int GetEnemyTriggerSize() { return _enemyTriggerSize; }
    public int GetIngredientsTiggerSize() { return _ingredientsTiggerSize; }
    public int GetHealthPowerUpTriggerSize() { return _healthPowerUpTriggerSize; }
    #endregion

    /// <summary>
    /// Reset all the game object active Triggers.
    /// </summary>
    /// <param name="checkpointTriggerSize"></param>
    /// <param name="ingredientsTiggerSize"></param>
    /// <param name="healthPowerUpTriggerSize"></param>
    /// <param name="enemyTriggerSize"></param>
    public void ResetAllGameObjectActiveTriggers(int checkpointTriggerSize, int ingredientsTiggerSize, int healthPowerUpTriggerSize, int enemyTriggerSize)
    {
        _checkpointTrigger.Clear();
        addAllTriggers(checkpointTriggerSize,_checkpointTrigger);

        _ingredientsTigger.Clear();
        addAllTriggers(ingredientsTiggerSize, _ingredientsTigger);

        _healthPowerUpTrigger.Clear();
        addAllTriggers(healthPowerUpTriggerSize, _healthPowerUpTrigger);

        _enemyTrigger.Clear();
        addAllTriggers(enemyTriggerSize, _enemyTrigger);
    }

    /// <summary>
    /// Added all Triggest to the trigger list
    /// </summary>
    /// <param name="triggerSize"></param>
    /// <param name="triggerList"></param>
    private void addAllTriggers(int triggerSize, List<bool> triggerList)
    {
        for (int i = 0; i < triggerSize; i++)
        {
            triggerList.Add(false);
        }
    }

    /// <summary>
    ///  Destroy the game object if already been collected
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
