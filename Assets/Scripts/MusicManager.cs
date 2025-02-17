using UnityEngine;
using UnityEngine.UI;

public class MusicManager : MonoBehaviour
{
    public static MusicManager instance;
    public AudioSource musicSource;  // Перетащи сюда объект с музыкой
    public Slider volumeSlider;      // Перетащи сюда слайдер громкости

    private const string VolumeKey = "MusicVolume"; // Ключ для сохранения громкости

    void Awake()
    {
        // Синглтон — предотвращаем дублирование объектов при смене сцен
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
        // Загружаем сохранённое значение громкости или устанавливаем 100%
        float savedVolume = PlayerPrefs.GetFloat(VolumeKey, 1f);
        musicSource.volume = savedVolume;

        if (volumeSlider != null)
            volumeSlider.value = savedVolume;

        // Добавляем слушатель для слайдера
        if (volumeSlider != null)
            volumeSlider.onValueChanged.AddListener(SetVolume);
    }

    public void SetVolume(float volume)
    {
        musicSource.volume = volume;
        PlayerPrefs.SetFloat(VolumeKey, volume);  // Сохраняем громкость
        PlayerPrefs.Save();  // Записываем изменения
    }
}
