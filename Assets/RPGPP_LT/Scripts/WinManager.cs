using UnityEngine;
using UnityEngine.SceneManagement; // ��� ����� ����
using UnityEngine.UI; // ��� ������ � UI

public class WinManager : MonoBehaviour
{
    // ��������� ���������� ��� �������� UI ���� ����� ���������
    public GameObject winWindow;

    // ������� ��� ����������� UI ����
    public void ShowWinWindow()
    {
        if (winWindow != null)
        {
            winWindow.SetActive(true); // ���������� ����
        }
    }

    // ������� ��� ������� UI ����
    public void HideWinWindow()
    {
        if (winWindow != null)
        {
            winWindow.SetActive(false); // ������������ ����
        }
    }

    // ������� ��� �������� �� ��������� �����
    public void LoadNextScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex + 1;
        SceneManager.LoadScene(nextSceneIndex);
    }

    // ������� ��� ������������ ������� �����
    public void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    void Update()
    {
        // ���������, ���� ������ � ����� "Fire" �����
        if (GameObject.FindWithTag("Fire") == null)
        {
            ShowWinWindow(); // �������� ����, ����� ��� �����
        }
    }
}
