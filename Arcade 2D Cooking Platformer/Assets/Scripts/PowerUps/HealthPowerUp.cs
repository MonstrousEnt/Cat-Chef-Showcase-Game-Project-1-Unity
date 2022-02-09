using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPowerUp : MonoBehaviour
{
    [SerializeField] private int indexHealthPowerUpTrigger; //id of the checkpoint
    [SerializeField] private int maxCount;

    private void Start()
    {
        if (GameObjectActiveManger.instance.GetHealthPowerUpTriggerList() != null)
        {
            if (GameObjectActiveManger.instance.GetHealthPowerUpTriggerList().Count == maxCount)
            {
                if (GameObjectActiveManger.instance.GetHealthPowerUpTriggerList()[indexHealthPowerUpTrigger] == true)
                {                    
                    Destroy(gameObject);
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    { 
        if (collision.tag == "Player")
        {
           
                      
                
            //Added the power up to the player
            PlayerBase.instance.HealthPowerUp(gameObject, indexHealthPowerUpTrigger, maxCount);
        }
    }
}
