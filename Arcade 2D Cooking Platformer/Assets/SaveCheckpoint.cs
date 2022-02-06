using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveCheckpoint : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Vector2 lastCheckpointPos = new Vector2(transform.position.x, transform.position.y);
            GameManager.instance.SetLastCheckpointPos(lastCheckpointPos);
        }
    }
}
