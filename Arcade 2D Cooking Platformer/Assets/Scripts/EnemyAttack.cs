using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;


public class EnemyAttack : MonoBehaviour
{
    //variables
    public Animator animator;

	[SerializeField] public float threatRadius;
	public Transform threatPoint;

	public Transform attackPoint;
    [SerializeField] public float attackRadius;

    public LayerMask playerLayer;

	private bool isAttacking = false;

	[SerializeField] private AIPath aipath;

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
			isAttacking = true;
			Debug.Log("Enemy attack!");
		}
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
		
		if (collision.tag == "Player")
        {
			

			Debug.Log("Enemy collider with player tag!");

			if (isAttacking)
			{
				StopAllCoroutines();
				//StopCoroutine(stopMoving());
				StartCoroutine(stopMoving());

			}

		}
    }

	private void OnDrawGizmos()
	{
		Gizmos.DrawWireSphere(threatPoint.position, threatRadius);
		Gizmos.DrawWireSphere(attackPoint.position, attackRadius);
	}

	private IEnumerator stopMoving()
    {
		aipath.canMove = false;

		Debug.Log("Do the enemy attack animation and damage!");
		FindObjectOfType<AudioManager>().playAudio("enemy_attack");
		animator.SetTrigger("Attack");
		PlayerBase.instance.TakeDmage(forkDamage);
		isAttacking = false;

		yield return new WaitForSeconds(.2f);

		aipath.canMove = true;

	}

}
