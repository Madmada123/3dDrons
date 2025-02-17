using UnityEngine;
using System.Runtime.InteropServices;

public class WebGLFileSaver : MonoBehaviour
{
    // Импортируем функцию из .jslib
    [DllImport("__Internal")]
    private static extern void SaveFile(string filename, string data);

    // Метод для вызова сохранения
    public void SaveDataToFile(string fileName, string data)
    {
#if UNITY_WEBGL && !UNITY_EDITOR
        SaveFile(fileName, data);
#else
        Debug.LogWarning("Сохранение работает только в WebGL билде.");
#endif
    }
}
