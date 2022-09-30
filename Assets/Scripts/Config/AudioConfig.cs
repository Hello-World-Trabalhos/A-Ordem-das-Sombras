using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioConfig
{
    public void EnableMusic(bool value)
    {
        PlayerPrefs.SetString(AudioConfigConstants.ENABLE_MUSIC_KEY, value.ToString());
        PlayerPrefs.Save();
    }

    public void SetMusicVolume(float value)
    {
        if (value < AudioConfigConstants.MIN_VOLUME_VALUE)
        {
            value = AudioConfigConstants.MIN_VOLUME_VALUE;
        }
        else if (value > AudioConfigConstants.MAX_VOLUME_VALUE)
        {
            value = AudioConfigConstants.MAX_VOLUME_VALUE;
        }

        PlayerPrefs.SetFloat(AudioConfigConstants.MUSIC_VOLUME_KEY, value);
        PlayerPrefs.Save();
    }

    public bool IsMusicEnabled()
    {
        if (!PlayerPrefs.HasKey(AudioConfigConstants.ENABLE_MUSIC_KEY))
        {
            EnableMusic(AudioConfigConstants.ENABLE_MUSIC_DEFAULT_VALUE);
        }

        return bool.Parse(PlayerPrefs.GetString(AudioConfigConstants.ENABLE_MUSIC_KEY));
    }

    public float GetMusicVolume()
    {
        if (!PlayerPrefs.HasKey(AudioConfigConstants.MUSIC_VOLUME_KEY))
        {
            SetMusicVolume(AudioConfigConstants.MUSIC_VOLUME_DEFAULT_VALUE);
        }

        return PlayerPrefs.GetFloat(AudioConfigConstants.MUSIC_VOLUME_KEY);
    }
}
