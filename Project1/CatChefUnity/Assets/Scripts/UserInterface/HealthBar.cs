/* Project Name: Arcade 2D Platformer
 * Team Name: Monstrous Entertainment - Vex Team
 * Authors: Daniel Cox, Ben Topple
 * Created Date: January 30, 2022
 * Latest Update: February 11, 2022
 * Description: The class is UI class for the health bar system.
 * Notes: Old Version 7ae06cb.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    //Class Variables 
    [Header("Info Data")]
    [SerializeField] private int numOfHearts;
    [SerializeField] private List<Image> heartImages;

    [Header("Heart Sprites")]
    [SerializeField] private Sprite fullHeartSprite;
    [SerializeField] private Sprite emptyHeartSprite;

    private void Start()
    {
        UIEvents.instance.onUpdateHealthBar.AddListener(updateHealthBar);
    }

    /// <summary>
    /// Update the health bar.
    /// </summary>
    /// <param name="health"></param>
    private void updateHealthBar(int health)
    {
        //Go through all the hearts
        for (int i = 0; i < heartImages.Count; i++)
        {
            //Empty or full hearts
            if (i < health)
            {
                heartImages[i].sprite = fullHeartSprite;
            }
            else
            {
                heartImages[i].sprite = emptyHeartSprite;
            }

            //Enable or disable hearts
            if (i < numOfHearts)
            {
                heartImages[i].enabled = true;
            }
            else
            {
                heartImages[i].enabled = false;
            }
        }
    }

    private void OnDestroy()
    {
        UIEvents.instance.onUpdateHealthBar.RemoveListener(updateHealthBar);
    }
}