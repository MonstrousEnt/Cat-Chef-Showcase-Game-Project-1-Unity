using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPowerUp : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    { 
        if (collision.tag == "Player")
        {
            //Added the power up to the player
            PlayerBase.instance.FullHeartPowerUp(gameObject);
        }
    }
}
