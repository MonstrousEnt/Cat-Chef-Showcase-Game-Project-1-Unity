using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPowerUp : MonoBehaviour
{
    [Header("Trigger Reference")]
    [SerializeField] private int indexHealthPowerUpTrigger; 

    private void Start()
    {
        GameObjectActiveManger.instance.UpdateTrigger(GameObjectActiveManger.instance.GetHealthPowerUpTrigger(), indexHealthPowerUpTrigger, GameObjectActiveManger.instance.GetHealthPowerUpTriggerSize(), gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    { 
        if (collision.tag == "Player")
        {
            //Added the power up to the player
            PlayerBase.instance.HealthPowerUp(gameObject, indexHealthPowerUpTrigger, GameObjectActiveManger.instance.GetHealthPowerUpTriggerSize());
        }
    }
}
