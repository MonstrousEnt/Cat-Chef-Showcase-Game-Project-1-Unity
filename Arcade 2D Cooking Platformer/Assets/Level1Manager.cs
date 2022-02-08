using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level1Manager : MonoBehaviour
{
    [SerializeField] private Vector2 checkpointOnePos;

    private void Start()
    {
        if (GameManager.instance.GetLevelStarted())
        {
            CollectablesUI.instance.SetText(GameManager.instance.GetCoinNum());

            if (!GameManager.instance.GetRestart())
            {
                AudioManager.instance.stopAudio("Level Music");
                AudioManager.instance.SetAudioLoop("Level Music", false);

                AudioManager.instance.SetAudioLoop("Level Music", true);
                AudioManager.instance.playAudio("Level Music");
            }

            GameManager.instance.SetRestart(false);

            for (int i = 0; i < GameManager.instance.GetIngredinetImagesActive().Count; i++)
            {
                GameManager.instance.GetIngredinetImagesActive()[i] = false;
            }

            LiveSystemManager.instance.ResetLives();

            SettingManager.instance.ActivePause(false, 1f);

            GameManager.instance.SetFoundIngredinetsNum(0);

            GameManager.instance.SetAtCakeOver(false);

            PlayerBase.instance.gameObject.transform.position = checkpointOnePos;


            GameObjectActiveManger.instance.GetCheckpointTriggerList().Clear();
            GameObjectActiveManger.instance.AddAllTriggers(3, GameObjectActiveManger.instance.GetCheckpointTriggerList());

            GameObjectActiveManger.instance.GetIngredientsTiggerList().Clear();
            GameObjectActiveManger.instance.AddAllTriggers(4, GameObjectActiveManger.instance.GetIngredientsTiggerList());

            GameManager.instance.SetLevelStarted(false);
        }
       


    }
}
