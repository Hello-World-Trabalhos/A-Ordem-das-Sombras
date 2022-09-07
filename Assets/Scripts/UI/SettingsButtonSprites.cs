using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsButtonSprites : MonoBehaviour
{
    public Sprite[] configButtonSprites;
    public int blackButtonIndex;
    public int whiteButtonIndex;

    void Start()
    {
        blackButtonIndex = configButtonSprites[0].name.Contains("black") ? 0 : 1;
        whiteButtonIndex = configButtonSprites[0].name.Contains("white") ? 0 : 1;
    }

    public Sprite GetBlackButtonVariation()
    {
        return configButtonSprites[blackButtonIndex];
    }

    public Sprite GetWhiteButtonVariation()
    {
        return configButtonSprites[whiteButtonIndex];
    }
}
