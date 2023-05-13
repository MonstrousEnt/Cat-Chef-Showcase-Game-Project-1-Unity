/* Name: Daniel Cox, Ben Topple 
 * Date: Oct 3 - November 14, 2020
 * Description: The parallax effects for Mission HQ
 * Notes: 
 * Parallax Tutorial Used: https://youtu.be/zit45k6CUMk
 */

//Libraries
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    //Class variables
    private float _length;//Length of the sprite
    private float _startposX; //Start position of the sprite
    private float _startposY; //Start position of the sprite

    [SerializeField] private GameObject _camera; //The game object of the camera
    [SerializeField] private float _parralaxEffect; //The parallel effect

    private void Start()
    {
        //Find the start position
        _startposX = transform.position.x;
        _startposY = transform.position.y;

        //Get the size of the sprite
        _length = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    private void Update()
    {
        //--HORIZONTAL--
        //How far we move from the camera
        float tempX = (_camera.transform.position.x * (1 - _parralaxEffect));
        //How far we move in world space
        float distanceX = (_camera.transform.position.x * _parralaxEffect);

        //--VERTICAL--

        //How far we move in world space
        float distanceY = (_camera.transform.position.y * _parralaxEffect);

        //Move the background
        transform.position = new Vector3(_startposX + distanceX, _startposY + distanceY, transform.position.z);

        //Repeat the sprites left and right
        if (tempX > _startposX + _length)
        {
            _startposX += _length;
        }
        else if (tempX < _startposX - _length)
        {
            _startposX -= _length;
        }
    }

}