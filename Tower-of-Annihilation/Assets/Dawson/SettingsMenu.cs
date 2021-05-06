using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SettingsMenu : MonoBehaviour
{
    public AudioMixer audioMixer;
    private GameObject player;

    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("Volume", volume);
    }

    public void BcMode(bool _isOn)
    {
        Debug.Log("HELLO");
        player = GameObject.FindGameObjectWithTag("Player");
        player.GetComponent<PlayerManager>().EnableBCMode();
    }
}