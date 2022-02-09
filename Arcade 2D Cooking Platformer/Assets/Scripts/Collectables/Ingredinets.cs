/* Project Name: Arcade 2D Platformer
 * Team Name: Monstrous Entertainment - Vex Team
 * Authors: Daniel Cox, Ben Topple
 * Created Date: January 30, 2022
 * Latest Update: February 11, 2022
 * Description: The class is the manager for collecting ingredients. 
 * Notes: 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ingredinets : MonoBehaviour
{
    //Class Variables 
    [Header("Data Info")]
    [SerializeField] private string IngredinetName;

    [Header("UI Images")]
    [SerializeField] private int ingredinetImagesActiveIndex;
    [SerializeField] private GameObject imageGameObject;

    [Header("Trigger Reference")]
    [SerializeField] private int indexIngredientsTiggerList; //id of the checkpoint
    [SerializeField] private int maxCountIngredientTiggerList;

    private void Start()
    {
        GameObjectActiveManger.instance.UpdateTrigger(GameObjectActiveManger.instance.GetIngredientsTiggerList(), indexIngredientsTiggerList, maxCountIngredientTiggerList, gameObject);

        #region Get Ingredients UI Image from Game Manager
        for (int i = 0; i < GameManager.instance.GetIngredientNameList().Count; i++)
        {
            if (IngredinetName == GameManager.instance.GetIngredientNameList()[i])
            {
                imageGameObject = GameManager.instance.GetIngredinetImages()[i];
            }
        }
       #endregion
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            CollectItem();
        }
    }

    private void CollectItem()
    {
        //Ingredients up go up by one and set it to the game manager
        int tempFoundIngredinetsNum = 1;
        GameManager.instance.SetFoundIngredinetsNum(GameManager.instance.GetFoundIngredinetsNum() + tempFoundIngredinetsNum);

        //Added the Ingredients to the total points
        PointManager.instance.SetTolatPoints(PointManager.instance.GetTolatPoints() + PointManager.instance.GetIngredientPointNum());

        //Play the sound
        AudioManager.instance.playAudio("getitem");

        //Set UI
        LevelObjectiveCakeIngredientsUI.instance.ActiveImage(imageGameObject, true, ingredinetImagesActiveIndex);

        //Game object has been trigger
        GameObjectActiveManger.instance.SetTrigger(GameObjectActiveManger.instance.GetIngredientsTiggerList(), indexIngredientsTiggerList, maxCountIngredientTiggerList, true);

        //Destroy the game object
        Destroy(gameObject);
    }
}
