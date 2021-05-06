using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SettingsMenu : MonoBehaviour
{
    public AudioMixer audioMixer;
    public GameObject BCObject;
    
    void Start()
    {
        
    }
    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("Volume", volume);
    }

    public void BcMode(bool _isOn)
    {
        BCObject = GameObject.FindGameObjectWithTag("BCMode");
        BCObject.GetComponent<BCMODE>().EnableBCMode();
        FindObjectOfType<SoundManager>().Play("Yeet");
        //Instantiate();
        // player = GameObject.FindGameObjectWithTag("Player");
        // player.GetComponent<PlayerManager>().EnableBCMode();
    }
}