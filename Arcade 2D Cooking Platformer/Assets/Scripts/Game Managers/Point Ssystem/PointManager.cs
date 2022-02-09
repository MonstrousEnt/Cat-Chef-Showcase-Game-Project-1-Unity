/* Project Name: Arcade 2D Platformer
 * Team Name: Monstrous Entertainment - Vex Team
 * Authors: Daniel Cox, Ben Topple
 * Created Date: January 30, 2022
 * Latest Update: February 11, 2022
 * Description: The class is the manager for the point system.
 * Notes: 
 */


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointManager : MonoBehaviour
{
    //Class Variables 
    public static PointManager instance; //A static reference of the class

    [Header("Point Total")]
    [SerializeField] private int _tolatPoints = 0;

    [Header("Point Data")]
    [SerializeField] private int _coinPointNum = 10;
    [SerializeField] private int _monsterPointNum = 20;
    [SerializeField] private int _ingredientPointNum = 30;
    [SerializeField] private int _healthPowerUpPointNum = 40;

    #region Getters and Setters
    public int GetCoinPointNum() { return _coinPointNum; }
    public int GetIngredientPointNum() { return _ingredientPointNum; }
    public int GetMonsterPointNum() { return _monsterPointNum; }
    public int GetHealthPowerUpPointNum() { return _healthPowerUpPointNum; }
    public int GetTolatPoints() { return _tolatPoints; }
    public void SetTolatPoints(int tolatPoints) { this._tolatPoints = tolatPoints; }
    #endregion


    private void Awake()
    {
        #region Singleton Reference
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
        #endregion
    }

}