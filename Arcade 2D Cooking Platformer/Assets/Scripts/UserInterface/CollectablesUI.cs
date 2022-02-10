/* Project Name: Arcade 2D Platformer
 * Team Name: Monstrous Entertainment - Vex Team
 * Authors: Daniel Cox, Ben Topple
 * Created Date: January 30, 2022
 * Latest Update: February 11, 2022
 * Description: The show the collectibles have collected throughout the level in the UI.
 * Notes: 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectablesUI : MonoBehaviour
{
    //Class Variables
    [SerializeField] private Text coinText;

    private void Start()
    {
        UIEvents.instance.onSetCollectableText.AddListener(setText);

        setText(GameManager.instance.GetCoinNum());
    }

    /// <summary>
    /// Update number of coin you have collect in the UI.
    /// </summary>
    /// <param name="coinNum"></param>
    private void setText(int coinNum)
    {
        coinText.text = coinNum.ToString();
    }

    private void OnDestroy()
    {
        UIEvents.instance.onSetCollectableText.RemoveListener(setText);
    }
}
