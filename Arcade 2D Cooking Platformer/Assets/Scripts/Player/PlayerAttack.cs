/* Project Name: Arcade 2D Platformer
 * Team Name: Monstrous Entertainment - Vex Team
 * Authors: Daniel Cox, Ben Topple
 * Created Date: January 30, 2022
 * Latest Update: February 11, 2022
 * Description: The class is the manger for the player attack
 * Notes: 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    //Class Variables 
    [Header("Component Reference")]
    [SerializeField] private Animator _animator;

    [Header("Attack Zone")]
    [SerializeField] private Transform _attackPoint;
    [SerializeField] private float _attackRadius;

    [Header("Layers")]
    [SerializeField] private LayerMask _enemyLayers;

    [Header("Combat")]
    [SerializeField] private int _clawDamage;


    private void Update()
    {
        //If the play hit the attack button
        if (Input.GetButtonDown("Attack") && !_animator.GetBool("isClinging"))
        {
            //Random the sounds effect for attack
            int randNum = Random.Range(1, 3);
            //Debug.Log(randNum);

            switch (randNum)
            {
                case 1:
                   AudioManager.instance.playAudio("meow_attack");
                    break;
                case 2:
                    AudioManager.instance.playAudio("meow_attack2");
                    break;
            }

            //Attack the monster
            Attack();
        }

        //If the player take their hand off the button, turn off the attack animation 
        if (Input.GetButtonUp("Attack"))
        {
            _animator.SetBool("isAttacking", false);
        }

    }

    /// <summary>
    /// Attack enemies in range of the attack zone 
    /// </summary>
    private void Attack()
    {
        //Play the attack animation
        _animator.SetBool("isAttacking", true);
        _animator.SetTrigger("Attack");        

        //Detect enemies in attack range
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(_attackPoint.position, _attackRadius, _enemyLayers);

        //damage each enemy
        foreach(Collider2D enemy in hitEnemies)
        {
            EnemyBase enemyBase = enemy.GetComponent<EnemyBase>();

            if (enemyBase != null)
            {
                enemyBase.TakeDamage(_clawDamage);
            }
        }

    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(_attackPoint.position, _attackRadius);
    }
}
