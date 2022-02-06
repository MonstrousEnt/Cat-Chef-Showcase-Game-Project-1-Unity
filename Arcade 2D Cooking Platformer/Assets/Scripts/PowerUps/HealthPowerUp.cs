using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPowerUp : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    { 
        if (collision.tag == "Player")
        {
            Debug.Log("I have 10 more health!");

            //Added the power up to the player
            PlayerBase.instance.FullHeartPowerUp();

            GameManager.instance.SetTolatPoints(GameManager.instance.GetTolatPoints() + GameManager.instance.GetHealthPowerUpPointNum());

            //destroy the object
            gameObject.SetActive(false);
        }
    }
}
