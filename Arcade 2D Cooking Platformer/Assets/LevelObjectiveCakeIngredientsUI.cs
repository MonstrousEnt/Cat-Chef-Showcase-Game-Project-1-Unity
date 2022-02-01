using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelObjectiveCakeIngredientsUI : MonoBehaviour
{
    [SerializeField] private Text FoundCakeIngredientsText;

   public void SetText(int foundIngredients)
   {
        FoundCakeIngredientsText.text = "Found Cake Ingredients: " + foundIngredients.ToString()+ "/" + GameManager.instance.GetMaxIngredients().ToString();
   }
}
