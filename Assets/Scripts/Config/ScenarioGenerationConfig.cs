using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScenarioGenerationConfig
{
    public void EnableObstaclesGeneration(bool value)
    {
        PlayerPrefs.SetString(ScenarioGeneratiorViewerConstants.ENABLE_OBSTACLES_GENERATION, value.ToString());
        PlayerPrefs.Save();
    }

    public void EnableEnemiesGeneration(bool value)
    {
        PlayerPrefs.SetString(ScenarioGeneratiorViewerConstants.ENABLE_ENEMIES_GENERATION, value.ToString());
        PlayerPrefs.Save();
    }

    public void EnablePlayerGeneration(bool value)
    {
        PlayerPrefs.SetString(ScenarioGeneratiorViewerConstants.ENABLE_PLAYER_GENERATION, value.ToString());
        PlayerPrefs.Save();
    }

    public void EnableBossGeneration(bool value)
    {
        PlayerPrefs.SetString(ScenarioGeneratiorViewerConstants.ENABLE_BOSS_GENERATION, value.ToString());
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

        PlayerPrefs.SetInt(ScenarioGeneratiorViewerConstants.ENEMIES_AMOUNT, value);
        PlayerPrefs.Save();
    }

    public bool IsObstacleGenerationEnabled()
    {
        if (!PlayerPrefs.HasKey(ScenarioGeneratiorViewerConstants.ENABLE_OBSTACLES_GENERATION))
        {
            EnableObstaclesGeneration(ScenarioGeneratiorViewerConstants.ENABLE_OBSTACLES_GENERATION_DEFAULT_VALUE);
        }

        return bool.Parse(PlayerPrefs.GetString(ScenarioGeneratiorViewerConstants.ENABLE_OBSTACLES_GENERATION));
    }

    public bool IsEnemyGenerationEnabled()
    {
        if (!PlayerPrefs.HasKey(ScenarioGeneratiorViewerConstants.ENABLE_ENEMIES_GENERATION))
        {
            EnableEnemiesGeneration(ScenarioGeneratiorViewerConstants.ENABLE_ENEMIES_GENERATION_DEFAULT_VALUE);
        }

        return bool.Parse(PlayerPrefs.GetString(ScenarioGeneratiorViewerConstants.ENABLE_ENEMIES_GENERATION));
    }

    public bool IsPlayerGenerationEnabled()
    {
        if (!PlayerPrefs.HasKey(ScenarioGeneratiorViewerConstants.ENABLE_PLAYER_GENERATION))
        {
            EnablePlayerGeneration(ScenarioGeneratiorViewerConstants.ENABLE_PLAYER_GENERATION_DEFAULT_VALUE);
        }

        return bool.Parse(PlayerPrefs.GetString(ScenarioGeneratiorViewerConstants.ENABLE_PLAYER_GENERATION));
    }

    public bool IsBossGenerationEnabled()
    {
        if (!PlayerPrefs.HasKey(ScenarioGeneratiorViewerConstants.ENABLE_BOSS_GENERATION))
        {
            EnableBossGeneration(ScenarioGeneratiorViewerConstants.ENABLE_BOSS_GENERATION_DEFAULT_VALUE);
        }

        return bool.Parse(PlayerPrefs.GetString(ScenarioGeneratiorViewerConstants.ENABLE_BOSS_GENERATION));
    }

    public int GetEnemiesAmmount()
    {
        if (!PlayerPrefs.HasKey(ScenarioGeneratiorViewerConstants.ENEMIES_AMOUNT))
        {
            EnemiesAmmount(ScenarioGeneratiorViewerConstants.ENEMIES_AMOUNT_DEFAULT_VALUE);
        }

        return PlayerPrefs.GetInt(ScenarioGeneratiorViewerConstants.ENEMIES_AMOUNT);
    }
}
