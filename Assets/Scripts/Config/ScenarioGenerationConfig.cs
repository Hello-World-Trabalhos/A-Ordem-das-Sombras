using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScenarioGenerationConfig
{
    public void EnableObstaclesGeneration(bool value)
    {
        PlayerPrefs.SetString(ScenarioGenerationViewerConstants.ENABLE_OBSTACLES_GENERATION_KEY, value.ToString());
        PlayerPrefs.Save();
    }

    public void EnableEnemiesGeneration(bool value)
    {
        PlayerPrefs.SetString(ScenarioGenerationViewerConstants.ENABLE_ENEMIES_GENERATION_KEY, value.ToString());
        PlayerPrefs.Save();
    }

    public void EnablePlayerGeneration(bool value)
    {
        PlayerPrefs.SetString(ScenarioGenerationViewerConstants.ENABLE_PLAYER_GENERATION_KEY, value.ToString());
        PlayerPrefs.Save();
    }

    public void EnableBossGeneration(bool value)
    {
        PlayerPrefs.SetString(ScenarioGenerationViewerConstants.ENABLE_BOSS_GENERATION_KEY, value.ToString());
        PlayerPrefs.Save();
    }

    public void EnemiesAmmount(int value)
    {
        if (value < ScenarioGenerationViewerConstants.MIN_ENEMIES_AMMOUNT)
        {
            value = ScenarioGenerationViewerConstants.MIN_ENEMIES_AMMOUNT;
        }
        else if (value > ScenarioGenerationViewerConstants.MAX_ENEMIES_AMMOUNT)
        {
            value = ScenarioGenerationViewerConstants.MAX_ENEMIES_AMMOUNT;
        }

        PlayerPrefs.SetInt(ScenarioGenerationViewerConstants.ENEMIES_AMOUNT_KEY, value);
        PlayerPrefs.Save();
    }

    public bool IsObstacleGenerationEnabled()
    {
        if (!PlayerPrefs.HasKey(ScenarioGenerationViewerConstants.ENABLE_OBSTACLES_GENERATION_KEY))
        {
            EnableObstaclesGeneration(ScenarioGenerationViewerConstants.ENABLE_OBSTACLES_GENERATION_DEFAULT_VALUE);
        }

        return bool.Parse(PlayerPrefs.GetString(ScenarioGenerationViewerConstants.ENABLE_OBSTACLES_GENERATION_KEY));
    }

    public bool IsEnemyGenerationEnabled()
    {
        if (!PlayerPrefs.HasKey(ScenarioGenerationViewerConstants.ENABLE_ENEMIES_GENERATION_KEY))
        {
            EnableEnemiesGeneration(ScenarioGenerationViewerConstants.ENABLE_ENEMIES_GENERATION_DEFAULT_VALUE);
        }

        return bool.Parse(PlayerPrefs.GetString(ScenarioGenerationViewerConstants.ENABLE_ENEMIES_GENERATION_KEY));
    }

    public bool IsPlayerGenerationEnabled()
    {
        if (!PlayerPrefs.HasKey(ScenarioGenerationViewerConstants.ENABLE_PLAYER_GENERATION_KEY))
        {
            EnablePlayerGeneration(ScenarioGenerationViewerConstants.ENABLE_PLAYER_GENERATION_DEFAULT_VALUE);
        }

        return bool.Parse(PlayerPrefs.GetString(ScenarioGenerationViewerConstants.ENABLE_PLAYER_GENERATION_KEY));
    }

    public bool IsBossGenerationEnabled()
    {
        if (!PlayerPrefs.HasKey(ScenarioGenerationViewerConstants.ENABLE_BOSS_GENERATION_KEY))
        {
            EnableBossGeneration(ScenarioGenerationViewerConstants.ENABLE_BOSS_GENERATION_DEFAULT_VALUE);
        }

        return bool.Parse(PlayerPrefs.GetString(ScenarioGenerationViewerConstants.ENABLE_BOSS_GENERATION_KEY));
    }

    public int GetEnemiesAmmount()
    {
        if (!PlayerPrefs.HasKey(ScenarioGenerationViewerConstants.ENEMIES_AMOUNT_KEY))
        {
            EnemiesAmmount(ScenarioGenerationViewerConstants.ENEMIES_AMOUNT_DEFAULT_VALUE);
        }

        return PlayerPrefs.GetInt(ScenarioGenerationViewerConstants.ENEMIES_AMOUNT_KEY);
    }
}
