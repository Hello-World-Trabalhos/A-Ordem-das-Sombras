using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewScenarioConfigSaver
{
    public void SaveValuesFromActualScene()
    {
        Toggle generateObstaclesToggle = GameObject.Find("GenerateObstaclesToggle").GetComponent<Toggle>();
        Toggle generateEnemiesToggle = GameObject.Find("GenerateEnemiesToggle").GetComponent<Toggle>();
        Toggle generatePlayerToggle = GameObject.Find("GeneratePlayerToggle").GetComponent<Toggle>();
        Toggle generateBossToggle = GameObject.Find("GenerateBossToggle").GetComponent<Toggle>();
        Toggle scenarioBackgroundToggle = GameObject.Find("ScenarioBackgroundToggle").GetComponent<Toggle>();
        Slider enemiesAmmountSlider = GameObject.Find("EnemySlider").GetComponent<Slider>();
        Text enemiesCount = GameObject.Find("EnemiesSliderCount").GetComponent<Text>();

        generateObstaclesToggle.interactable = false;
        generateEnemiesToggle.interactable = false;
        generatePlayerToggle.interactable = false;
        generateBossToggle.interactable = false;
        scenarioBackgroundToggle.interactable = false;
        enemiesAmmountSlider.interactable = false;

        PlayerPrefsSaver playerPrefsSaver = new PlayerPrefsSaver();

        playerPrefsSaver.EnableObstaclesGeneration(generateObstaclesToggle.isOn);
        playerPrefsSaver.EnableEnemiesGeneration(generateEnemiesToggle.isOn);
        playerPrefsSaver.EnablePlayerGeneration(generatePlayerToggle.isOn);
        playerPrefsSaver.EnableBossGeneration(generateBossToggle.isOn);
        playerPrefsSaver.EnableLightBackground(scenarioBackgroundToggle.isOn);
        playerPrefsSaver.EnemiesAmmount(int.Parse(enemiesCount.text.Trim()));
    }
}
