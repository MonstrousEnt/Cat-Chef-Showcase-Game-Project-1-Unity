/* Name: Daniel Cox, Spencer Stoddard 
 * Date: July 6 - September 23, 2020
 * Description: This class holds all the data type for the sounds
 * Notes: 
 * Audio Manager Tutorial Used: https://youtu.be/6OT43pvUyfY
 */

//Libraries
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;


[System.Serializable]
public class Sound
{
    //Class Variables
    public string name; //Name of the sound
    public AudioClip clip; //The clip of the sound

    [Range(0f, 1f)]
    public float volume; //The volume of the sound
    
    [Range(.1f, 3f)]
    public float pitch; //The pitch of the sounds

    public bool loop; //loop the sound
	
	[SerializeField] private bool playOnAwake; //Sound played when the game starts

    [HideInInspector]
    public AudioSource source; //The source of the sound

}