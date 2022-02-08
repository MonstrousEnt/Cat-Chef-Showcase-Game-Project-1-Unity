using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LivesUI : MonoBehaviour
{
    public static LivesUI instance; //A static reference of the class

    [SerializeField] private Text LivesText;

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

    public void SetLives(int lives)
	{
		LivesText.text = "x " + lives.ToString();
	}
}
