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
        AudioManager.instance.playAudio("Level Music");

        PlayerBase.instance.gameObject.transform.position = checkpointOnePos;
    }
}
