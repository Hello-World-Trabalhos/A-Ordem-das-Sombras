using UnityEngine;
using UnityEngine.UI;

public class Hud : MonoBehaviour
{
    private readonly AudioConfig audioConfig = new AudioConfig();
    private readonly GameStateManager gameStateManager = new GameStateManager();
    private GameObject hud;
    private GameObject pauseMenu;
    private GameObject initialMenu;
    private GameObject settingsPanel;
    private AudioManager audioManager;

    void Start()
    {
        Transform canvasTransform = GameObject.Find("Canvas").transform;
        hud = canvasTransform.Find("Hud").gameObject;
        pauseMenu = canvasTransform.Find("PauseMenu").gameObject;
        initialMenu = pauseMenu.transform.Find("InitialMenu").gameObject;
        settingsPanel = pauseMenu.transform.Find("SettingsPanel").gameObject;
        audioManager = GameObject.Find("AudioManager").GetComponent<AudioManager>();
    }

    public void LoadMainMenu()
    {
        gameStateManager.ResumeGame();
        SceneLoader.LoadMainMenu();
    }

    public void OpenPauseMenu()
    {
        gameStateManager.PauseGame();
        pauseMenu.SetActive(true);
        hud.SetActive(false);
    }

    public void ClosePauseMenu()
    {
        gameStateManager.ResumeGame();
        pauseMenu.SetActive(false);
        hud.SetActive(true);
    }

    public void ToogleConfigPanel()
    {
        initialMenu.SetActive(!initialMenu.activeSelf);
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
}
