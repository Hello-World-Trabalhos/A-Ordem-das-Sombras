using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndGameManager : MonoBehaviour
{

    public GameObject endGamePrefabReference;

    public void ShowEndGamePanel(EndGameOption reason)
    {
        // GameStateManager irá conter métodos estáticos
        GameStateManager gameStateManager = new GameStateManager();
        gameStateManager.PauseGame();
        
        GameObject hudCanvas = GameObject.FindWithTag("Hud").transform.Find("Canvas").gameObject;
        if (hudCanvas != null) {
            hudCanvas.gameObject.SetActive(false);
        }
        
        GameObject endGamePanel = Instantiate(endGamePrefabReference, endGamePrefabReference.transform.position, Quaternion.identity)
            .transform.Find("Canvas").Find("Panel").gameObject;

        endGamePanel.transform.Find("PresentationText").GetComponent<Text>().text = GetTextFromReason(reason);
        endGamePanel.transform.Find("PlayButton").GetComponent<Button>().onClick.AddListener(() =>
        {
            // retirar esses resumes
            gameStateManager.ResumeGame();
            SceneLoader.ReloadCurrentScene();
        });

        endGamePanel.transform.Find("MainMenuButton").GetComponent<Button>().onClick.AddListener(() =>
        {
            // retirar esses resumes
            gameStateManager.ResumeGame();
            SceneLoader.LoadMainMenu();
        });
    }

    private string GetTextFromReason(EndGameOption reason)
    {
        switch (reason)
        {
            case EndGameOption.PLAYER_DEAD:
                return "Você morreu ... :(";
            case EndGameOption.BOSS_KILLED:
                return "Você derrotou o boss e concluiu o cenário!";
        }

        return "";
    }
}
