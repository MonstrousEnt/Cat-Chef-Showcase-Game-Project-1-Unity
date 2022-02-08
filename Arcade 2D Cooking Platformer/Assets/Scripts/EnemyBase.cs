using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBase : MonoBehaviour
{
    [SerializeField] private int health = 0;
    [SerializeField] private int maxHealth;

    [SerializeField] private int indexEnemyTriggerList; 
    [SerializeField] private int maxCount;

    // Start is called before the first frame update
    void Start()
    {
        if (GameObjectActiveManger.instance.GetEnemyTriggerList() != null)
        {
            if (GameObjectActiveManger.instance.GetEnemyTriggerList().Count == maxCount)
            {
                if (GameObjectActiveManger.instance.GetEnemyTriggerList()[indexEnemyTriggerList] == true)
                {
                    Destroy(gameObject);
                }
            }
        }

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
        if (GameObjectActiveManger.instance.GetEnemyTriggerList() != null)
        {
            if (GameObjectActiveManger.instance.GetEnemyTriggerList().Count == maxCount)
            {
                GameObjectActiveManger.instance.GetEnemyTriggerList()[indexEnemyTriggerList] = true;
            }
        }

        //Turn off the player game object
        Destroy(gameObject);
    }
}
