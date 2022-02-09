using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerBase : MonoBehaviour
{
    public static PlayerBase instance; //A static reference of the class

    [SerializeField] public int health = 0;
    [SerializeField] private int fullHeartNum = 10;
    [SerializeField] private int maxHealth;
    [SerializeField] private int maxHealthPowerUp = 100;

    [SerializeField] private HealthBar healthBar;

    public bool isRespawn = false; //A boolean flag for when the player is respawn at a checkpoint
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
        Physics2D.IgnoreLayerCollision(6, 10, false);

        //set the health to max health of the player
        health = maxHealth;

        //Display it in the UI
        healthBar.UpdateHealthBar(health, maxHealthPowerUp);
    }

    private void Update()
    {

    }

    public void HealthPowerUp(GameObject healthPowerUpGameObject, int indexHealthPowerUpTrigger, int maxCount)
    {
        if (health == maxHealthPowerUp)
        {
            return;
        }
        else
        {
            //Power up health
            health = health + GetFullHeartNum();
            FindObjectOfType<AudioManager>().playAudio("health_item");
            FindObjectOfType<AudioManager>().playAudio("happy_purr");

            //Display it in the UI
            healthBar.UpdateHealthBar(health, maxHealthPowerUp);

            PointManger.instance.SetTolatPoints(PointManger.instance.GetTolatPoints() + PointManger.instance.GetPointData().GetHealthPowerUpPointNum());

            if (GameObjectActiveManger.instance.GetHealthPowerUpTriggerList() != null)
            {
                if (GameObjectActiveManger.instance.GetHealthPowerUpTriggerList().Count == maxCount)
                {
                    GameObjectActiveManger.instance.GetHealthPowerUpTriggerList()[indexHealthPowerUpTrigger] = true;
                }
            }

            //destroy the object
            Destroy(healthPowerUpGameObject);
        }
    }

    public void TakeDmage(int damage)
    {
		//The player take the damage from the monsters.
		health -= damage;

        //Display it in the UI
        healthBar.UpdateHealthBar(health, maxHealthPowerUp);

        StopCoroutine(DamageIndicator());
        StopCoroutine(Flickering());

        StartCoroutine(DamageIndicator());
        StartCoroutine(Flickering());

        //If the player dies
        if (health <= 0)
		{
            StopCoroutine(Die());
			StartCoroutine(Die());
		}
	}

    private IEnumerator DamageIndicator()
    {
        Physics2D.IgnoreLayerCollision(6, 10, true);

        //play sound
        FindObjectOfType<AudioManager>().playAudio("meow_take_dmg");

        //take damage frame
        _animator.SetTrigger("takeDamage");

        //Wait a second or 2
        yield return new WaitForSeconds(2f);

        Physics2D.IgnoreLayerCollision(6, 10, false);

    }

    private IEnumerator Flickering()
    {   //Turn the player red

        for (int i = 0; i < 3; i++)
        {
            gameObject.GetComponent<SpriteRenderer>().color = Color.red;
            yield return new WaitForSeconds(.1f);
            gameObject.GetComponent<SpriteRenderer>().color = Color.white;
            yield return new WaitForSeconds(.2f);
        }
        gameObject.GetComponent<SpriteRenderer>().color = Color.white;

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
