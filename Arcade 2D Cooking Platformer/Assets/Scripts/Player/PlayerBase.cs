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
    private int playerLayer; //layer of the player
    private int enemyLayer; //layer of the enemy
    [SerializeField] private Animator _animator; //Reference to the animator 


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
        playerLayer = LayerMask.NameToLayer("Player");
        enemyLayer = LayerMask.NameToLayer("Enemy");

        //set the health to max health of the player
        health = maxHealth;

        //Display it in the UI
        healthBar.UpdateHealthBar(health, maxHealthPowerUp);

        LiveSystemManager.instance.ResetLives();
    }

    private void Update()
    {

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

        StopAllCoroutines();
        StartCoroutine(DamageIndicator());

        //If the player dies
        if (health <= 0)
		{
            StopAllCoroutines();
			StartCoroutine(Die());
		}
	}

    private IEnumerator DamageIndicator()
    {
        Physics2D.IgnoreLayerCollision(playerLayer, enemyLayer, true);

        //take damage frame
        _animator.SetTrigger("takeDamage");

        //Turn the player red
        gameObject.GetComponent<SpriteRenderer>().color = Color.red;

        //Wait a second or 2
        yield return new WaitForSeconds(1.0f);

        //Turn the player back to normal
        gameObject.GetComponent<SpriteRenderer>().color = Color.white;

        Physics2D.IgnoreLayerCollision(playerLayer, enemyLayer, false);

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
