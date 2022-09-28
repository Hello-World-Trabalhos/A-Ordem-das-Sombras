using UnityEngine;

public class MainMenu : MonoBehaviour
{

    private GameObject mainMenu;
    private GameObject scenarioGenerationPanel;

    void Start()
    {
        mainMenu = GameObject.Find("MainMenu").gameObject;
        scenarioGenerationPanel = GameObject.Find("Canvas").transform.Find("ScenarioGenerationPanel").gameObject;
    }

    public void OpenScenarioGenerationPanel()
    {
        mainMenu.SetActive(false);
        scenarioGenerationPanel.SetActive(true);
    }

    public void CloseScenarioGenerationPanel()
    {
        scenarioGenerationPanel.SetActive(false);
        mainMenu.SetActive(true);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
