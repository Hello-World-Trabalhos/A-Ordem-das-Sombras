using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScenarioGenerationViewerConfigSaver
{
    public void SaveValuesFromActualScene()
    {
        Toggle generateObstaclesToggle = GameObject.Find("GenerateObstaclesToggle").GetComponent<Toggle>();
        Toggle generateEnemiesToggle = GameObject.Find("GenerateEnemiesToggle").GetComponent<Toggle>();
        Toggle generatePlayerToggle = GameObject.Find("GeneratePlayerToggle").GetComponent<Toggle>();
        Toggle generateBossToggle = GameObject.Find("GenerateBossToggle").GetComponent<Toggle>();
        Slider enemiesAmmountSlider = GameObject.Find("EnemySlider").GetComponent<Slider>();
        Text enemiesCount = GameObject.Find("EnemiesSliderCount").GetComponent<Text>();

        generateObstaclesToggle.interactable = false;
        generateEnemiesToggle.interactable = false;
        generatePlayerToggle.interactable = false;
        generateBossToggle.interactable = false;
        enemiesAmmountSlider.interactable = false;

        ScenarioGenerationConfig scenarioGenerationConfig = new ScenarioGenerationConfig();

        scenarioGenerationConfig.EnableObstaclesGeneration(generateObstaclesToggle.isOn);
        scenarioGenerationConfig.EnableEnemiesGeneration(generateEnemiesToggle.isOn);
        scenarioGenerationConfig.EnablePlayerGeneration(generatePlayerToggle.isOn);
        scenarioGenerationConfig.EnableBossGeneration(generateBossToggle.isOn);
        scenarioGenerationConfig.EnemiesAmmount(int.Parse(enemiesCount.text.Trim()));
    }
}
