
using UnityEngine;
using System;


public class AudioManager : MonoBehaviour
{
    //public static AudioManager instance;
    public Sound[] sounds;
    private void Awake()
    {
        //if(instance == null)
        //{
        //    instance = this;
        //}
        //else
        //{
        //    Destroy(gameObject);
        //}
        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.outputAudioMixerGroup = s.group;
        }
        
    }
    public void Play(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        
        s.source.Play();
    }
    public void StopPlayer(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
       

        if (s == null)
        {
            print("sound not found");
        }
        else
        {
            s.source.Stop();
        }
    }
    public void Pause(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        s.source.Pause();
    }
    public void UnPause(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        s.source.UnPause();
    }
}

