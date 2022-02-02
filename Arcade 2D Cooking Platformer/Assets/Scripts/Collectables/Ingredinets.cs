using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ingredinets : MonoBehaviour
{
    [SerializeField] private LevelObjectiveCakeIngredientsUI levelObjectiveCakeIngredientsUI;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            int tempFoundIngredinetsNum = 1;

            GameManager.instance.SetFoundIngredinetsNum(GameManager.instance.GetFoundIngredinetsNum() + tempFoundIngredinetsNum);
            Debug.Log("found one!");

            //Set UI
            levelObjectiveCakeIngredientsUI.SetText(GameManager.instance.GetFoundIngredinetsNum());

            gameObject.SetActive(false);
        }
    }
}
