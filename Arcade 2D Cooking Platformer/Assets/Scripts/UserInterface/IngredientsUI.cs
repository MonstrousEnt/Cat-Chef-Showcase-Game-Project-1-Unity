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
    //Class Variables 
    public static IngredientsUI instance; 

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
    }

    /// <summary>
    /// Update the ingredient images when the level or when the player respawn from the checkpoint.
    /// </summary>
    public void UpdateImage()
    {
        for (int i = 0; i < GameManager.instance.GetIngredinetImages().Count; i++)
        {
            GameManager.instance.GetIngredinetImages()[i].SetActive(GameManager.instance.GetIngredinetImagesActive()[i]);
        }
    }

    /// <summary>
    /// Active the ingredients in the UI.
    /// </summary>
    /// <param name="imageGameObject"></param>
    /// <param name="flag"></param>
    /// <param name="ingredinetImagesActiveIndex"></param>
    public void ActiveImage(GameObject imageGameObject, bool flag, int ingredinetImagesActiveIndex)
    {
        imageGameObject.SetActive(flag);

        GameManager.instance.GetIngredinetImagesActive()[ingredinetImagesActiveIndex] = true;
    }
}
