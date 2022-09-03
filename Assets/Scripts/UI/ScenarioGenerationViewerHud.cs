using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScenarioGenerationViewerHud : MonoBehaviour
{
    private Button pauseButton;
    private Button scenarioGeneratorButton;
    private GameObject pausePanel;
    private TouchActions touchActions;

    void Start()
    {
        pauseButton = gameObject.transform.Find("PauseButton").GetComponent<Button>();
        pausePanel = gameObject.transform.Find("PausePanel").gameObject;
        touchActions = GameObject.Find("TouchActions").GetComponent<TouchActions>();
        scenarioGeneratorButton = GameObject.Find("ScenarioGeneratorButton").GetComponent<Button>();
    }

    public void PauseGame()
    {
        // Lembrar de adicionar pausa de tempo aqui
        pauseButton.gameObject.SetActive(false);
        scenarioGeneratorButton.gameObject.SetActive(false);
        touchActions.gameObject.SetActive(false);
        pausePanel.SetActive(true);
    }

    public void ResumeGame()
    {
        pauseButton.gameObject.SetActive(true);
        scenarioGeneratorButton.gameObject.SetActive(true);
        touchActions.gameObject.SetActive(true);
        pausePanel.SetActive(false);
    }

    public void GenerateNewScenario()
    {
        SceneLoader.ReloadCurrentScene();
    }

    public void LoadMainMenu()
    {
        SceneLoader.LoadMainMenu();
    }
}
