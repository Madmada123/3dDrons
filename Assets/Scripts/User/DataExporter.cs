using UnityEngine;
using TMPro;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

public class DataExporter : MonoBehaviour
{
    public TextMeshProUGUI averageTimeText;
    public TextMeshProUGUI maxScoreText;
    /*
#if UNITY_WEBGL
    [DllImport("__Internal")]
    private static extern void SaveFile(string fileName, string data);
#endif
    */
    void Start()
    {
        DisplayResults();
    }

    // ����� ��� �������� ����� ��� ���� �������
    private List<float> LoadLevelTimes()
    {
        List<float> times = new List<float>
        {
            PlayerPrefs.GetFloat("LevelTime_0", 0f),
            PlayerPrefs.GetFloat("LevelTime_1", 0f)
        };

        return times;
    }

    // ����� ��� �������� ������������ �����
    private float LoadMaxScore()
    {
        return PlayerPrefs.GetFloat("MaxScore", 0f);
    }

    // ����� ��� ����������� ����������� �� ������
    private void DisplayResults()
    {
        List<float> times = LoadLevelTimes();
        float maxScore = LoadMaxScore();

        if (times.Count == 2)
        {
            float averageTime = times.Average();

            averageTimeText.text = $"������� �����: {averageTime:F2} ���";
            maxScoreText.text = $"������������ ����: {maxScore:F0}";

            Debug.Log("������� �����: " + averageTime);
            Debug.Log("������������ ����: " + maxScore);
        }
        else
        {
            averageTimeText.text = "��� ������ � �������";
            maxScoreText.text = "��� ������ � �����";
        }
    }

    /*
    // ����� ��� �������� ������ � CSV
    public void ExportToExcel()
    {
        List<float> times = LoadLevelTimes();
        List<float> scores = new List<float>
        {
            PlayerPrefs.GetFloat("Level1Score", 0),
            PlayerPrefs.GetFloat("Level2Score", 0)
        };

        if (times.Count >= 2 && scores.Count >= 2)
        {
            StringBuilder csvData = new StringBuilder();
            csvData.AppendLine("�������;����� (���);����");

            csvData.AppendLine($"������� 1;{times[0]:F2};{scores[0]:F0}");
            csvData.AppendLine($"������� 2;{times[1]:F2};{scores[1]:F0}");

            float averageTime = times.Average();
            float averageScore = scores.Average();
            csvData.AppendLine($"������� ��������;{averageTime:F2};{averageScore:F0}");

#if UNITY_WEBGL
            // ����� JavaScript-������� ��� ���������� ����� � WebGL
            SaveFile("LevelResults.csv", csvData.ToString());
#else
            // ��������� ���������� ��� Windows/Mac
            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string filePath = System.IO.Path.Combine(desktopPath, "LevelResults.csv");

            System.IO.File.WriteAllText(filePath, csvData.ToString(), Encoding.GetEncoding("windows-1251"));
            Debug.Log("������ �������������� �� ������� ����: " + filePath);
#endif
        }
        else
        {
            Debug.LogWarning("��� ������ ��� ��������.");
        }
    } */
}
