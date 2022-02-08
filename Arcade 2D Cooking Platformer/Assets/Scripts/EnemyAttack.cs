using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    //variables
    public Animator animator;

	[SerializeField] public float threatRadius;
	public Transform threatPoint;

	public Transform attackPoint;
    [SerializeField] public float attackRadius;

    public LayerMask playerLayer;

    [Header("Combat")]
    public int forkDamage;

    private void Start()
    {
		forkDamage = PlayerBase.instance.GetFullHeartNum();
    }

    private void Update()
	{
		Collider2D attackPlayer = Physics2D.OverlapCircle(threatPoint.position, threatRadius, playerLayer);

		//When the monster hit the player
		if (attackPlayer != null)
		{
			//Attack the player
			Attack();
		}
	}

	private void Attack()
    {
		//animation
		animator.SetTrigger("Attack");
		Collider2D weaponAttackPlayer = Physics2D.OverlapCircle(attackPoint.position, attackRadius, playerLayer);
		//check if player is touching the weapon
		if (weaponAttackPlayer != null)
		{
			//deal damage to the player 
			PlayerBase.instance.TakeDmage(forkDamage);
		}
	}

	private void OnDrawGizmos()
	{
		Gizmos.DrawWireSphere(threatPoint.position, threatRadius);
		Gizmos.DrawWireSphere(attackPoint.position, attackRadius);
	}
}
