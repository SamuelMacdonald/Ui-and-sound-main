using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class Musicvolume : MonoBehaviour
{
    [SerializeField] private AudioMixer myMix;
    [SerializeField] private Slider masterSlider;
    [SerializeField] private Slider musicSlider;
    [SerializeField] private Slider SFXSlider;

    
    bool isMuted;
  
    private void Start()
    {
        if(PlayerPrefs.HasKey("musicVolume"))
        {
            LoadVolume();
        }
        else
        {
            SetMusic();
            SetMaster();
            SetSFX();
        }
       
    }

    public void MuteToggle(bool muted)
    {
        if (muted)
        {
            myMix.SetFloat("Music", -80);
            isMuted = true;
        }
        else
        {
            LoadVolume();
            isMuted = false;
            SetMusic();
        }
    }


    public void SetMusic()
    {
        if(isMuted == false)
        {
            float volume = musicSlider.value;
            myMix.SetFloat("Music", volume);
            PlayerPrefs.SetFloat("musicVolume", volume);
        }
    }
    public void SetSFX()
    {
        float volume = SFXSlider.value;
        myMix.SetFloat("SFX", volume);
        PlayerPrefs.SetFloat("SFXVolume", volume);
    }
    public void SetMaster()
    {
        float volume = masterSlider.value;
        myMix.SetFloat("Master", volume);
        PlayerPrefs.SetFloat("MasterVolume", volume);
    }
    private void LoadVolume()
    {
        musicSlider.value = PlayerPrefs.GetFloat("musicVolume");
        SFXSlider.value = PlayerPrefs.GetFloat("SFXVolume");
        masterSlider.value = PlayerPrefs.GetFloat("MasterVolume");

        SetMusic();
        SetSFX();
        SetMaster();
    }
}

