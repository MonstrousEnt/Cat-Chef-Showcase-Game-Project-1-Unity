using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BananamanMovement : MonoBehaviour
{
    private Animator _animator;
    [SerializeField] float targetRange = 3f;
    [SerializeField] float moveSpeed = 3f;

    //AIPathfinding reference
    public AIPath aipath;
    public AIDestinationSetter destinationSetter;



    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {       

    }

    private void FixedUpdate()
    {
        //check if the target is in range, if not then null the path
        if (Vector3.Distance(transform.position, destinationSetter.target.transform.position) > targetRange)
        {
            aipath.maxSpeed = 0;
        }
        else
        {
            aipath.maxSpeed = moveSpeed;
        }

        _animator.SetFloat("movespeed", Mathf.Abs(aipath.desiredVelocity.x));

        Flip();

    }

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
