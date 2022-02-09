using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveCheckpoint : MonoBehaviour
{
    //Class Variables
    [Header("Trigger Reference")]
    [SerializeField] private int indexCheckpointTrigger; //id of the checkpoint
    [SerializeField] private int maxCountCheckpointTriggerList;

    private void Start()
    {
        GameObjectActiveManger.instance.UpdateTrigger(GameObjectActiveManger.instance.GetCheckpointTriggerList(), indexCheckpointTrigger, maxCountCheckpointTriggerList, gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Vector2 lastCheckpointPos = new Vector2(transform.position.x, transform.position.y);
            GameManager.instance.SetLastCheckpointPos(lastCheckpointPos);

            GameObjectActiveManger.instance.SetTrigger(GameObjectActiveManger.instance.GetCheckpointTriggerList(), indexCheckpointTrigger, maxCountCheckpointTriggerList, true);
 
            //Destroy the current checkpoint
            Destroy(gameObject);
        }
    }
}
