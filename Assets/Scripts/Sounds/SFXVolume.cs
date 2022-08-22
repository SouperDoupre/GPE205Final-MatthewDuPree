using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SFXVolume : MonoBehaviour
{
    public AudioMixer SFXAudio;
    public Slider VolumeSlider;

    private void Start()
    {
        VolumeSlider.value = .5f;
        OnSFXVolumeChange();
    }
    public void OnSFXVolumeChange()
    {
        float newVolume = VolumeSlider.value;
        newVolume = Mathf.Log10(newVolume);
        newVolume = newVolume * 20;
        SFXAudio.SetFloat("SFX", newVolume);
    }
}
