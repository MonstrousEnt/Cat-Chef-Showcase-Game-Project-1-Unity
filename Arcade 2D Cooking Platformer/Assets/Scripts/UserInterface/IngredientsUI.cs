/* Project Name: Arcade 2D Platformer
 * Team Name: Monstrous Entertainment - Vex Team
 * Authors: Daniel Cox, Ben Topple
 * Created Date: January 30, 2022
 * Latest Update: February 11, 2022
 * Description: The show the ingredients have collected throughout the level in the UI.
 * Notes: 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IngredientsUI : MonoBehaviour
{
    [SerializeField] private List<GameObject> _IngredinetImages;

    private void Start()
    {
        UIEvents.instance.onActiveIngredientImage.AddListener(activeImage);

        updateImages();
    }

    /// <summary>
    /// Update the ingredient images when the level or when the player respawn from the checkpoint.
    /// </summary>
    private void updateImages()
    {
        for (int i = 0; i < _IngredinetImages.Count; i++)
        {
            _IngredinetImages[i].SetActive(GameManager.instance.GetIngredinetImagesActive()[i]);
        }
    }

    /// <summary>
    /// Active the ingredients in the UI.
    /// </summary>
    /// <param name="imageGameObject"></param>
    /// <param name="flag"></param>
    /// <param name="ingredinetImagesActiveIndex"></param>
    private void activeImage(bool flag, int ingredinetImagesActiveIndex)
    {
        GameManager.instance.GetIngredinetImagesActive()[ingredinetImagesActiveIndex] = flag;

        updateImages();
    }

    private void OnDestroy()
    {
        UIEvents.instance.onActiveIngredientImage.RemoveListener(activeImage);
    }
}
