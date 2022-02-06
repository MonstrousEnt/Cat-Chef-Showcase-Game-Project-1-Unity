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
    //[SerializeField] private Sprite halfHeartSprite;
    [SerializeField] private Sprite emptyHeartSprite;
    

    //Getters and Setters
    public int GetNumOfHearts() { return numOfHearts; }
    public void SetNumOfHearts(int numOfHearts) { this.numOfHearts = numOfHearts; }

    public void UpdateHealthBar(int health, int maxHealthPowerUp)
    {
        if (health == maxHealthPowerUp)
        {
            maxHearts();
        }
        else
        {
            List<int> threeDightsNum = new List<int>();

            threeDightsNum = separateDigits(health);

            if (health < 0)
            {
                return;

            }
            else
            {
                fullHearts(threeDightsNum);

                //haftHeats(threeDightsNum);

                emptyHearts(threeDightsNum);
            }
        }
    }

    private List<int> separateDigits(int number)
    {
        int hundreds;
        int tens;
        int ones;

        hundreds = (number / 100) % 10;
        tens = (number / 10) % 10;
        ones = number % 10;

        List<int> threeDightsNum = new List<int>();

        threeDightsNum.Add(hundreds);
        threeDightsNum.Add(tens);
        threeDightsNum.Add(ones);


        return threeDightsNum;
    }

    private void maxHearts()
    {
        for (int i = 0; i < MaxNumOfHearts; i++)
        {
            heartImages[i].sprite = fullHeartSprite;
            heartImages[i].enabled = true;
        }
    }

    private void fullHearts(List <int> threeDightsNum)
    {
        for (int i = 0; i < numOfHearts; i++)
        {
            heartImages[i].enabled = true;
        }

        for (int i = 0; i < threeDightsNum[1]; i++)
        {
            heartImages[i].sprite = fullHeartSprite;
        }
    }

    //private void haftHeats(List<int> threeDightsNum)
    //{
    //    if (threeDightsNum[2] == 5)
    //    {
    //        int index = threeDightsNum[2] + 1;
    //        heartImages[index].sprite = halfHeartSprite;
    //    }
    //}

    private void emptyHearts(List<int> threeDightsNum)
    {

        for (int i = threeDightsNum[1]; i < MaxNumOfHearts; i++)
        {
            heartImages[i].sprite = emptyHeartSprite;
        }
    }
}