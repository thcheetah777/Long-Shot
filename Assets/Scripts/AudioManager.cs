using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    public AudioClip shoot;
    public AudioClip destroy;
    public AudioClip die;
    public AudioClip powerup;

    AudioSource audioSource;
    AudioSource backgroundMusic;

    void Start() {
        audioSource = GetComponent<AudioSource>();
        backgroundMusic = GameObject.Find("Background Music").GetComponent<AudioSource>();
        if (!SettingsManager.GetSettings("musicEnabled")) backgroundMusic.volume = 0;
    }

    public void PlaySound(AudioClip sound) {
        if (SettingsManager.GetSettings("sfxEnabled")) audioSource.PlayOneShot(sound);
    }

}
