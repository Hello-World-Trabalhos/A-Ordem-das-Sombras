using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScenarioGenerationConfig
{
    public void EnableObstaclesGeneration(bool value)
    {
        PlayerPrefs.SetString(ScenarioGeneratiorViewerConstants.ENABLE_OBSTACLES_GENERATION_KEY, value.ToString());
        PlayerPrefs.Save();
    }

    public void EnableEnemiesGeneration(bool value)
    {
        PlayerPrefs.SetString(ScenarioGeneratiorViewerConstants.ENABLE_ENEMIES_GENERATION_KEY, value.ToString());
        PlayerPrefs.Save();
    }

    public void EnablePlayerGeneration(bool value)
    {
        PlayerPrefs.SetString(ScenarioGeneratiorViewerConstants.ENABLE_PLAYER_GENERATION_KEY, value.ToString());
        PlayerPrefs.Save();
    }

    public void EnableBossGeneration(bool value)
    {
        PlayerPrefs.SetString(ScenarioGeneratiorViewerConstants.ENABLE_BOSS_GENERATION_KEY, value.ToString());
        PlayerPrefs.Save();
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

        PlayerPrefs.SetInt(ScenarioGeneratiorViewerConstants.ENEMIES_AMOUNT_KEY, value);
        PlayerPrefs.Save();
    }

    public bool IsObstacleGenerationEnabled()
    {
        if (!PlayerPrefs.HasKey(ScenarioGeneratiorViewerConstants.ENABLE_OBSTACLES_GENERATION_KEY))
        {
            EnableObstaclesGeneration(ScenarioGeneratiorViewerConstants.ENABLE_OBSTACLES_GENERATION_DEFAULT_VALUE);
        }

        return bool.Parse(PlayerPrefs.GetString(ScenarioGeneratiorViewerConstants.ENABLE_OBSTACLES_GENERATION_KEY));
    }

    public bool IsEnemyGenerationEnabled()
    {
        if (!PlayerPrefs.HasKey(ScenarioGeneratiorViewerConstants.ENABLE_ENEMIES_GENERATION_KEY))
        {
            EnableEnemiesGeneration(ScenarioGeneratiorViewerConstants.ENABLE_ENEMIES_GENERATION_DEFAULT_VALUE);
        }

        return bool.Parse(PlayerPrefs.GetString(ScenarioGeneratiorViewerConstants.ENABLE_ENEMIES_GENERATION_KEY));
    }

    public bool IsPlayerGenerationEnabled()
    {
        if (!PlayerPrefs.HasKey(ScenarioGeneratiorViewerConstants.ENABLE_PLAYER_GENERATION_KEY))
        {
            EnablePlayerGeneration(ScenarioGeneratiorViewerConstants.ENABLE_PLAYER_GENERATION_DEFAULT_VALUE);
        }

        return bool.Parse(PlayerPrefs.GetString(ScenarioGeneratiorViewerConstants.ENABLE_PLAYER_GENERATION_KEY));
    }

    public bool IsBossGenerationEnabled()
    {
        if (!PlayerPrefs.HasKey(ScenarioGeneratiorViewerConstants.ENABLE_BOSS_GENERATION_KEY))
        {
            EnableBossGeneration(ScenarioGeneratiorViewerConstants.ENABLE_BOSS_GENERATION_DEFAULT_VALUE);
        }

        return bool.Parse(PlayerPrefs.GetString(ScenarioGeneratiorViewerConstants.ENABLE_BOSS_GENERATION_KEY));
    }

    public int GetEnemiesAmmount()
    {
        if (!PlayerPrefs.HasKey(ScenarioGeneratiorViewerConstants.ENEMIES_AMOUNT_KEY))
        {
            EnemiesAmmount(ScenarioGeneratiorViewerConstants.ENEMIES_AMOUNT_DEFAULT_VALUE);
        }

        return PlayerPrefs.GetInt(ScenarioGeneratiorViewerConstants.ENEMIES_AMOUNT_KEY);
    }
}
