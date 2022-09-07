using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
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

    private PlayerPrefsSaver playerPrefsSaver = new PlayerPrefsSaver();

    void Start()
    {
        pauseButton = gameObject.transform.Find("PauseButton").GetComponent<Button>();
        scenarioGeneratorButton = GameObject.Find("ScenarioGeneratorButton").GetComponent<Button>();
        scenarioGenerationSettings = GameObject.Find("ScenarioGenerationSettingsButton").GetComponent<Button>();
        pausePanel = gameObject.transform.Find("PausePanel").gameObject;
        touchActions = GameObject.Find("TouchActions").GetComponent<TouchActions>();
        scenarioGenerationConfigPanel = gameObject.transform.Find("ScenarioGenerationConfigPanel").gameObject;

        SettingsButtonSprites settingsButtonSprites = gameObject.GetComponent<SettingsButtonSprites>();
        Image scenarioGenerationSettingsImage = scenarioGenerationSettings.GetComponent<Image>();

        if (playerPrefsSaver.IsLightbackgroundEnabled())
        {
            scenarioGenerationSettingsImage.sprite = settingsButtonSprites.GetBlackButtonVariation();
        }
        else
        {
            scenarioGenerationSettingsImage.sprite = settingsButtonSprites.GetWhiteButtonVariation();
        }
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
        pauseButton.gameObject.SetActive(true);
        scenarioGeneratorButton.gameObject.SetActive(true);
        scenarioGenerationSettings.gameObject.SetActive(true);
        touchActions.gameObject.SetActive(true);
        pausePanel.SetActive(false);
        scenarioGenerationConfigPanel.SetActive(false);
    }

    public void OpenConfigPanel() {
        pauseButton.gameObject.SetActive(false);
        scenarioGeneratorButton.gameObject.SetActive(false);
        scenarioGenerationSettings.gameObject.SetActive(false);
        touchActions.gameObject.SetActive(false);
        scenarioGenerationConfigPanel.SetActive(true);
    }

    public void GenerateNewScenario()
    {
        SceneLoader.ReloadCurrentScene();
    }

    public void GenerateNewScenarioSavingConfigurations()
    {
        GameObject.Find("ScenarioGeneratorSavingChangesButton").GetComponent<Button>().interactable = false;

        Parallel.Invoke(() => {
            new NewScenarioConfigSaver().SaveValuesFromActualScene();
            GenerateNewScenario();
        });
    }

    public void LoadMainMenu()
    {
        SceneLoader.LoadMainMenu();
    }
}
