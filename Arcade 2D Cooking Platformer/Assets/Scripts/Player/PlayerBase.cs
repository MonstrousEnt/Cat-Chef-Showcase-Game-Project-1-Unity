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

    public int GetFullHeartNum() { return fullHeartNum; }

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
        healthBar.UpdateHealthBar(health, maxHealthPowerUp);
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

        //Turn off the player game object
        gameObject.SetActive(false);

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

            //Set the player potion to the last checkpoint position
            gameObject.transform.position = GameManager.instance.GetLastCheckpointPos();

            //Turn on the player game object
            gameObject.SetActive(true);
        }
    }
}
