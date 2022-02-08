using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectablesUI : MonoBehaviour
{
    [SerializeField] private Text coinText;

    public static CollectablesUI instance; //A static reference of the class

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


    public void SetText(int coinNum)
   {
        coinText.text = coinNum.ToString();
    }
}
