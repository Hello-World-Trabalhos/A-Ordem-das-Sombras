using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{

    private GameObject mainMenu;
    private GameObject scenarioGenerationPanel;
    private GameObject aboutPanel;
    private GameObject settingsPanel;

    void Start()
    {
        GameObject canvas = GameObject.Find("Canvas").gameObject;

        mainMenu = canvas.transform.Find("MainMenu").gameObject;
        scenarioGenerationPanel = canvas.transform.Find("ScenarioGenerationPanel").gameObject;
        aboutPanel = canvas.transform.Find("AboutPanel").gameObject;
        settingsPanel = canvas.transform.Find("SettingsPanel").gameObject;
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

    public void ToggleSettingsPanel()
    {
        mainMenu.SetActive(!mainMenu.activeSelf);
        settingsPanel.SetActive(!settingsPanel.activeSelf);

        if (settingsPanel.activeSelf)
        {
            SetupConfigs();
        }
    }

    public void SaveConfigs()
    {
        Toggle musicToggle = settingsPanel.transform.Find("MusicToggle").transform.Find("Toggle").GetComponent<Toggle>();
        Slider musicVolume = settingsPanel.transform.Find("MusicVolumeSlider").transform.Find("Slider").GetComponent<Slider>();
        // chamar o AudioConfigSaver (instância)
        // chamar o método dele para salvar configuracoes
    }

    private void SetupConfigs()
    {
        Toggle musicToggle = settingsPanel.transform.Find("MusicToggle").transform.Find("Toggle").GetComponent<Toggle>();
        Slider musicVolume = settingsPanel.transform.Find("MusicVolumeSlider").transform.Find("Slider").GetComponent<Slider>();
        // buscar os valores do AudioConfig
        // atribuir aos itens referenciados nas variáveis acima
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
