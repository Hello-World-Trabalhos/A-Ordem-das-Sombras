using UnityEngine;

public class MainMenu : MonoBehaviour
{

    private GameObject mainMenu;
    private GameObject scenarioGenerationPanel;
    private GameObject aboutPanel;

    void Start()
    {
        GameObject canvas = GameObject.Find("Canvas").gameObject;

        mainMenu = canvas.transform.Find("MainMenu").gameObject;
        scenarioGenerationPanel = canvas.transform.Find("ScenarioGenerationPanel").gameObject;
        aboutPanel = canvas.transform.Find("AboutPanel").gameObject;
    }

    public void ToggleScenarioGenerationPanel()
    {
        mainMenu.SetActive(!mainMenu.activeSelf);
        scenarioGenerationPanel.SetActive(!scenarioGenerationPanel.activeSelf);
    }

    public void ToggleAboutPanel()
    {
        mainMenu.SetActive(!mainMenu.activeSelf);
        aboutPanel.SetActive(!aboutPanel.activeSelf);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
