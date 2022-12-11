using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.Audio;
public class AudioController : MonoBehaviour
{


    public AudioMixer am;
    public void PlaySound(AudioSource Sound)
    {
        Sound.Play();
    }
    public void SwitchVolume(float sliderValue)
    {
        am.SetFloat("masterVolume", sliderValue);
    }
}
