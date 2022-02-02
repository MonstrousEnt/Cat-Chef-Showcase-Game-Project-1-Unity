using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBase : MonoBehaviour
{
    [SerializeField] int health = 0;
    [SerializeField] int maxHealth;

    [SerializeField] private HealthBar healthBar;

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
