using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject uiWindow; // Перетащи сюда UI-окно в инспекторе

    public void PlayGame()
    {
        SceneManager.LoadScene("Level1");
    }

    public void OpenUI()
    {
        if (uiWindow != null)
            uiWindow.SetActive(true);
    }

    public void CloseUI()
    {
        if (uiWindow != null)
            uiWindow.SetActive(false);
    }

    public void OpenUserScene()
    {
        SceneManager.LoadScene("User");
    }

    public void OpenMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
