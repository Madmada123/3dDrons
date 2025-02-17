using UnityEngine;
using TMPro;

public class MaxScoreTracker : MonoBehaviour
{
    public TextMeshProUGUI maxScoreText;

    public TextMeshProUGUI maxScoreTextLevel1;
    public TextMeshProUGUI maxScoreTextLevel2;

    void Start()
    {
        DisplayMaxScores();
    }

    private void DisplayMaxScores()
    {
        // �������� ���� ��� ������� ������
        float level1Score = PlayerPrefs.GetFloat("Level1Score", 0);
        float level2Score = PlayerPrefs.GetFloat("Level2Score", 0);

        // ��������� ����� �� ������
        maxScoreTextLevel1.text = "���� (������� 1): " + Mathf.Ceil(level1Score).ToString();
        maxScoreTextLevel2.text = "���� (������� 2): " + Mathf.Ceil(level2Score).ToString();
    }
}
