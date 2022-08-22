using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AmbientVolume : MonoBehaviour
{
    public AudioMixer ambientVolume;
    public Slider VolumeSlider;

    private void Start()
    {
        VolumeSlider.value = .5f;
        OnAmbientVolumeChange();
    }
    public void OnAmbientVolumeChange()
    {
        float newVolume = VolumeSlider.value;
        newVolume = Mathf.Log10(newVolume);
        newVolume = newVolume * 20;
        ambientVolume.SetFloat("Ambient", newVolume);
    }
}

