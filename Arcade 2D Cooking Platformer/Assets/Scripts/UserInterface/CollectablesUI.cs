using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectablesUI : MonoBehaviour
{
    [SerializeField] private Text coinText;

   public void SetText(int coinNum)
   {
        coinText.text = "Coins: " + coinNum.ToString() + "/" + GameManager.instance.GetMaxCoins().ToString();
    }
}
