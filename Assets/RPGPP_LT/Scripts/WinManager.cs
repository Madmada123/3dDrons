using UnityEngine;
using UnityEngine.SceneManagement; // Для смены сцен
using UnityEngine.UI; // Для работы с UI

public class WinManager : MonoBehaviour
{
    // Публичная переменная для привязки UI окна через инспектор
    public GameObject winWindow;

    // Функция для отображения UI окна
    public void ShowWinWindow()
    {
        if (winWindow != null)
        {
            winWindow.SetActive(true); // Активируем окно
        }
    }

    // Функция для скрытия UI окна
    public void HideWinWindow()
    {
        if (winWindow != null)
        {
            winWindow.SetActive(false); // Деактивируем окно
        }
    }

    // Функция для перехода на следующую сцену
    public void LoadNextScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex + 1;
        SceneManager.LoadScene(nextSceneIndex);
    }

    // Функция для перезагрузки текущей сцены
    public void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    void Update()
    {
        // Проверяем, если объект с тегом "Fire" исчез
        if (GameObject.FindWithTag("Fire") == null)
        {
            ShowWinWindow(); // Показать окно, когда тэг исчез
        }
    }
}
