/* Project Name: Arcade 2D Platformer
 * Team Name: Monstrous Entertainment - Vex Team
 * Authors: Daniel Cox, Ben Topple
 * Created Date: January 30, 2022
 * Latest Update: February 11, 2022
 * Description: The class is the manger for the player
 * Notes: 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerBase : MonoBehaviour
{
    //Class Variables
    public static PlayerBase instance;

    [Header("Player Data")]
    [SerializeField] public int health = 0;
    [SerializeField] private int maxHealth;
    [SerializeField] private int fullHeartNum = 10;

    [Header("Health Power Up")]
    [SerializeField] private int maxHealthPowerUp = 100;
    [SerializeField] private string healthItemSoundEffect = "health_item";
    [SerializeField] private string happyPurrSoundEffect = "happy_purr";

    [Header("Layer")]
    [SerializeField] private int playerLayer;
    [SerializeField] private int enemyLayer;

    [Header("Component References")]
    [SerializeField] private HealthBar healthBar;

    [Header("Animator References")]
    [SerializeField] private Animator _animator;
    [SerializeField] private string takeDamage = "takeDamage";

    [Header("Sound Effects")]
    private string takeDamageSoundEffect = "meow_take_dmg";
   
    [Header("Flag Boolean")]
    private bool isRespawn = false;

    //Getter and Setters
    public int GetFullHeartNum() { return fullHeartNum; }
    public bool GetIsRespawn() { return isRespawn; }
    public void SetIsRespawn(bool isRespawn) { this.isRespawn = isRespawn; }

    public void Awake()
    {
        #region Singleton Reference
        if (instance == null)
        {
            instance = this;
        }
        #endregion

        //Get game components 
        _animator = GetComponent<Animator>();
    }

    private void Start()
    {
        //Reset collision for player and enemy layers
        Physics2D.IgnoreLayerCollision(playerLayer, enemyLayer, false);

        //set the health to max health of the player
        health = maxHealth;

        //Display it in the UI
        healthBar.UpdateHealthBar(health, maxHealthPowerUp);
    }

    /// <summary>
    /// This power up increase the health of the player.
    /// </summary>
    /// <param name="healthPowerUpGameObject"></param>
    /// <param name="indexHealthPowerUpTrigger"></param>
    /// <param name="healthPowerUpTriggerSize"></param>
    public void HealthPowerUp(GameObject healthPowerUpGameObject, int indexHealthPowerUpTrigger, int healthPowerUpTriggerSize)
    {
        //If player health is max out
        if (health == maxHealthPowerUp)
        {
            //then exit out of this method
            return;
        }
        //Otherwise increase the health by one heart
        else
        {
            //Power up health
            health = health + GetFullHeartNum();

            //Ply the sound
            AudioManager.instance.playAudio(healthItemSoundEffect);
            AudioManager.instance.playAudio(happyPurrSoundEffect);

            //Display it in the UI
            healthBar.UpdateHealthBar(health, maxHealthPowerUp);

            //Added the Health power up to the total points
            PointManager.instance.SetTolatPoints(PointManager.instance.GetTolatPoints() + PointManager.instance.GetHealthPowerUpPointNum());

            //Game object has been trigger
            GameObjectActiveManger.instance.SetTrigger(GameObjectActiveManger.instance.GetHealthPowerUpTrigger(), indexHealthPowerUpTrigger, healthPowerUpTriggerSize, true);

            //Destroy the object game
            Destroy(healthPowerUpGameObject);
        }
    }

    /// <summary>
    /// When the player takes damage.
    /// </summary>
    /// <param name="damage"></param>
    public void TakeDmage(int damage)
    {
		//The player take the damage from the monsters.
		health -= damage;

        //Display it in the UI
        healthBar.UpdateHealthBar(health, maxHealthPowerUp);

        //Play sound
        AudioManager.instance.playAudio(takeDamageSoundEffect);

        //Take damage frame
        _animator.SetTrigger(takeDamage);

        //Indicator the damage
        StopCoroutine(invulnerability());
        StopCoroutine(flickering());

        StartCoroutine(invulnerability());
        StartCoroutine(flickering());

        //If the player dies
        if (health <= 0)
		{
            StopCoroutine(die());
			StartCoroutine(die());
		}
	}

    /// <summary>
    /// Make the player and enemy Invulnerability for a flew seconds.
    /// </summary>
    /// <returns></returns>
    private IEnumerator invulnerability()
    {
        //Turn off collision for player and enemy
        Physics2D.IgnoreLayerCollision(playerLayer, enemyLayer, true);

        //Wait a second or 2
        yield return new WaitForSeconds(2f);

        //Turn off collision for player and enemy
        Physics2D.IgnoreLayerCollision(playerLayer, enemyLayer, false);

    }

    /// <summary>
    /// Flicker the player red for a couple of seconds.
    /// </summary>
    /// <returns></returns>
    private IEnumerator flickering()
    {   
        for (int i = 0; i < 3; i++)
        {
            gameObject.GetComponent<SpriteRenderer>().color = Color.red;

            yield return new WaitForSeconds(.1f);

            gameObject.GetComponent<SpriteRenderer>().color = Color.white;

            yield return new WaitForSeconds(.2f);
        }

        gameObject.GetComponent<SpriteRenderer>().color = Color.white;

    }


    /// <summary>
    /// When the players dies, respawn the player.
    /// </summary>
    /// <returns></returns>
    private IEnumerator die()
    {
        //Wait a flew seconds to show all hearts are empty heat.
        yield return new WaitForSeconds(0.5f);

        //Respawn the player
        respawn();
       
        
    }

    /// <summary>
    /// Respawn the player back at the checkpoint.
    /// </summary>
    private void respawn()
    {
        //If the player ran out of lives
        if (LiveSystemManager.instance.GetLivesCount() == 0)
        {
            LiveSystemManager.instance.OutOfLives();
        }
        //Otherwise respawn the player back at the checkpoint.
        else
        {
            //Reset the health
            health = maxHealth;

            //Reset the health bar
            healthBar.UpdateHealthBar(health, maxHealthPowerUp);

            //Player lose one life
            LiveSystemManager.instance.LoseALife();

            //Respawn at checkpoint
			isRespawn = true;
        }
    }

    private void OnDestroy()
    {
        //Set the singleton reference to null when the game object destroy
        instance = null;
    }
}
