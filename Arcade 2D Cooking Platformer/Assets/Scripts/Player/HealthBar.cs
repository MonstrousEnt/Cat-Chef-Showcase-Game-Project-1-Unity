using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Reference: https://youtu.be/3uyolYVsiWc

public class HealthBar : MonoBehaviour
{
    //Class Variables 
    [SerializeField] private int numOfHearts;
    [SerializeField] private List<Image> hearts;
    [SerializeField] private Sprite fullHeart;
    [SerializeField] private Sprite emptyHeart;

    //Getters and Setters
    public int GetNumOfHearts() { return numOfHearts; }
    public void SetNumOfHearts(int numOfHearts) { this.numOfHearts = numOfHearts; }

   public void UpdateHealthBar(int health)
   {
        //Go through all the hearts
        for (int i = 0; i < hearts.Count; i++)
        {
            //Check to see if health is greater than hearts (Error checker)
            if (health > numOfHearts)
            {
                health = numOfHearts;
            }

            //Empty or full hearts
            if (i < health)
            {
                hearts[i].sprite = fullHeart;
            }
            else
            {
                hearts[i].sprite = emptyHeart;
            }

            //Enable hearts
            if (i < numOfHearts)
            {
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = false;
            }
        }
   }
}