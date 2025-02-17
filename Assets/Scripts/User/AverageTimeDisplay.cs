using UnityEngine;
using TMPro;
using System.Collections.Generic;
using System.Linq;

public class AverageTimeDisplay : MonoBehaviour
{
    // UI ������� ��� ����������� �������� �������
    public TextMeshProUGUI averageTimeText;

    void Start()
    {
        DisplayAverageTime();
    }

    // ����� ��� �������� ���� ���������� ������
    private List<float> LoadLevelTimes()
    {
        List<float> times = new List<float>();
        int count = PlayerPrefs.GetInt("LevelTimeCount", 0);

        for (int i = 0; i < count; i++)
        {
            times.Add(PlayerPrefs.GetFloat("LevelTime_" + i, 0f));
        }

        return times;
    }

    // ����� ��� ���������� �������� ������� � ���������� ������
    private void DisplayAverageTime()
    {
        List<float> times = LoadLevelTimes();

        if (times.Count > 0)
        {
            float averageTime = times.Average();
            averageTimeText.text = "������� �����: " + averageTime.ToString("F2") + " ���";
        }
        else
        {
            averageTimeText.text = "��� ������";
        }
    }
}
