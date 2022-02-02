using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterWeapeon : MonoBehaviour
{
	[SerializeField] private int damageMin = 1;
	[SerializeField] private int damgeMax = 6;
	[SerializeField] private int damgemodify = 1;

	private void OnTriggerEnter2D(Collider2D collision)
	{
		int damage = rollDiceDamage();

		PlayerBase.instance.TakeDmage(damage);

	}

	/// <summary>
	/// Roll the damage of the attack.
	/// </summary>
	/// <returns></returns>
	protected int rollDiceDamage()
	{
		//Set the default damage
		int damage = 0;

		//Get a random between min and max of the damage
		int randNum = Random.Range(damageMin, damgeMax);

		//Critical hit
		if (randNum == damgeMax)
		{
			//Set the damage to a critical hit
			damage = (randNum + damgemodify) * 2;
			Debug.Log(damage); //output the damage	
		}
		//Default hit
		else
		{
			//Set the damage to the randNum + damage modifier
			damage = randNum + damgemodify;
			Debug.Log(damage); //output the damage	
		}

		//Return the damage
		return damage;
	}

}
