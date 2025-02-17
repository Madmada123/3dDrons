using UnityEngine;
using UnityEngine.UI;

public class MusicManager : MonoBehaviour
{
    public static MusicManager instance;
    public AudioSource musicSource;  // �������� ���� ������ � �������
    public Slider volumeSlider;      // �������� ���� ������� ���������

    private const string VolumeKey = "MusicVolume"; // ���� ��� ���������� ���������

    void Awake()
    {
        // �������� � ������������� ������������ �������� ��� ����� ����
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }

    void Start()
    {
        // ��������� ���������� �������� ��������� ��� ������������� 100%
        float savedVolume = PlayerPrefs.GetFloat(VolumeKey, 1f);
        musicSource.volume = savedVolume;

        if (volumeSlider != null)
            volumeSlider.value = savedVolume;

        // ��������� ��������� ��� ��������
        if (volumeSlider != null)
            volumeSlider.onValueChanged.AddListener(SetVolume);
    }

    public void SetVolume(float volume)
    {
        musicSource.volume = volume;
        PlayerPrefs.SetFloat(VolumeKey, volume);  // ��������� ���������
        PlayerPrefs.Save();  // ���������� ���������
    }
}
