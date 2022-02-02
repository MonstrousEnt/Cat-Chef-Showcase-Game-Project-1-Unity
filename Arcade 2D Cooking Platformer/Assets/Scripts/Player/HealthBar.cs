using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    //Class Variables 
    [SerializeField] private Slider slider; 
    [SerializeField] private Text healthText;

    
    /// <summary>
    /// Set the max health for UI base on player's health.
    /// </summary>
    /// <param name="maxHealth"></param>
    public void SetMaxHealth(int maxHealth)
    {
        //Set the max value of the slider to the player's max health.
        slider.maxValue = maxHealth;

        //Set the current value of the slider to player's max health.
        slider.value = maxHealth;

        //Set the player's max health in UI text element.
        healthText.text = maxHealth.ToString();
    }

    /// <summary>
    /// Set the health for the UI based on the player's health.
    /// </summary>
    /// <param name="health"></param>
    public void SetHealth(int health)
    {
        //Set the current value of the slider to the player's health.
        slider.value = health;

        //Set the current value of player's health in UI text element.
        healthText.text = health.ToString();
    }
}


