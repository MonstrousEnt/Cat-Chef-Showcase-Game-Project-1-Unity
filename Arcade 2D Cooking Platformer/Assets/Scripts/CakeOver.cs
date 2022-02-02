using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CakeOver : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            GameManager.instance.SetAtCakeOver(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            GameManager.instance.SetAtCakeOver(false);
        }
    }
}
