
using UnityEngine;

using UnityEngine.Audio;
public class VolumeLoader : MonoBehaviour
{

    public AudioMixer mixer;
    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.HasKey("musicVolume"))
        {
            float volume = PlayerPrefs.GetFloat("musicVolume");
            mixer.SetFloat("music", Mathf.Log10(volume) * 20);
        }
        if (PlayerPrefs.HasKey("sfxVolume"))
        {
            float volume = PlayerPrefs.GetFloat("sfxVolume");
            mixer.SetFloat("sfx", Mathf.Log10(volume) * 20);
        }
    }
}
