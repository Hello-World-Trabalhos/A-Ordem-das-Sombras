using UnityEngine;

public class Hud : MonoBehaviour
{

    private const byte HUD_CHILD_INDEX = 0;
    private const byte PAUSE_MENU_CHILD_INDEX = 1;
    private GameObject hud;
    private GameObject pauseMenu;

    void Start()
    {
        Transform canvasTransform = GameObject.Find("Canvas").transform;
        hud = canvasTransform.GetChild(HUD_CHILD_INDEX).gameObject;
        pauseMenu = canvasTransform.GetChild(PAUSE_MENU_CHILD_INDEX).gameObject;
    }

    public void LoadMainMenu()
    {
        SceneLoader.LoadMainMenu();
    }

    public void OpenPauseMenu()
    {
        pauseMenu.SetActive(true);
        hud.SetActive(false);
    }

    public void ClosePauseMenu()
    {
        pauseMenu.SetActive(false);
        hud.SetActive(true);
    }
}
