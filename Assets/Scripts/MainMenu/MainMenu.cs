using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{

    private readonly AudioConfig audioConfig = new AudioConfig();
    private GameObject mainMenu;
    private GameObject scenarioGenerationPanel;
    private GameObject aboutPanel;
    private GameObject settingsPanel;
    private AudioManager audioManager;

    void Start()
    {
        GameObject canvas = GameObject.Find("Canvas").gameObject;

        mainMenu = canvas.transform.Find("MainMenu").gameObject;
        scenarioGenerationPanel = canvas.transform.Find("ScenarioGenerationPanel").gameObject;
        aboutPanel = canvas.transform.Find("AboutPanel").gameObject;
        settingsPanel = canvas.transform.Find("SettingsPanel").gameObject;
        audioManager = GameObject.Find("AudioManager").GetComponent<AudioManager>();
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
        
        audioConfig.EnableMusic(musicToggle.isOn);
        audioConfig.SetMusicVolume(musicVolume.value);
        audioManager.ConfigureAudioBasedOnSavedConfigValues();
    }

    private void SetupConfigs()
    {
        Toggle musicToggle = settingsPanel.transform.Find("MusicToggle").transform.Find("Toggle").GetComponent<Toggle>();
        Slider musicVolume = settingsPanel.transform.Find("MusicVolumeSlider").transform.Find("Slider").GetComponent<Slider>();
        
        musicToggle.isOn = audioConfig.IsMusicEnabled();
        musicVolume.value = audioConfig.GetMusicVolume();
        audioManager.ConfigureAudioBasedOnSavedConfigValues();
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
