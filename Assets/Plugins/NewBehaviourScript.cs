using UnityEngine;
using System.Runtime.InteropServices;

public class WebGLFileSaver : MonoBehaviour
{
    // ����������� ������� �� .jslib
    [DllImport("__Internal")]
    private static extern void SaveFile(string filename, string data);

    // ����� ��� ������ ����������
    public void SaveDataToFile(string fileName, string data)
    {
#if UNITY_WEBGL && !UNITY_EDITOR
        SaveFile(fileName, data);
#else
        Debug.LogWarning("���������� �������� ������ � WebGL �����.");
#endif
    }
}
