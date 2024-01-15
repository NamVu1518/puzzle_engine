using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UISetting : UICanvas
{
    [SerializeField] private Slider sliderControlMusicVolume;
    [SerializeField] private Slider sliderControlSFXVolume;

    private void OnEnable()
    {
        sliderControlMusicVolume.value = PlayerPrefs.GetFloat(Constant.KEY_DATA_VOLUME_MUSIC);
        sliderControlSFXVolume.value = PlayerPrefs.GetFloat(Constant.KEY_DATA_VOLUME_SFX);

        sliderControlMusicVolume.onValueChanged.AddListener((value) => SoundManager.Ins.SetMusicVolume(sliderControlMusicVolume));
        sliderControlSFXVolume.onValueChanged.AddListener((value) => SoundManager.Ins.SetSFXVolume(sliderControlSFXVolume));
    }
}
