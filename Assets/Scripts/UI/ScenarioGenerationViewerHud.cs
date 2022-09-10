using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScenarioGenerationViewerHud : MonoBehaviour
{
    private Button pauseButton;
    private Button scenarioGeneratorButton;
    private Button scenarioGenerationSettings;
    private GameObject pausePanel;
    private GameObject scenarioGenerationConfigPanel;
    private TouchActions touchActions;

    void Start()
    {
        pauseButton = gameObject.transform.Find("PauseButton").GetComponent<Button>();
        scenarioGeneratorButton = GameObject.Find("ScenarioGeneratorButton").GetComponent<Button>();
        scenarioGenerationSettings = GameObject.Find("ScenarioGenerationSettingsButton").GetComponent<Button>();
        pausePanel = gameObject.transform.Find("PausePanel").gameObject;
        touchActions = GameObject.Find("TouchActions").GetComponent<TouchActions>();
        scenarioGenerationConfigPanel = gameObject.transform.Find("ScenarioGenerationConfigPanel").gameObject;
    }

    public void PauseGame()
    {
        // Lembrar de adicionar pausa de tempo aqui
        pauseButton.gameObject.SetActive(false);
        scenarioGeneratorButton.gameObject.SetActive(false);
        scenarioGenerationSettings.gameObject.SetActive(false);
        touchActions.gameObject.SetActive(false);
        pausePanel.SetActive(true);
    }

    public void ResumeGame()
    {
        // Lembrar de remover pausa de tempo aqui
        pauseButton.gameObject.SetActive(true);
        scenarioGeneratorButton.gameObject.SetActive(true);
        scenarioGenerationSettings.gameObject.SetActive(true);
        touchActions.gameObject.SetActive(true);
        pausePanel.SetActive(false);
        scenarioGenerationConfigPanel.SetActive(false);
    }

    public void OpenConfigPanel()
    {
        // Lembrar de adicionar pausa de tempo aqui
        pauseButton.gameObject.SetActive(false);
        scenarioGeneratorButton.gameObject.SetActive(false);
        scenarioGenerationSettings.gameObject.SetActive(false);
        touchActions.gameObject.SetActive(false);
        scenarioGenerationConfigPanel.SetActive(true);
        SetConfigValuesFromPreviousSavedData();
    }

    private void SetConfigValuesFromPreviousSavedData()
    {
        Toggle generateObstaclesToggle = GameObject.Find("GenerateObstaclesToggle").GetComponent<Toggle>();
        Toggle generateEnemiesToggle = GameObject.Find("GenerateEnemiesToggle").GetComponent<Toggle>();
        Toggle generatePlayerToggle = GameObject.Find("GeneratePlayerToggle").GetComponent<Toggle>();
        Toggle generateBossToggle = GameObject.Find("GenerateBossToggle").GetComponent<Toggle>();
        Slider enemiesAmmountSlider = GameObject.Find("EnemySlider").GetComponent<Slider>();
        Text enemiesCount = GameObject.Find("EnemiesSliderCount").GetComponent<Text>();

        ScenarioGenerationConfig scenarioGenerationConfig = new ScenarioGenerationConfig();

        generateObstaclesToggle.isOn = scenarioGenerationConfig.IsObstacleGenerationEnabled();
        generateEnemiesToggle.isOn = scenarioGenerationConfig.IsEnemyGenerationEnabled();
        generatePlayerToggle.isOn = scenarioGenerationConfig.IsPlayerGenerationEnabled();
        generateBossToggle.isOn = scenarioGenerationConfig.IsBossGenerationEnabled();
        enemiesAmmountSlider.value = scenarioGenerationConfig.GetEnemiesAmmount();
        enemiesCount.text = scenarioGenerationConfig.GetEnemiesAmmount().ToString();
    }

    public void GenerateNewScenario()
    {
        SceneLoader.ReloadCurrentScene();
    }

    public void GenerateNewScenarioSavingConfigurations()
    {
        GameObject.Find("ScenarioGeneratorSavingChangesButton").GetComponent<Button>().interactable = false;

        new ActualScenarioConfigSaver().SaveValuesFromActualScene();
        GenerateNewScenario();
    }

    public void LoadMainMenu()
    {
        SceneLoader.LoadMainMenu();
    }
}
