using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private AudioSource audioSource;
    private readonly AudioConfig audioConfig = new AudioConfig();

    void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
        ConfigureAudioBasedOnSavedConfigValues();
    }

    public void ConfigureAudioBasedOnSavedConfigValues()
    {
        SetMusicVolumeFromSavedConfigValue();
        ToggleMusicUsingSavedConfigValue();
    }

    private void ToggleMusicUsingSavedConfigValue()
    {
        if (audioConfig.IsMusicEnabled())
        {
            if (!audioSource.isPlaying)
            {
                audioSource.Play();
            }
        }
        else
        {
            if (audioSource.isPlaying)
            {
                audioSource.Stop();
            }
        }
    }

    private void SetMusicVolumeFromSavedConfigValue()
    {
        audioSource.volume = audioConfig.GetMusicVolume();
    }
}
