/* Project Name: Arcade 2D Platformer
 * Team Name: Monstrous Entertainment - Vex Team
 * Authors: Daniel Cox, Ben Topple
 * Created Date: January 30, 2022
 * Latest Update: February 11, 2022
 * Description: The class is the manger for the enemy.
 * Notes: 
 */

using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBase : MonoBehaviour
{
    //Class Variables
    [Header("Enemy Data")]
    [SerializeField] public int health = 0;
    [SerializeField] private int _maxHealth;
    [SerializeField] private PlayerController2D _playerCharacter;
    [SerializeField] private Rigidbody2D _rigidbody2D;
    [SerializeField] private float knockbackAmount = 60f;

    [SerializeField] private EnemyAttack attackScript;

    [Header("Sound Effects")]
    [SerializeField] string _takeDamagesoundEffect = "slash";
    
    [Header("Animations")]
    [SerializeField] private Animator _animator;
    [SerializeField] private string _takeDamageAnimation = "takeDamage";
    [SerializeField] private string _deathAnimation = "isDead";


    [Header("AIPathfinding references")]
    [SerializeField] private AIPath aipath;

    [Header("Trigger Reference")]
    [SerializeField] private int _indexEnemyTriggerList;    


    private void Awake()
    {
        //Get the game components 
        _animator.GetComponent<Animator>();
    }

    private void Start()
    {
        //Enable the enemy collier
        GetComponent<Collider2D>().enabled = true;

        GameObjectActiveManger.instance.UpdateTrigger(GameObjectActiveManger.instance.GetEnemyTriggers(), _indexEnemyTriggerList, GameObjectActiveManger.instance.GetEnemyTriggerSize(), gameObject);

        //set the health to max health of the enemy
        health = _maxHealth;
    }

    /// <summary>
    /// When the enemy takes damage
    /// </summary>
    /// <param name="damage"></param>
    public void TakeDamage(int damage)
    {

        //disable attack script
        //attackScript = null;
        attackScript._isAttacking = false;

        //player the sound effect for damage
        AudioManager.instance.playAudio(_takeDamagesoundEffect);

        //The enemy take the damage from the monsters.
        health -= damage;
        Debug.Log("Damage taken by enemy " + damage);

        //apply force 

        Vector2 moveDirection = _rigidbody2D.transform.position - _playerCharacter.transform.position;
        _rigidbody2D.AddForce(moveDirection.normalized * knockbackAmount);

        Debug.Log("knocked back by " + knockbackAmount);

        //reset force
        _rigidbody2D.AddForce(Vector2.zero);

        StopCoroutine(StopMoving());
        StartCoroutine(StopMoving());               

        //If the enemy dies
        if (health <= 0)
        {            
            Die();
        }

        ////enable attack script;
        //attackScript = GetComponent<EnemyAttack>();
    }

    /// <summary>
    /// stop the enemy for a couple of seconds.
    /// </summary>
    /// <returns></returns>
    private IEnumerator StopMoving()
    {
        //Stop move
        aipath.canMove = false;

        //take damage frame
        _animator.SetTrigger(_takeDamageAnimation);

        //Wait a second or 2
        yield return new WaitForSeconds(1f);

        //Can move now
        aipath.canMove = true;

    }

    /// <summary>
    /// When the enemy dies
    /// </summary>
    private void Die()
    {
        //Disable the enemy collier
        GetComponent<Collider2D>().enabled = false;
        
        //prevent the enemy from attacking
        //Game object has been trigger
        GameObjectActiveManger.instance.SetTrigger(GameObjectActiveManger.instance.GetEnemyTriggers(), _indexEnemyTriggerList, GameObjectActiveManger.instance.GetEnemyTriggerSize(), true);

        //flicker the enemy
        StopCoroutine(flickeringDie());
        StartCoroutine(flickeringDie());

        //Run death animation and destroy the enemy
        StopCoroutine(playDeathAnimation());
        StartCoroutine(playDeathAnimation());  
              
    }

    /// <summary>
    /// Play the death animation for the enemy then die.
    /// </summary>
    /// <returns></returns>
    private IEnumerator playDeathAnimation()
    {
        //Play the animation
        _animator.SetBool(_deathAnimation, true);

        //Wait for a flew seconds
        yield return new WaitForSeconds(1f);

        //Destroy the game object
        Destroy(gameObject);
    }

    /// <summary>
    /// flicker the enemy from invisible to normal for a couple seconds.
    /// </summary>
    /// <returns></returns>
    private IEnumerator flickeringDie()
    {  
        for (int i = 0; i < 3; i++)
        {
            gameObject.GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, 0);

            yield return new WaitForSeconds(.1f);

            gameObject.GetComponent<SpriteRenderer>().color = Color.white;

            yield return new WaitForSeconds(.2f);
        }

        gameObject.GetComponent<SpriteRenderer>().color = Color.white;

    }

}
