using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioManager : GOSingleton<AudioManager>
{
    bool isBGM=false;
    bool isSFX = false;
    public List<AudioClip> audioMenu;
    public AudioClip audioCoin;
    public AudioClip audioAttack;
    public AudioClip audioDie;
    public AudioClip audioTeleport;
    public AudioClip audioJump;
    public AudioClip audioMove;
    public AudioClip audioThrow;
    public AudioClip audioOnHit;
    [SerializeField]private AudioSource audioCurrent;
    [SerializeField] private AudioSource audioGame;
    [SerializeField] GameObject sliderAudioGame;

    private void Start()
    {
        GetInstance();
    }
    public void PlaySound(AudioClip audioClip)
    {
        audioCurrent.clip = audioClip;
        audioCurrent.Play();
    }

    public void EnableAudioGame()
    {
        isBGM = isBGM==true?false:true;
        if (isBGM == true) { 
            audioGame.Play();
        
        } else { 
            audioGame.Stop();
        }
    }
    public void EnableAudioGame(bool flag)
    {
        isBGM = flag;
        if (isBGM == true)
        {
            audioGame.Play();

        }
        else
        {
            audioGame.Stop();
        }
    }
    public void SetAudioGame()
    {
        audioGame.volume = sliderAudioGame.GetComponent<Slider>().value;
        
    }

    public void EnableSFX()
    {
        isSFX = isSFX == true ? false : true;
        if (isSFX == true)
        {
            audioCurrent.volume=1;

        }
        else
        {
            audioCurrent.volume=0 ; 
        }
    }
    public void EnableSFX(bool flag)
    {
        isSFX = flag;
        if (isSFX == true)
        {
            audioCurrent.volume = 1;

        }
        else
        {
            audioCurrent.volume = 0;
        }
    }

}
