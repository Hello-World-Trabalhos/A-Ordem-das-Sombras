using UnityEngine;

public class Hud : MonoBehaviour
{
    private readonly GameStateManager gameStateManager = new GameStateManager();
    private GameObject hud;
    private GameObject pauseMenu;

    void Start()
    {
        Transform canvasTransform = GameObject.Find("Canvas").transform;
        hud = canvasTransform.Find("Hud").gameObject;
        pauseMenu = canvasTransform.Find("PauseMenu").gameObject;
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
}
