/* Project Name: Arcade 2D Platformer
 * Team Name: Monstrous Entertainment - Vex Team
 * Authors: Daniel Cox, Ben Topple
 * Created Date: January 30, 2022
 * Latest Update: February 11, 2022
 * Description: The class is the manger for the enemy attack.
 * Notes: 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;


public class EnemyAttack : MonoBehaviour
{
    //Class Variables
	[Header("Threat Zone")]
	[SerializeField] private float _threatRadius;
	[SerializeField] private Transform _threatPoint;

	[Header("Attack Zone")]
	[SerializeField] private Transform _attackPoint;
	[SerializeField] private float _attackRadius;

	[Header("Layers")]
	[SerializeField] private LayerMask _playerLayer;

	[Header("Boolean Flags")]
	[SerializeField] private bool _isAttacking = false;

	[Header("Combat Damage")]
	[SerializeField] private int _forkDamage;

	[Header("Sound Effects")]
	[SerializeField] private string _enemyAttackSoundEffect = "enemy_attack";

	[Header("Animations")]
	[SerializeField] private Animator _animator;
	[SerializeField] private string _attackAnimation = "Attack";

	[Header("Components")]
	[SerializeField] private AIPath _aipath;
	[SerializeField] private EnemyBase _enemyBase;


	private void Start()
    {
		_forkDamage = PlayerBase.instance.GetFullHeartNum();
    }

    private void Update()
	{
		//Detect player in threat range
		Collider2D attackPlayer = Physics2D.OverlapCircle(_threatPoint.position, _threatRadius, _playerLayer);

		//When the enemy hit the player
		if (attackPlayer != null)
		{
			_isAttacking = true;
		}
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
		//Once the player is collier with the enemy in the threat zone
		if (collision.tag == "Player" && _enemyBase.health > 0)
        {		
			if (_isAttacking)
			{
				StopAllCoroutines();
				//StopCoroutine(stopMoving());
				StartCoroutine(attack());

			}

		}
    }

	private void OnDrawGizmos()
	{
		Gizmos.DrawWireSphere(_threatPoint.position, _threatRadius);
		Gizmos.DrawWireSphere(_attackPoint.position, _attackRadius);
	}

	private IEnumerator attack()
    {
		//Stop the enemy
		_aipath.canMove = false;

		//Play attack sound effect
		AudioManager.instance.playAudio(_enemyAttackSoundEffect);

		//Play the attack animation
		_animator.SetTrigger(_attackAnimation);

		//Take damage form the player
		PlayerBase.instance.TakeDmage(_forkDamage);

		//Stop attack
		_isAttacking = false;

		//Wait a couple of seconds
		yield return new WaitForSeconds(.2f);

		//Enemy can move now
		_aipath.canMove = true;

	}

}
