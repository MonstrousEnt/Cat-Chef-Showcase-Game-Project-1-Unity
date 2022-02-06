using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance; //A static reference of the class

    [SerializeField] private int _foundIngredinetsNum = 0;
    [SerializeField] private int _maxIngredients;

    [SerializeField] private int _coinNum;
    [SerializeField] private int _coinMax;
    
    [SerializeField] private int _coinPointNum = 10;
    [SerializeField] private int _monsterPointNum = 20;
    [SerializeField] private int _ingredientPointNum = 30;
    [SerializeField] private int _healthPowerUpPointNum = 40;
    [SerializeField] private int _tolatPoints = 0;

    [SerializeField] private CollectablesUI collectablesUI;

    [SerializeField] private bool _atCakeOver = false;

    [SerializeField] private Vector2 lastCheckpointPos;

    [SerializeField] private WinScreenUI WinScreenUI;



    public int GetMaxIngredients() {return _maxIngredients;}
    public int GetFoundIngredinetsNum() { return _foundIngredinetsNum; }
    public void SetFoundIngredinetsNum( int foundIngredinetsNum) { this._foundIngredinetsNum = foundIngredinetsNum; }

    public int GetMaxCoins () { return _coinMax; }
    public void SetCoinNum(int coinNum) { this._coinNum = coinNum;}
    public int GetCoinNum() { return _coinNum; }

    public int GetIngredientPointNum() { return _ingredientPointNum; }
    public int GetCoinPointNum() { return _coinPointNum; }
    public int GetMonsterPointNum() { return _monsterPointNum; }
    public int GetHealthPowerUpPointNum() { return _healthPowerUpPointNum; }
    public int GetTolatPoints() { return _tolatPoints; }
    public void SetTolatPoints(int tolatPoints) { this._tolatPoints = tolatPoints; }

    public void SetAtCakeOver(bool flag) { this._atCakeOver = flag; }

    public Vector2 GetLastCheckpointPos() { return lastCheckpointPos; }
    public void SetLastCheckpointPos(Vector2 lastCheckpointPos) { this.lastCheckpointPos = lastCheckpointPos; }



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
        collectablesUI.SetText(_coinNum);
        AudioManager.instance.playAudio("Level Music");
    }

    private void Update()
    {
        if (_foundIngredinetsNum == _maxIngredients && _atCakeOver)
        {
            //Level Completed
            WinScreenUI.activeMenu(true);
        }

        if (Input.GetKeyDown(KeyCode.H))
        {
            PlayerBase.instance.TakeDmage(PlayerBase.instance.GetFullHeartNum());
        }
        if (Input.GetKeyDown(KeyCode.J))
        {
            PlayerBase.instance.TakeDmage(PlayerBase.instance.GetFullHeartNum());
            PlayerBase.instance.TakeDmage(PlayerBase.instance.GetFullHeartNum());
        }
    }
}
