using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class SoundManager : Singleton<SoundManager>
{
    private AudioClip[] musicSoundArray;
    private AudioClip[] SFXArray;

    //Audio Mixer 
    //***************************************************//
    [Tooltip("Drag Audio Mixer")]
    [Header("Audio Mixer")]
    [SerializeField] private AudioMixer audioMixerControlAll;

    //Background Sound variable
    //***************************************************//
    [Tooltip("Drag your Audio Souce in here")]
    [Header("Audio Souce")]
    [SerializeField] private AudioSource backgroundMusicAudioSouce;
    [SerializeField] private AudioSource sfxAudioSouce;

    //Background Sound variable
    //***************************************************//
    [Tooltip("Drag your background sound in here")]
    [Header("Background Sound")]

    [SerializeField] private AudioClip mainMenuMusic;
    [SerializeField] private AudioClip gameMenuMusic;
    [SerializeField] private AudioClip winMenuMusic;
    [SerializeField] private AudioClip loseMenuMusic;
    [SerializeField] private AudioClip shopMenuMusic;

    //Effec Sound variable
    //***************************************************//
    [Tooltip("Drag your Effect sound in here")]
    [Header("Effect Sound")]

    [SerializeField] private AudioClip hitSFX;
    [SerializeField] private AudioClip punishmentSFX;
    [SerializeField] private AudioClip rewardSFX;
    [SerializeField] private AudioClip buttonClickSFX;
    [SerializeField] private AudioClip buySFX;


    private void Awake()
    {
        SetUpMusicSoundArray();
        SetUpSFXArray();

        backgroundMusicAudioSouce.loop = true;

        //Register background sound
        RegisterSound(EnumMusic.MAINMENU_MUSIC, mainMenuMusic);
        RegisterSound(EnumMusic.GAMEMENU_MUSIC, gameMenuMusic);
        RegisterSound(EnumMusic.WINMENU_MUSIC, winMenuMusic);
        RegisterSound(EnumMusic.LOSEMENU_MUSIC, loseMenuMusic);
        RegisterSound(EnumMusic.SHOPMENU_MUSIC, shopMenuMusic);

        //Register SFX
        RegisterSound(EnumSFX.HIT_SFX, hitSFX);
        RegisterSound(EnumSFX.PUNISHMENT_SFX, punishmentSFX);
        RegisterSound(EnumSFX.REWARD_SFX, rewardSFX);
        RegisterSound(EnumSFX.BUTTON_CLICK_SFX, buttonClickSFX);
        RegisterSound(EnumSFX.BUY_SFX, buySFX);
    }

    private void Start()
    {
        ActionManager.Ins.AddAction(EnumAction.INIT, LoadMusicVolume);
        ActionManager.Ins.AddAction(EnumAction.INIT, LoadSFXVolume);
    }

    private void SetUpMusicSoundArray()
    {
        int amount = Enum.GetValues(typeof(EnumMusic)).Length;
        musicSoundArray = new AudioClip[amount];
    }

    private void SetUpSFXArray()
    {
        int amount = Enum.GetValues(typeof(EnumSFX)).Length;
        SFXArray = new AudioClip[amount];
    }



    //**********************************************************//
    #region Sound Manager Funtion
    //Function of Sound Manager
    //**********************************************************//
    public void RegisterSound(EnumMusic enumMusic = EnumMusic.NONE, AudioClip audioClip = null)
    {
        if (audioClip == null)
        {
            Debug.LogWarning("AudioClip pararmater can not be null");
            return;
        }

        musicSoundArray[(int)enumMusic] = audioClip;
    }

    public void RegisterSound(EnumSFX enumSFX = EnumSFX.NONE, AudioClip audioClip = null)
    {
        if (enumSFX == EnumSFX.NONE) return;

        if (audioClip == null)
        {
            Debug.LogWarning("AudioClip pararmater can not be null");
            return;
        }

        SFXArray[(int)enumSFX] = audioClip;
    }

    public void UnregisterSound(EnumSFX enumSFX = EnumSFX.NONE)
    {
        if (enumSFX == EnumSFX.NONE) return;

        SFXArray[(int)enumSFX] = null;
    }

    public void UnregisterSound(EnumMusic enumMusic = EnumMusic.NONE)
    {
        if (enumMusic == EnumMusic.NONE) return;

        musicSoundArray[(int)enumMusic] = null;
    }
    #endregion




    //***********************************************************************//
    #region Sound Control Funtion
    public void PlaySound(EnumMusic enumMusic = EnumMusic.NONE, bool isPlayAgainIfThisSoundPlaying = false)
    {
        if (musicSoundArray[(int)enumMusic] == null)
        {
            Debug.LogError(String.Format("{0} not yet register in array", enumMusic.ToString()));
            return;
        }

        if (backgroundMusicAudioSouce.clip == musicSoundArray[(int)enumMusic] && !isPlayAgainIfThisSoundPlaying)
        {
            return;
        }

        backgroundMusicAudioSouce.clip = musicSoundArray[(int)enumMusic];
        backgroundMusicAudioSouce.Play();
    }

    public void PlaySound(EnumSFX enumSFX = EnumSFX.NONE)
    {
        if (SFXArray[(int)enumSFX] == null)
        {
            Debug.LogError(String.Format("{0} not yet register in array", enumSFX.ToString()));
            return;
        }

        sfxAudioSouce.clip = SFXArray[(int)enumSFX];
        sfxAudioSouce.Play();
    }

    public void PauseSound(EnumMusic enumMusic = EnumMusic.NONE)
    {
        if (musicSoundArray[(int)enumMusic] == null)
        {
            Debug.LogError(String.Format("{0} not yet register in array", enumMusic.ToString()));
            return;
        }

        backgroundMusicAudioSouce.Pause();
    }

    public void PauseSound(EnumSFX enumSFX = EnumSFX.NONE)
    {
        if (SFXArray[(int)enumSFX] == null)
        {
            Debug.LogError(String.Format("{0} not yet register in array", enumSFX.ToString()));
            return;
        }

        sfxAudioSouce.Pause();
    }

    private void ResumeSound(EnumMusic enumMusic)
    {
        if (musicSoundArray[(int)enumMusic] == null)
        {
            Debug.LogError(String.Format("{0} not yet register in array", enumMusic.ToString()));
            return;
        }

        backgroundMusicAudioSouce.UnPause();
    }

    private void ResumeSound(EnumSFX enumSFX)
    {
        if (SFXArray[(int)enumSFX] == null)
        {
            Debug.LogError(String.Format("{0} not yet register in array", enumSFX.ToString()));
            return;
        }

        sfxAudioSouce.UnPause();
    }

    public void SetMusicVolume(Slider slider)
    {
        float volume = slider.value;
        audioMixerControlAll.SetFloat(Constant.KEY_VAR_MUSIC_VOLUME_CONTROL_AUDIO_MIXER, Mathf.Log10(volume) * 20);
        PlayerPrefs.SetFloat(Constant.KEY_DATA_VOLUME_MUSIC, volume);
    }

    public void LoadMusicVolume()
    {
        if (PlayerPrefs.HasKey(Constant.KEY_DATA_VOLUME_MUSIC))
        {
            float volume = PlayerPrefs.GetFloat(Constant.KEY_DATA_VOLUME_MUSIC);
            audioMixerControlAll.SetFloat(Constant.KEY_VAR_MUSIC_VOLUME_CONTROL_AUDIO_MIXER, Mathf.Log10(volume) * 20);

        }
        else
        {
            audioMixerControlAll.SetFloat(Constant.KEY_VAR_MUSIC_VOLUME_CONTROL_AUDIO_MIXER, Mathf.Log10(1f) * 20);
            PlayerPrefs.SetFloat(Constant.KEY_DATA_VOLUME_MUSIC, 1f);
        }
    }

    public void SetSFXVolume(Slider slider)
    {
        float volume = slider.value;
        audioMixerControlAll.SetFloat(Constant.KEY_VAR_SFX_VOLUME_CONTROL_AUDIO_MIXER, Mathf.Log10(volume) * 20);
        PlayerPrefs.SetFloat(Constant.KEY_DATA_VOLUME_SFX, volume);
    }

    public void LoadSFXVolume()
    {
        if (PlayerPrefs.HasKey(Constant.KEY_DATA_VOLUME_SFX))
        {
            float volume = PlayerPrefs.GetFloat(Constant.KEY_DATA_VOLUME_SFX);
            audioMixerControlAll.SetFloat(Constant.KEY_VAR_SFX_VOLUME_CONTROL_AUDIO_MIXER, Mathf.Log10(volume) * 20);
        }
        else
        {
            audioMixerControlAll.SetFloat(Constant.KEY_VAR_SFX_VOLUME_CONTROL_AUDIO_MIXER, Mathf.Log10(1f) * 20);
            PlayerPrefs.SetFloat(Constant.KEY_DATA_VOLUME_SFX, 1f);
        }
    }
    #endregion
}
