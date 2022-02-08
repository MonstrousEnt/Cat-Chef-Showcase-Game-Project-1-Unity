using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    //variables
    public Animator animator;
    public Transform attackPoint;
    [SerializeField]public float attackRadius;
    public LayerMask enemyLayers;


    [Header("Combat")]
    [SerializeField] public int clawDamage;


    private void FixedUpdate()
    {
        if (Input.GetButtonDown("Attack"))
        {
            Attack();
        }

        if (Input.GetButtonUp("Attack"))
        {
            animator.SetBool("isAttacking", false);
        }

    }

    private void Attack()
    {
        //play the animation
        animator.SetBool("isAttacking", true);
        animator.SetTrigger("Attack");
        

        //detect enemies in attack range
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRadius, enemyLayers);

        foreach(Collider2D enemy in hitEnemies)
        {
            //damage enemies
            EnemyBase enemyBase = enemy.GetComponent<EnemyBase>();

            if (enemyBase != null)
            {

                //enemy takes the damage
                enemyBase.TakeDamage(clawDamage);

            }
            Debug.Log("Dealt damage to " + enemy.name);
        }

    }


    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(attackPoint.position, attackRadius);
    }
}
