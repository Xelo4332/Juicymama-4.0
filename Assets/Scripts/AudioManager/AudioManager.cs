using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Deni
//This script is our manager for all of our audio that we will use in the game.
//With help of instance we will store our audio date in audio manager. 
public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;
    [SerializeField] private AudioSource _sfxSource;
    //When we will boot the game, the first thing will unity to is to activate instance so we can store our audio date.
    private void Awake()
    {
        Instance = this;
    }
    //Here we are able to play our audio in this method.
    public void PlaySound(AudioClip clip)
    {
        _sfxSource.clip = clip;
        _sfxSource.Play();
    }

}
