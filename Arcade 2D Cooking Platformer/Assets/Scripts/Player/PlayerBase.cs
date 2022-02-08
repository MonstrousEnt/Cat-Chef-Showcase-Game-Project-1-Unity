using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerBase : MonoBehaviour
{
    public static PlayerBase instance; //A static reference of the class

    [SerializeField] private int health = 0;
    [SerializeField] private int fullHeartNum = 10;
    [SerializeField] private int maxHealth;
    [SerializeField] private int maxHealthPowerUp = 100;

    [SerializeField] private HealthBar healthBar;

    public bool isRespawn = false; //A boolean flag for when the player is respawn at a checkpoint

    public int GetFullHeartNum() { return fullHeartNum; }

    public void Awake()
    {
        if (instance == null)
        {
            //Set an instance of it
            instance = this;
        }
    }

    private void Start()
    { 
        //set the health to max health of the player
        health = maxHealth;

        //Display it in the UI
        healthBar.UpdateHealthBar(health, maxHealthPowerUp);

        LiveSystemManager.instance.ResetLives();
    }

    public void HealthPowerUp(GameObject healthPowerUpGameObject)
    {
        if (health == maxHealthPowerUp)
        {
            return;
        }
        else
        {
            //Power up health
            health = health + GetFullHeartNum();

            //Display it in the UI
            healthBar.UpdateHealthBar(health, maxHealthPowerUp);

            PointManger.instance.SetTolatPoints(PointManger.instance.GetTolatPoints() + PointManger.instance.GetPointData().GetHealthPowerUpPointNum());

            //destroy the object
            healthPowerUpGameObject.SetActive(false);
        }
    }

    public void TakeDmage(int damage)
    {
		//The player take the damage from the monsters.
		health -= damage;

        //Display it in the UI
        healthBar.UpdateHealthBar(health, maxHealthPowerUp);

        //If the player dies
        if (health <= 0)
		{
            StopCoroutine(Die());
			StartCoroutine(Die());
		}
	}

    private IEnumerator Die()
    {
        //Wait a flew seconds to show all hearts are empty heat.
        yield return new WaitForSeconds(0.5f);

        //Respawn the player
        Respawn();
    }

    private void Respawn()
    {
        if (LiveSystemManager.instance.GetLivesCount() == 0)
        {
            LiveSystemManager.instance.OutOfLives();
        }
        else
        {
            //Reset the health
            health = maxHealth;

            //Reset the health bar
            healthBar.UpdateHealthBar(health, maxHealthPowerUp);

            LiveSystemManager.instance.LoseALife();

             //Respawn at checkpoint
			isRespawn = true;
        }
    }

    private void OnDestroy()
    {
        instance = null;
    }
}
