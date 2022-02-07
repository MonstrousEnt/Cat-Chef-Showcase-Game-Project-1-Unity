using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBase : MonoBehaviour
{
    [SerializeField] private int health = 0;
    [SerializeField] private int maxHealth;

    // Start is called before the first frame update
    void Start()
    {
        //set the health to max health of the enemy
        health = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        //The enemy take the damage from the monsters.
        health -= damage;

        //If the enemy dies
        if (health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        //Turn off the player game object
        gameObject.SetActive(false);
    }
}
