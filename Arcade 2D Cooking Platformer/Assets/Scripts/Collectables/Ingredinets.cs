using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ingredinets : MonoBehaviour
{
    [SerializeField] private string IngredinetName;

    [SerializeField] private int ingredinetImagesActiveIndex;

    [SerializeField] private GameObject imageGameObject;

    [SerializeField] private int indexIngredientsTigger; //id of the checkpoint
    [SerializeField] private int maxCount;

    private void Start()
    {
        if (GameObjectActiveManger.instance.GetIngredientsTiggerList() != null)
        {
            if (GameObjectActiveManger.instance.GetIngredientsTiggerList().Count == maxCount)
            {
                if (GameObjectActiveManger.instance.GetIngredientsTiggerList()[indexIngredientsTigger] == true)
                {
                    Destroy(gameObject);
                }
            }
        }

        for (int i = 0; i < GameManager.instance.GetIngredientNameList().Count; i++)
        {
            if (IngredinetName == GameManager.instance.GetIngredientNameList()[i])
            {
                imageGameObject = GameManager.instance.GetIngredinetImages()[i];
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            int tempFoundIngredinetsNum = 1;
            GameManager.instance.SetFoundIngredinetsNum(GameManager.instance.GetFoundIngredinetsNum() + tempFoundIngredinetsNum);

            PointManger.instance.SetTolatPoints(PointManger.instance.GetTolatPoints() + PointManger.instance.GetPointData().GetIngredientPointNum());
            
            Debug.Log("found one!");
            //play the sound
            AudioManager.instance.playAudio("getitem");

            //Set UI
            LevelObjectiveCakeIngredientsUI.instance.ActiveImage(imageGameObject, true, ingredinetImagesActiveIndex);

            if (GameObjectActiveManger.instance.GetIngredientsTiggerList() != null)
            {
                if (GameObjectActiveManger.instance.GetIngredientsTiggerList().Count == maxCount)
                {
                    GameObjectActiveManger.instance.GetIngredientsTiggerList()[indexIngredientsTigger] = true;
                }
            }
                    
            Destroy(gameObject);
        }
    }
}
