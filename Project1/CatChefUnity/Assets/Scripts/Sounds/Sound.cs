/* Project Name: Arcade 2D Platformer
 * Team Name: Monstrous Entertainment - Vex Team
 * Authors: Daniel Cox, Spencer Stoddard 
 * Created Date: July 6, 2020
 * Latest Update: February 11, 2022
 * Description: This class is data for the sounds.
 * Notes: Audio Manager Tutorial Used: https://youtu.be/6OT43pvUyfY
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;


[System.Serializable]
public class Sound
{
    //Class Variables
    public string name; 
    public AudioClip clip; 

    [Range(0f, 1f)]
    public float volume; 
    
    [Range(.1f, 3f)]
    public float pitch; 

    public bool loop; 
	
	[SerializeField] private bool playOnAwake; 

    [HideInInspector]
    public AudioSource source; 

}