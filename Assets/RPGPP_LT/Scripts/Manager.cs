using UnityEngine;
using TMPro;
using System;

public class Manager : MonoBehaviour
{
    public GameObject uiWindow;
    public float hideTime = 5f;
    public TextMeshProUGUI timerText;
    public float countdownTime = 10f;
    public TextMeshProUGUI scoreText;
    private float score;
    private float countdown;
    private bool isTimerRunning = true;
    private bool isScoreDecreasing = true;

    public event Action OnFireExtinguished;

    void Start()
    {
        countdown = countdownTime;
        score = 3000;
        Invoke("HideUIWindow", hideTime);
        LoadScore();
    }

    void Update()
    {
        if (isTimerRunning && countdown > 0)
        {
            countdown -= Time.deltaTime;
            UpdateTimerText();
        }

        if (isScoreDecreasing)
        {
            DecreaseScore();
        }
    }

    void HideUIWindow()
    {
        if (uiWindow != null)
        {
            uiWindow.SetActive(false);
            Debug.Log("UI ���� ������.");
        }
    }

    void UpdateTimerText()
    {
        if (timerText != null)
        {
            timerText.text = Mathf.Ceil(countdown).ToString();
        }
    }

    void DecreaseScore()
    {
        if (score > 0)
        {
            score -= 50 * Time.deltaTime;
            score = Mathf.Max(score, 0);
        }
        UpdateScoreText();
    }

    void UpdateScoreText()
    {
        if (scoreText != null)
        {
            scoreText.text = "����: " + Mathf.Ceil(score).ToString();
        }
    }

    void SaveScore()
    {
        PlayerPrefs.SetFloat("PlayerScore", score);
        PlayerPrefs.Save();
    }

    void LoadScore()
    {
        score = PlayerPrefs.GetFloat("PlayerScore", 3000);
        UpdateScoreText();
    }

    public void StopTimerAndScore()
    {
        if (!isTimerRunning && !isScoreDecreasing)
        {
            Debug.Log("������ � ���������� ����� ��� �����������.");
            return;
        }

        isTimerRunning = false;
        isScoreDecreasing = false;
        Debug.Log("������ � ���������� ����� �����������");

        SaveLevelTime(countdownTime - countdown);

        // ��������� ���� � PlayerPrefs ��� ��������� �����
        int currentLevel = UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex;
        PlayerPrefs.SetFloat("Level" + currentLevel + "Score", score);
        PlayerPrefs.Save();

        Debug.Log("���������� ���� ���������: " + score);
    }

    void SaveLevelTime(float timeTaken)
    {
        int count = PlayerPrefs.GetInt("LevelTimeCount", 0);
        PlayerPrefs.SetFloat("LevelTime_" + count, timeTaken);
        PlayerPrefs.SetInt("LevelTimeCount", count + 1);
        PlayerPrefs.Save();

        Debug.Log("����� ����������� ������ ���������: " + timeTaken + " ���");
    }

    public void CalculateScore(float timeTaken)
    {
        float calculatedScore = 3000 - timeTaken * 50;
        score = Mathf.Max(calculatedScore, 0); // ����� ���� �� ���� ������ 0
        UpdateScoreText();
        SaveScore(); // ��������� ����� ����
        Debug.Log("���� �����������: " + score);
    }


    public float GetScore()
    {
        return score;
    }

    private void OnEnable()
    {
        OnFireExtinguished += StopTimerAndScore;
    }

    private void OnDisable()
    {
        OnFireExtinguished -= StopTimerAndScore;
    }

    public void FireExtinguishedHandler()
    {
        StopTimerAndScore();
    }
}
