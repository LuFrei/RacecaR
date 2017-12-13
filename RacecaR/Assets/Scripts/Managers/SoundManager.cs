using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SoundManager : MonoBehaviour
{
    System.Random rand = new System.Random();

    public static SoundManager instance;

    public AudioClip[] musicAudioClips;
    public AudioClip[] sfxAudioClips;

    public AudioSource musicAudioSource;
    public AudioSource sfxAudioSource;

    public AudioClip currentSongAudioClip;

    public float songDelay;
    public int currentSongIndex = -1;
    public int previousSongIndex;
    public bool shuffle;

    void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
    }

    // Use this for initialization
    void Start ()
    {
        playMusic();
    }
	
	// Update is called once per frame
	void Update ()
    {
        /*if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            CancelInvoke("playMusic");
            playMusic();
        }*/
    }

    void playMusic()
    {
        previousSongIndex = currentSongIndex;

        if (shuffle)
        {
            do
                currentSongIndex = rand.Next(musicAudioClips.Length);
            while (currentSongIndex == previousSongIndex);
        }
        else
        {
            if (currentSongIndex == musicAudioClips.Length - 1)
                currentSongIndex = 0;
            else
                currentSongIndex++;
        }

        currentSongAudioClip = musicAudioClips[currentSongIndex];

        musicAudioSource.clip = currentSongAudioClip;
        musicAudioSource.Play();

        Debug.Log("Now Playing: " + musicAudioSource.clip.name);

        Invoke("playMusic", musicAudioSource.clip.length + songDelay);
    }

    public void playSFX(int index)
    {
        sfxAudioSource.clip = sfxAudioClips[index];
        sfxAudioSource.Play();
    }

    public void adjustMasterVolume(float newVol) { AudioListener.volume = newVol / 100; }

    public void adjustMusicVolume(float newVol) { musicAudioSource.volume = newVol / 100; }

    public void adjustSFXVolume(float newVol) { sfxAudioSource.volume = newVol / 100; }
}