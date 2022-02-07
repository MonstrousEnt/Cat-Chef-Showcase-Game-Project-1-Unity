using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level1Manager : MonoBehaviour
{
    [SerializeField] private CollectablesUI collectablesUI;

    [SerializeField] private Vector2 checkpointOnePos;

    private void Start()
    {
        collectablesUI.SetText(GameManager.instance.GetCoinNum());

        if (!GameManager.instance.GetRestart())
        {
            AudioManager.instance.stopAudio("Level Music");
            AudioManager.instance.SetAudioLoop("Level Music", false);

            AudioManager.instance.SetAudioLoop("Level Music", true);
            AudioManager.instance.playAudio("Level Music");
        }

        GameManager.instance.SetRestart(false);

        PlayerBase.instance.gameObject.transform.position = checkpointOnePos;

    }
}
