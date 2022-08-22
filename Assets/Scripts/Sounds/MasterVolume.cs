using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class MasterVolume : MonoBehaviour
{
    public AudioMixer masterVolume;
    public Slider VolumeSlider;

    private void Start()
    {
        VolumeSlider.value = .5f;
        OnMasterVolumeChange();
    }
    public void OnMasterVolumeChange()
    {
        float newVolume = VolumeSlider.value;
        newVolume = Mathf.Log10(newVolume);
        newVolume = newVolume * 20;
        masterVolume.SetFloat("Master", newVolume);
    }
}

