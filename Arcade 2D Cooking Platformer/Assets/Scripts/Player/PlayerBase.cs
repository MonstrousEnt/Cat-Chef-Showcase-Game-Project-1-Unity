using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerBase : MonoBehaviour
{
    public static PlayerBase instance; //A static reference of the class

    [SerializeField] private int health = 0;
    [SerializeField] private int healthIconNum = 1;
    [SerializeField] private int maxHealth;

    [SerializeField] private HealthBar healthBar;

    public int GetHealthIconNum() { return healthIconNum; }

    private void Awake()
    {
        //---Make sure there is only one instance of this class for each Scene.

        //If there is no instance of the object
        if (instance == null)
        {
            //Set an instance of it
            instance = this;
        }

        //Else, if there's already an instance
        else
        {
            //Destroy it
            Destroy(gameObject);
            return;
        }


        //This won't get destroy when you switch scene
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    { 
        //set the health to max health of the player
        health = maxHealth;

        //Display it in the UI
        healthBar.UpdateHealthBar(health);
    }

    public void SetHealthPowerUp()
    {
        //Power up health
        health = health + healthIconNum;

        //Update hearts
        int tempNumOfHearts = healthBar.GetNumOfHearts() + 1;
        healthBar.SetNumOfHearts(tempNumOfHearts);

        //Display it in the UI
        healthBar.UpdateHealthBar(health);
    }




    public void TakeDmage(int damage)
    {
		//The player take the damage from the monsters.
		health -= damage;

        //Update hearts
        int tempNumOfHearts = healthBar.GetNumOfHearts() - 1;
        healthBar.SetNumOfHearts(tempNumOfHearts);

        //Display it in the UI
        healthBar.UpdateHealthBar(health);

		//If the player dies
		if (health <= 0)
		{
			Die();
		}
	}

    public void Die()
    {
        GameManager.instance.SetPlayerHasDie(true);
        gameObject.SetActive(false);
    }
}
