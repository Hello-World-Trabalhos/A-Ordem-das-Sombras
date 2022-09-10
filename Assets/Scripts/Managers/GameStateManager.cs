using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateManager
{
    public void PauseGame()
    {
        Time.timeScale = 0;
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
    }
}
