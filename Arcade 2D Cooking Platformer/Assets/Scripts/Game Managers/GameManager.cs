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

    public void ResetGameData()
    {
        //Reset Coins
        _coinNum = 0;

        //Reset Lives
        LiveSystemManager.instance.ResetLives();

        //Reset Ingredient
        _foundIngredinetsNum = 0;

        #region reset Ingredient UI
        for (int i = 0; i < _IngredinetImagesActive.Count; i++)
        {
            _IngredinetImagesActive[i] = false;
        }
        #endregion

        //Update Ingredient UI
        IngredientsUI.instance.UpdateImage();
    }

    /// <summary>
    /// Reset the boolean flag for the game.
    /// </summary>
    public void ResetBooleanFlags()
    {
        //Turn of the boolean flag for restart the game
        Restart = false;

        //Reset the boolean for when the level is completed
        _atCakeOver = false;
    }

    /// <summary>
    /// Play the music as long level hasn't restart.
    /// </summary>
    public void PlayLevelMusic(string levelMusicName)
    {
        if (!Restart)
        {
            AudioManager.instance.SetAudioLoop(levelMusicName, false);
            AudioManager.instance.stopAudio(levelMusicName);

            AudioManager.instance.SetAudioLoop(levelMusicName, true);
            AudioManager.instance.playAudio(levelMusicName);
        }
    }

    private void Update()
    {
        if (_foundIngredinetsNum == _maxIngredients && _atCakeOver)
        {
            CakeOver.instance.GameCompleted();

            //Level Completed
            EndStateScreenUI.instance.activeMenu(true);
        }
    }
}
