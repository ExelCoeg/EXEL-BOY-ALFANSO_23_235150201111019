
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioSlider : MonoBehaviour
{
    public Slider musicSlider;
    public Slider SFXSlider;
    public AudioMixer mixer;
    private void Start()
    {
        if (PlayerPrefs.HasKey("musicVolume"))
        {
            LoadVolume();

        }
        else
        {
            SetMusicVolume();
            
        }
        if (PlayerPrefs.HasKey("sfxVolume"))
        {
            LoadSFX();
        }
        else
        {
            SetMusicVolume();
        }
       
    }
    public void SetMusicVolume()
    {
        float volume = musicSlider.value;
        mixer.SetFloat("music", Mathf.Log10(volume)*20);
        PlayerPrefs.SetFloat("musicVolume", volume);
    }
    public void SetSFXVolume()
    {
        float volume = SFXSlider.value;
        mixer.SetFloat("sfx", Mathf.Log10(volume) * 20);
        PlayerPrefs.SetFloat("sfxVolume", volume);
    }

    private void LoadVolume()
    {
        musicSlider.value = PlayerPrefs.GetFloat("musicVolume");
        SetMusicVolume();
    }
    private void LoadSFX()
    {
        SFXSlider.value = PlayerPrefs.GetFloat("sfxVolume");
        float volume = SFXSlider.value;
        SetSFXVolume();
    }
}
