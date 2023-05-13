/* Project Name: Arcade 2D Platformer
 * Team Name: Monstrous Entertainment - Vex Team
 * Authors: Daniel Cox, Ben Topple
 * Created Date: January 30, 2022
 * Latest Update: February 11, 2022
 * Description: The class save the last checkpoint for the player.
 * Notes: 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveCheckpoint : MonoBehaviour
{
    //Class Variables

    [Header("Checkpoint Data")]
    [SerializeField] private float _defaultCheckpointHeight;


    [Header("Trigger Reference")]
    [SerializeField] private int _indexCheckpointTrigger; 

    private void Start()
    {
        GameObjectActiveManger.instance.UpdateTrigger(GameObjectActiveManger.instance.GetCheckpointTriggers(), _indexCheckpointTrigger, GameObjectActiveManger.instance.GetCheckpointTriggerSize(), gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            //Set the last checkpoint
            Vector2 lastCheckpointPos = new Vector2(transform.position.x, _defaultCheckpointHeight);
            GameManager.instance.SetLastCheckpointPos(lastCheckpointPos);

            //Game object has been trigger
            GameObjectActiveManger.instance.SetTrigger(GameObjectActiveManger.instance.GetCheckpointTriggers(), _indexCheckpointTrigger, GameObjectActiveManger.instance.GetCheckpointTriggerSize(), true);
 
            //Destroy the current checkpoint
            Destroy(gameObject);
        }
    }
}
