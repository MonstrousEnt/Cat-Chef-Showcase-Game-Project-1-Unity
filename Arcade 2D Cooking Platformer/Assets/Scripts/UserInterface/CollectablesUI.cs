/* Project Name: Arcade 2D Platformer
 * Team Name: Monstrous Entertainment - Vex Team
 * Authors: Daniel Cox, Ben Topple
 * Created Date: January 30, 2022
 * Latest Update: February 11, 2022
 * Description: The show the collectibles have collected throughout the level in the UI.
 * Notes: 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectablesUI : MonoBehaviour
{
    //Class Variables
    public static CollectablesUI instance; //A static reference of the class

    [SerializeField] private Text coinText;

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
    /// Update number of coin you have collect in the UI.
    /// </summary>
    /// <param name="coinNum"></param>
    public void SetText(int coinNum)
    {
        coinText.text = coinNum.ToString();
    }
}
