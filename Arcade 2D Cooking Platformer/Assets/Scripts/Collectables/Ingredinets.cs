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
    [SerializeField] private int _ingredinetImagesActiveIndex;

    [Header("SoundEffect")]
    [SerializeField] private string _getItemSoundEffect = "getitem";

    [Header("Trigger Reference")]
    [SerializeField] private int _indexIngredientsTiggerList; //id of the checkpoint

    private void Start()
    {
        GameObjectActiveManger.instance.UpdateTrigger(GameObjectActiveManger.instance.GetIngredientsTriggers(), _indexIngredientsTiggerList, GameObjectActiveManger.instance.GetIngredientsTiggerSize(), gameObject); 
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
        GameManager.instance.SetIngredinetsNum(GameManager.instance.GetIngredinetsNum() + tempFoundIngredinetsNum);

        //Added the Ingredients to the total points
        PointManager.instance.SetTolatPoints(PointManager.instance.GetTolatPoints() + PointManager.instance.GetIngredientPointNum());

        //Play the sound
        AudioManager.instance.playAudio(_getItemSoundEffect);

        //Set UI
        UIEvents.instance.ActiveIngredientImage(true, _ingredinetImagesActiveIndex);

        //Game object has been trigger
        GameObjectActiveManger.instance.SetTrigger(GameObjectActiveManger.instance.GetIngredientsTriggers(), _indexIngredientsTiggerList, GameObjectActiveManger.instance.GetIngredientsTiggerSize(), true);

        //Destroy the game object
        Destroy(gameObject);
    }
}
