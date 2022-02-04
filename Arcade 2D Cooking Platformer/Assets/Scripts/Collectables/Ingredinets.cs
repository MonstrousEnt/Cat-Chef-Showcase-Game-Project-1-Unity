using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ingredinets : MonoBehaviour
{
    [SerializeField] private LevelObjectiveCakeIngredientsUI levelObjectiveCakeIngredientsUI;
    [SerializeField] private GameObject imageGameObject;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            int tempFoundIngredinetsNum = 1;

            GameManager.instance.SetFoundIngredinetsNum(GameManager.instance.GetFoundIngredinetsNum() + tempFoundIngredinetsNum);
            GameManager.instance.SetTolatPoints(GameManager.instance.GetTolatPoints() + GameManager.instance.GetIngredientPointNum());
            Debug.Log("found one!");

            //Set UI
            levelObjectiveCakeIngredientsUI.ActiveImage(imageGameObject, true);

            gameObject.SetActive(false);
        }
    }
}
