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


    private void FixedUpdate()
    {
        if (Input.GetButtonDown("Attack"))
        {
            Attack();
        }
    }

    private void Attack()
    {
        //play the animation
        animator.SetTrigger("Attack");

        //detect enemies in attack range
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRadius, enemyLayers);

        foreach(Collider2D enemy in hitEnemies)
        {
            //damage enemies
            Debug.Log("Dealt damage to " + enemy.name);
        }

        //deal damage
    }

    private void OnDrawGizmos()
    {
        if (attackRadius == null)
            return;

        Gizmos.DrawWireSphere(attackPoint.position, attackRadius);
    }
}
