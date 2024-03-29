﻿/* Project Name: Arcade 2D Platformer
 * Team Name: Monstrous Entertainment - Vex Team
 * Authors: Daniel Cox, Spencer Stoddard 
 * Created Date: July 6, 2020
 * Latest Update: February 11, 2022
 * Description: This manager all the sounds in the game.
 * Notes: Audio Manager Tutorial Used: https://youtu.be/6OT43pvUyfY
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using System;

public class AudioManager : MonoBehaviour
{
    //Class Variables
    public static AudioManager instance;

    [SerializeField] private Sound[] _sounds; 

    private void Awake()
    {
        //---Make sure there is only one instance of this class for each Scene.

        //If there is no instance of the object
        if (instance == null)
        {
            //Set an instance of it
            instance = this;
        }

        //Else, if there's already an instance
        else
        {
            //Destroy it
            Destroy(gameObject);
            return;
        }

        //--------------------------------------------------------------------------

        foreach (Sound s in _sounds)
        {
			//set the component of the sound
			s.source = gameObject.AddComponent<AudioSource>(); 

            //Set the clip of the sound
            s.source.clip = s.clip;

            //Set the volume of the sound
            s.source.volume = s.volume;

            //Set the pitch of the sound
            s.source.pitch = s.pitch;

            //Set the loop of the sound
            s.source.loop = s.loop;
        }
    }

    /// <summary>
    /// Find the sound by the index of it.
    /// </summary>
    /// <param name="index"></param>
    /// <returns></returns>
    private Sound findAudioByIndex(int index)
    {
        Sound s = _sounds[index];
        return s;
    }


    /// <summary>
    /// Find the sound by the name of it.
    /// </summary>
    /// <param name="name"></param>
    /// <returns></returns>
    private Sound findAudio(string name)
	{
		//Find the name of the sound
        Sound s = Array.Find(_sounds, sound => sound.name == name);

        //If the name is null
        if (s == null)
        {
            //Let the user know that a sound cannot be found
            Debug.LogWarning("Sound: " + name + "not found!");
            return null;
        }

		return s;
	}

	/// <summary>
	/// Set the loop of the sound.
	/// </summary>
	/// <param name="name"></param>
	/// <param name="flag"></param>
	public void SetAudioLoop(string name, bool flag)
	{
		//Find the sound
		Sound s = findAudio(name);

		//Set the loop 
		s.loop = flag;
	}

	/// <summary>
	/// Play the sound.
	/// </summary>
	public void playAudio (string name)
    {
		//Find the sound
		Sound s = findAudio(name);

        //Play the sound
        s.source.Play();
    }

	/// <summary>
	/// Stop the sound.
	/// </summary>
	/// <param name="name"></param>
	public void stopAudio(string name)
	{
		//Find the sound
		Sound s = findAudio(name);

		//Stop the sound
		s.source.Stop();
	}
}