using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance; //A static reference of the class

    [SerializeField] private int _foundIngredinetsNum = 0;
    [SerializeField] private int _maxIngredients;

    [SerializeField] private LevelObjectiveCakeIngredientsUI levelObjectiveCakeIngredientsUI;

    [SerializeField] private bool _atCakeOver;

    public int GetMaxIngredients() {return _maxIngredients;}
    public int GetFoundIngredinetsNum() { return _foundIngredinetsNum; }
    public void SetFoundIngredinetsNum( int foundIngredinetsNum) { this._foundIngredinetsNum = foundIngredinetsNum; }

    public void SetAtCakeOver(bool flag) { this._atCakeOver = flag; }

    
    
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

    private void Start()
    {
        _atCakeOver = false;
        levelObjectiveCakeIngredientsUI.SetText(_foundIngredinetsNum);
    }

    private void Update()
    {
        if (_foundIngredinetsNum == _maxIngredients && _atCakeOver)
        {
            //Level Completed
            //you win
        }

        //Die = lose

        
        
    }
}
