using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    private const byte MAIN_MENU_SCENE_INDEX = 0;

    public static void LoadMainMenu()
    {
        LoadScene(MAIN_MENU_SCENE_INDEX);
    }

    public static void LoadScene(int index)
    {
        // Implementar telas de loading e tal, aqui, nesse local
        // o carregamento de cenarios já está assincrono, apenas melhorar a lógica
        SceneManager.LoadSceneAsync(index);
    }
}
