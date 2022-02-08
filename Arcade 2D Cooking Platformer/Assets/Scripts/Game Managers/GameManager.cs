using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance; //A static reference of the class

    [SerializeField] private int _foundIngredinetsNum = 0;
    [SerializeField] private List<GameObject> _IngredinetImages;
    [SerializeField] private List<bool> _IngredinetImagesActive;
    [SerializeField] private int _maxIngredients;

    [SerializeField] private int _coinNum;
    [SerializeField] private int _coinMax;

    [SerializeField] private bool _atCakeOver = false;

    [SerializeField] private Vector2 lastCheckpointPos;

    [SerializeField] private bool Restart = false;

    [SerializeField] private bool _levelStarted; //A boolean for when the level started or not

    [SerializeField] private List<string> IngredientNameList;

    public List<string> GetIngredientNameList() { return IngredientNameList; }

    public List<GameObject> GetIngredinetImages() { return _IngredinetImages; }
    public List<bool> GetIngredinetImagesActive() { return _IngredinetImagesActive; }

    public int GetMaxIngredients() {return _maxIngredients;}
    public int GetFoundIngredinetsNum() { return _foundIngredinetsNum; }
    public void SetFoundIngredinetsNum( int foundIngredinetsNum) { this._foundIngredinetsNum = foundIngredinetsNum; }

    public int GetMaxCoins () { return _coinMax; }
    public void SetCoinNum(int coinNum) { this._coinNum = coinNum;}
    public int GetCoinNum() { return _coinNum; }

    public bool GetRestart() { return Restart; }
    public void SetRestart(bool restart) { this.Restart = restart; }

    public void SetAtCakeOver(bool flag) { this._atCakeOver = flag; }

    public Vector2 GetLastCheckpointPos() { return lastCheckpointPos; }
    public void SetLastCheckpointPos(Vector2 lastCheckpointPos) { this.lastCheckpointPos = lastCheckpointPos; }

    public bool GetLevelStarted() { return _levelStarted; }
    public void SetLevelStarted(bool levelStarted) { this._levelStarted = levelStarted; }

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

    private void Update()
    {
        if (_foundIngredinetsNum == _maxIngredients && _atCakeOver)
        {
            SettingManager.instance.ActivePause(true, 0f);

            //Level Completed
            WinScreenUI.instance.activeMenu(true);
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
