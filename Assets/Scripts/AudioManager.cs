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

    void Start() {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlaySound(AudioClip sound) {
        audioSource.PlayOneShot(sound);
    }

}
