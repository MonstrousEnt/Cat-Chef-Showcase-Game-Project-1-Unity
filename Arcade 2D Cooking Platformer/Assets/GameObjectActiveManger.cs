using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameObjectActiveManger : MonoBehaviour
{
    public static GameObjectActiveManger instance; //A static reference of the class

    [SerializeField] private List<bool> checkpointTriggerList;
    [SerializeField] private List<bool> enemyTriggerList;
    [SerializeField] private List<bool> coinTriggerList;
    [SerializeField] private List<bool> ingredientsTiggerList;
    [SerializeField] private List<bool> healthPowerUpTriggerList;

    public List<bool> GetCheckpointTriggerList() { return checkpointTriggerList; }
    public List<bool> GetEnemyTriggerList() { return enemyTriggerList; }
    public List<bool> GetCoinTriggerList() { return coinTriggerList; }
    public List<bool> GetIngredientsTiggerList() { return ingredientsTiggerList; }
    public List<bool> GetHealthPowerUpTriggerList() { return healthPowerUpTriggerList; }

    public void AddAllTriggers(int amount, List<bool> triggerList)
    {
        for (int i = 0; i < amount; i++)
        {
            triggerList.Add(false);
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
