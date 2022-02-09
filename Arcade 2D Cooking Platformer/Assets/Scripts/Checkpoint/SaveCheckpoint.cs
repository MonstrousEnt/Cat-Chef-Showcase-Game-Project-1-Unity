using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveCheckpoint : MonoBehaviour
{
    //Class Variables
    [SerializeField] private int indexCheckpointTrigger; //id of the checkpoint
    [SerializeField] private int maxCount;

    private void Start()
    {
        if (GameObjectActiveManger.instance.GetCheckpointTriggerList() != null)
        {
            if (GameObjectActiveManger.instance.GetCheckpointTriggerList().Count == maxCount)
            {
                //if the player has already pass this checkpoint
                if (GameObjectActiveManger.instance.GetCheckpointTriggerList()[indexCheckpointTrigger] == true)
                {
                    //Destroy this checkpoint
                    Destroy(gameObject);
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Vector2 lastCheckpointPos = new Vector2(transform.position.x, transform.position.y);
            GameManager.instance.SetLastCheckpointPos(lastCheckpointPos);

            if (GameObjectActiveManger.instance.GetCheckpointTriggerList() != null)
            {
                if (GameObjectActiveManger.instance.GetCheckpointTriggerList().Count == maxCount)
                {
                    //This object has been trigger by the player
                    GameObjectActiveManger.instance.GetCheckpointTriggerList()[indexCheckpointTrigger] = true;
                }
            }

            //Destroy the current checkpoint
            Destroy(gameObject);
        }
    }
}
