using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheildPowerUp : MonoBehaviour
{
    private GameObject sheild;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Debug.Log("I have a shield!");

            //spawn it

            //add to player

            GameManager.instance.SetTolatPoints(GameManager.instance.GetTolatPoints() + GameManager.instance.GetSheildPowerUpPointNum());

            //destroy the object
            gameObject.SetActive(false);
        }
    }
}
