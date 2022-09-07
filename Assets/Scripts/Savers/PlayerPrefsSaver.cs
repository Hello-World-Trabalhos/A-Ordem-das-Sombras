using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPrefsSaver
{
    public void EnableObstaclesGeneration(bool value)
    {
        PlayerPrefs.SetString(ScenarioGeneratiorViewerConstants.ENABLE_OBSTACLES_GENERATION, value.ToString());
    }

    public void EnableEnemiesGeneration(bool value)
    {
        PlayerPrefs.SetString(ScenarioGeneratiorViewerConstants.ENABLE_ENEMIES_GENERATION, value.ToString());
    }

    public void EnablePlayerGeneration(bool value)
    {
        PlayerPrefs.SetString(ScenarioGeneratiorViewerConstants.ENABLE_PLAYER_GENERATION, value.ToString());
    }

    public void EnableBossGeneration(bool value)
    {
        PlayerPrefs.SetString(ScenarioGeneratiorViewerConstants.ENABLE_BOSS_GENERATION, value.ToString());
    }

    public void EnemiesAmmount(int value)
    {
        if (value < ScenarioGeneratiorViewerConstants.MIN_ENEMIES_AMMOUNT)
        {
            value = ScenarioGeneratiorViewerConstants.MIN_ENEMIES_AMMOUNT;
        }
        else if (value > ScenarioGeneratiorViewerConstants.MAX_ENEMIES_AMMOUNT)
        {
            value = ScenarioGeneratiorViewerConstants.MAX_ENEMIES_AMMOUNT;
        }

        PlayerPrefs.SetInt(ScenarioGeneratiorViewerConstants.ENEMIES_AMOUNT, value);
    }

    public void EnableLightBackground(bool value)
    {
        PlayerPrefs.SetString(ScenarioGeneratiorViewerConstants.ENABLE_LIGHT_BACKGROUND, value.ToString());
    }

    public bool IsObstacleGenerationEnabled()
    {
        if (!PlayerPrefs.HasKey(PlayerPrefs.GetString(ScenarioGeneratiorViewerConstants.ENABLE_OBSTACLES_GENERATION)))
        {
            PlayerPrefs.SetString(
                ScenarioGeneratiorViewerConstants.ENABLE_OBSTACLES_GENERATION, 
                ScenarioGeneratiorViewerConstants.ENABLE_OBSTACLES_GENERATION_DEFAULT_VALUE.ToString()
            );
        }

        return bool.Parse(PlayerPrefs.GetString(ScenarioGeneratiorViewerConstants.ENABLE_OBSTACLES_GENERATION));
    }

    public bool IsEnemyGenerationEnabled()
    {
        if (!PlayerPrefs.HasKey(PlayerPrefs.GetString(ScenarioGeneratiorViewerConstants.ENABLE_ENEMIES_GENERATION)))
        {
            PlayerPrefs.SetString(
                ScenarioGeneratiorViewerConstants.ENABLE_ENEMIES_GENERATION,
                ScenarioGeneratiorViewerConstants.ENABLE_ENEMIES_GENERATION_DEFAULT_VALUE.ToString()
            );
        }

        return bool.Parse(PlayerPrefs.GetString(ScenarioGeneratiorViewerConstants.ENABLE_ENEMIES_GENERATION));
    }

    public bool IsPlayerGenerationEnabled()
    {
        if (!PlayerPrefs.HasKey(PlayerPrefs.GetString(ScenarioGeneratiorViewerConstants.ENABLE_PLAYER_GENERATION)))
        {
            PlayerPrefs.SetString(
                ScenarioGeneratiorViewerConstants.ENABLE_PLAYER_GENERATION,
                ScenarioGeneratiorViewerConstants.ENABLE_PLAYER_GENERATION_DEFAULT_VALUE.ToString()
            );
        }

        return bool.Parse(PlayerPrefs.GetString(ScenarioGeneratiorViewerConstants.ENABLE_PLAYER_GENERATION));
    }

    public bool IsBossGenerationEnabled()
    {
        if (!PlayerPrefs.HasKey(PlayerPrefs.GetString(ScenarioGeneratiorViewerConstants.ENABLE_BOSS_GENERATION)))
        {
            PlayerPrefs.SetString(
                ScenarioGeneratiorViewerConstants.ENABLE_BOSS_GENERATION,
                ScenarioGeneratiorViewerConstants.ENABLE_BOSS_GENERATION_DEFAULT_VALUE.ToString()
            );
        }

        return bool.Parse(PlayerPrefs.GetString(ScenarioGeneratiorViewerConstants.ENABLE_BOSS_GENERATION));
    }

    public bool IsLightbackgroundEnabled()
    {
        if (!PlayerPrefs.HasKey(PlayerPrefs.GetString(ScenarioGeneratiorViewerConstants.ENABLE_LIGHT_BACKGROUND)))
        {
            PlayerPrefs.SetString(
                ScenarioGeneratiorViewerConstants.ENABLE_LIGHT_BACKGROUND,
                ScenarioGeneratiorViewerConstants.ENABLE_LIGHT_BACKGROUND_DEFAULT_VALUE.ToString()
            );
        }

        return bool.Parse(PlayerPrefs.GetString(ScenarioGeneratiorViewerConstants.ENABLE_LIGHT_BACKGROUND));
    }

    public int GetEnemiesAmmount()
    {
        if (!PlayerPrefs.HasKey(PlayerPrefs.GetString(ScenarioGeneratiorViewerConstants.ENEMIES_AMOUNT)))
        {
            PlayerPrefs.SetInt(
                ScenarioGeneratiorViewerConstants.ENEMIES_AMOUNT,
                ScenarioGeneratiorViewerConstants.ENEMIES_AMOUNT_DEFAULT_VALUE
            );
        }

        return PlayerPrefs.GetInt(ScenarioGeneratiorViewerConstants.ENEMIES_AMOUNT);
    }
}
