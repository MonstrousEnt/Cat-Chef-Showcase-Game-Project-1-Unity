using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelObjectiveCakeIngredientsUI : MonoBehaviour
{
    public static LevelObjectiveCakeIngredientsUI instance; //A static reference of the class

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

    public void UpdateImage()
    {
        for (int i = 0; i < GameManager.instance.GetIngredinetImages().Count; i++)
        {
            GameManager.instance.GetIngredinetImages()[i].SetActive(GameManager.instance.GetIngredinetImagesActive()[i]);
        }
    }

    public void ActiveImage(GameObject imageGameObject, bool flag, int ingredinetImagesActiveIndex)
    {
        imageGameObject.SetActive(flag);

        GameManager.instance.GetIngredinetImagesActive()[ingredinetImagesActiveIndex] = true;
    }
}
