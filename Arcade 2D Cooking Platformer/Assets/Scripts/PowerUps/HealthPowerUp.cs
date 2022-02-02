using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPowerUp : MonoBehaviour
{

     int healthBoost = 10;

    private void OnTriggerEnter2D(Collider2D collision)
    { 
        if (collision.tag == "Player")
        {
            Debug.Log("I have 10 more health!");

            //player health

            //add boost

            //destroy the object
            gameObject.SetActive(false);
        }
    }
}
