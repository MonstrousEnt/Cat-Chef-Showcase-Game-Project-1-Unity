using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackDamagePowerUp : MonoBehaviour
{
    int AttackDmageBoost = 10; 

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Debug.Log("I can do more attack damage!");

            //player attack damage

            //add boost

            //destroy the object
            gameObject.SetActive(false);
        }
     
    }
}
