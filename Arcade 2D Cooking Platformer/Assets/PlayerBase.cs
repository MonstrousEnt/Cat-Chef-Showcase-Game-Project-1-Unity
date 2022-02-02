using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBase : MonoBehaviour
{
    public static PlayerBase instance; //A static reference of the class

    [SerializeField] int health = 0;
    [SerializeField] int maxHealth;

    [SerializeField] private HealthBar healthBar;

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

        //Display it in the UI. 
        healthBar.SetMaxHealth(maxHealth);
    }

    private void TakeDmage(int damage)
    {
		//The player take the damage from the monsters.
		health -= damage;

		//Display it in the UI.
		healthBar.SetHealth(health);

		//If the player dies
		if (health <= 0)
		{
			Die();
		}
	}

    private void Die()
    {
        GameManager.instance.SetPlayerHasDie(true);
        gameObject.SetActive(false);
    }
}
