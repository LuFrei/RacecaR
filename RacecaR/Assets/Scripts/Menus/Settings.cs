using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Settings : MonoBehaviour
{
    public Toggle soundToggle;

    public Slider masterVolumeSlider;
    public Slider musicVolumeSlider;
    public Slider sfxVolumeSlider;

    public Button settingsButton;

    // Use this for initialization
    void Start ()
    {
        soundToggle.GetComponentInChildren<Text>().text = "Sound: ON";
        soundToggle.onValueChanged.AddListener(delegate { onSoundToggle(); });

        masterVolumeSlider.onValueChanged.AddListener(delegate { SoundManager.instance.adjustMasterVolume(masterVolumeSlider.value); });
        musicVolumeSlider.onValueChanged.AddListener(delegate { SoundManager.instance.adjustMusicVolume(musicVolumeSlider.value); });
        sfxVolumeSlider.onValueChanged.AddListener(delegate { SoundManager.instance.adjustSFXVolume(sfxVolumeSlider.value); });

        settingsButton.onClick.AddListener(onReturn);
    }

    void onSoundToggle()
    {
        SoundManager.instance.adjustMasterVolume(soundToggle.isOn ? masterVolumeSlider.maxValue : masterVolumeSlider.minValue);
        soundToggle.GetComponentInChildren<Text>().text = "Sound: " + (soundToggle.isOn ? "ON" : "OFF");

        masterVolumeSlider.enabled = soundToggle.isOn ? true : false;
        musicVolumeSlider.enabled = soundToggle.isOn ? true : false;
        sfxVolumeSlider.enabled = soundToggle.isOn ? true : false;
    }

    void onReturn()
    {
        UIManager.instance.ChangeMenu(UIManager.instance.previousMenu);
    }
}