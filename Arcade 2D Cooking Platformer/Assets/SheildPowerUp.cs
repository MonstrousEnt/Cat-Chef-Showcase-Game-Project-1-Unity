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

            //destroy the object
            gameObject.SetActive(false);
        }
    }
}
