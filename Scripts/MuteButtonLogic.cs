using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;




public class MuteButtonLogic : MonoBehaviour
{
    //This is telling us if the application is muted or not.
    public bool isMuted;

    //These are images stored in an array. 
    public Sprite[] onOffIcons;
    //This is the image component that displays the icon you want.
    public Image iconHolder;

    //This is the sound mixer that you mute.
    public AudioMixerGroup masterSound;



    private void Start()
    {
        //When this object is activated load in the current muted key and check if it should display currently muted or not.
        LoadToggle();
        
    }

    //This function is called to save the current volume mute boolean.
    public void SaveToggle()
    {
        //First I need to convert the boolean into an integer so I can save it. As there isn't a SetBool function, only SetInt.
        int convertedBool = Convert.ToInt32(isMuted);
        //I give the Saved Information a keyword and a value that associates to it.
        PlayerPrefs.SetInt("IsMuted", convertedBool);
        
    }

    //This function checks to see if the isMuted is current muted or not from the saved data.
    public void LoadToggle()
    {
        if(PlayerPrefs.HasKey("IsMuted"))
        {
            //We retrieve the saved value from the player prefs
            int currentIsMutedValue = PlayerPrefs.GetInt("IsMuted");
            isMuted = Convert.ToBoolean(currentIsMutedValue);
            ToggleSound();
        }   
        else
        {
            isMuted = false;
            ToggleSound();
        }

    }

    //This is a function you use to mute and unmute.
    public void ToggleMute()
    { 
        isMuted = !isMuted;
        //Toggle sound function gets called to change the volume.
        ToggleSound();

    }
    //This function is in charge of the muting. 
    public void ToggleSound()
    {
        int index = Convert.ToInt32(isMuted);
        iconHolder.sprite = onOffIcons[index];
        //Set the volume
        if (isMuted == true)
        {
            masterSound.audioMixer.SetFloat("Volume", -80);
        }
        else
        {
            masterSound.audioMixer.SetFloat("Volume", 0);
        }

       
        SaveToggle();
    }



}
