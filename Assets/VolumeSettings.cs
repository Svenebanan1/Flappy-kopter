using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class VolumeSettings : MonoBehaviour
{
    [SerializeField] private AudioMixer myMixer;
    [SerializeField] private Slider MusicSlider;
    [SerializeField] private Slider SFXSlider;
    [SerializeField] private Slider LobbyMusicSlider;
    private void Start()
    {
        if (PlayerPrefs.HasKey("musicVolume"))
        {
            LoadVolume();
        }
        else
        {
            SetMusicVolume();
            SetSFXVolume();
            SetLobbyMusicVolume();
        }
        
    }
    public void SetMusicVolume()
    {
        float volume = MusicSlider.value;
        myMixer.SetFloat("Music", Mathf.Log10(volume)*20);
        PlayerPrefs.SetFloat("musicVolume", volume);
    }
    public void SetSFXVolume()
    {
        float volume = SFXSlider.value;
        myMixer.SetFloat("SFX", Mathf.Log10(volume) * 20);
        PlayerPrefs.SetFloat("SFXVolume", volume);
    }
    public void SetLobbyMusicVolume()
    {
        float volume = LobbyMusicSlider.value;
        myMixer.SetFloat("LobbyMusic", Mathf.Log10(volume) * 20);
        PlayerPrefs.SetFloat("lobbymusicVolume", volume);
    }
    private void LoadVolume()
    {
        MusicSlider.value = PlayerPrefs.GetFloat("musicVolume");
        SFXSlider.value = PlayerPrefs.GetFloat("SFXVolume");
        LobbyMusicSlider.value = PlayerPrefs.GetFloat("lobbymusicVolume");
        SetMusicVolume();
        SetSFXVolume();
        SetLobbyMusicVolume();
    }
}
