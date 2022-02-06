//Note: Heart Fragments Version 7ae06cb.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    //Class Variables 
    [SerializeField] private int numOfHearts;
    [SerializeField] private int MaxNumOfHearts;

    [SerializeField] private List<Image> heartImages;

    [SerializeField] private Sprite fullHeartSprite;
    [SerializeField] private Sprite emptyHeartSprite;
    

    //Getters and Setters
    public int GetNumOfHearts() { return numOfHearts; }
    public void SetNumOfHearts(int numOfHearts) { this.numOfHearts = numOfHearts; }

    /// <summary>
    /// Update the health bar.
    /// </summary>
    /// <param name="health"></param>
    /// <param name="maxHealthPowerUp"></param>
    public void UpdateHealthBar(int health, int maxHealthPowerUp)
    {
        //Max Hearts
        if (health == maxHealthPowerUp)
        {
           
            maxHearts();
        }
        //Health is less than Max Hearts
        else if (health < maxHealthPowerUp)
        {
            //If the player has die. Don't update the UI.
            if (health < 0)
            {
                return;
            }
            //If the player is live. Update the UI.
            else if (health >= 0)
            {
                //Separate the number into three digits. 
                List<int> threeDightsNum = new List<int>();
                threeDightsNum = separateDigits(health);

                //Show full hearts based off the tenth placements.
                fullHearts(threeDightsNum);

                //Show empty hearts for the reminder heart.
                emptyHearts(threeDightsNum);
            }
        }
    }

    /// <summary>
    /// Separate the number into three digits.
    /// </summary>
    /// <param name="number"></param>
    /// <returns></returns>
    private List<int> separateDigits(int number)
    {
        //Local Variables
        int hundreds;
        int tens;
        int ones;

        //Get each digits 
        hundreds = (number / 100) % 10;
        tens = (number / 10) % 10;
        ones = number % 10;

        //Create a list to hold all the digits.
        List<int> threeDightsNum = new List<int>();

        //Add each digits
        threeDightsNum.Add(hundreds);
        threeDightsNum.Add(tens);
        threeDightsNum.Add(ones);

        //Return the list
        return threeDightsNum;
    }


    /// <summary>
    /// Display the max hearts.
    /// </summary>
    private void maxHearts()
    {
        //Enable all hearts and set the sprite to a full heart.
        for (int i = 0; i < MaxNumOfHearts; i++)
        {
            heartImages[i].sprite = fullHeartSprite;
            heartImages[i].enabled = true;
        }
    }

    /// <summary>
    /// Display the full hearts based on tenth placement.
    /// </summary>
    /// <param name="threeDigitsNum"></param>
    private void fullHearts(List<int> threeDigitsNum)
    {
        //Enable number of hearts.
        for (int i = 0; i < numOfHearts; i++)
        {
            heartImages[i].enabled = true;
        }

        //Display the full hearts based on tenth placement.
        for (int i = 0; i < threeDigitsNum[1]; i++)
        {
            heartImages[i].sprite = fullHeartSprite;
        }
    }

    /// <summary>
    /// Show the reminder of hearts empty.
    /// </summary>
    /// <param name="threeDigitsNum"></param>
    private void emptyHearts(List<int> threeDigitsNum)
    {
        //Enable the reminder of hearts as empty heart.
        for (int i = threeDigitsNum[1]; i < MaxNumOfHearts; i++)
        {
            heartImages[i].sprite = emptyHeartSprite;
        }
    }
}