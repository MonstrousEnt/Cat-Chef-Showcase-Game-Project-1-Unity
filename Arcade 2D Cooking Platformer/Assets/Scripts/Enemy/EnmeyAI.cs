/* Project Name: Arcade 2D Platformer
 * Team Name: Monstrous Entertainment - Vex Team
 * Authors: Daniel Cox, Ben Topple
 * Created Date: January 30, 2022
 * Latest Update: February 11, 2022
 * Description: The class is the manger for the enemy AI.
 * Notes: 
 */

using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnmeyAI : MonoBehaviour
{
    //Class Variables
    [Header("AI Data")]
    [SerializeField] private float _targetRange = 3f;
    [SerializeField] private string _moveAnimation = "movespeed";

    [Header("Components")]
    [SerializeField] private Animator animator;

    [Header("AIPathfinding references")]
    [SerializeField] private AIPath aipath;
    [SerializeField] private AIDestinationSetter destinationSetter;

    private void Awake()
    {
        //Get game components
        animator = GetComponent<Animator>();
        aipath = GetComponent<AIPath>();
        destinationSetter = GetComponent<AIDestinationSetter>();
    }

    private void FixedUpdate()
    {
        //Check if the target is in range, if not then stop the enemy from moving
        if (Vector3.Distance(transform.position, destinationSetter.target.transform.position) > _targetRange)
        {
            aipath.canMove = false;
        }
        else
        {
            aipath.canMove = true;
        }

        //Animation move
        animator.SetFloat(_moveAnimation, Mathf.Abs(aipath.desiredVelocity.x));

        //Flip the enemy
        Flip();

    }

    /// <summary>
    /// Flip the enemy from left to right
    /// </summary>
    private void Flip()
    {
        if (aipath.desiredVelocity.x >= 0.2f)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }
        else if(aipath.desiredVelocity.x >= -0.2f)
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
        }
    }
}
