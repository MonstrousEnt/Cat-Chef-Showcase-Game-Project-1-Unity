using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Conis : MonoBehaviour
{
   [SerializeField] private CollectablesUI collectablesUI;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            int tempCoinNum = 1;
            GameManager.instance.SetCoinNum(GameManager.instance.GetCoinNum() + tempCoinNum);

            PointManger.instance.SetTolatPoints(PointManger.instance.GetTolatPoints() + PointManger.instance.GetPointData().GetCoinPointNum());

            //play the sound
            FindObjectOfType<AudioManager>().playAudio("coin1");

            collectablesUI.SetText(GameManager.instance.GetCoinNum());

            gameObject.SetActive(false);
        }
    }
}
