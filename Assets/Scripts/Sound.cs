
using UnityEngine;
using System;
using UnityEngine.Audio;

[Serializable]
public class Sound
{
    public string name;

    public AudioClip clip;
    public AudioMixerGroup group;
    
    [Range(0f, 1f)]
    public float volume;
    
    [Range(.1f, 3f)]
    public float pitch;

    [HideInInspector]
    public AudioSource source;
    
    //[Range(0f, 1f)]
    //public float volumeVariance;
    
    //[Range(.1f, 3f)]
    //public float pitchVariance;

}
