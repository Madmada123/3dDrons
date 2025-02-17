using UnityEngine;

public class DestroyOnFoamTouch : MonoBehaviour
{
    public string foamTag = "Foam"; // ���, � ������� ������ ������ ����������� ��� �����������

    void OnCollisionEnter(Collision collision)
    {
        // ���������, ��� ������ ���������� � ��������, ������� ��� "Foam"
        if (collision.gameObject.CompareTag(foamTag))
        {
            // ���������� ������� ������
            Destroy(gameObject);
            Debug.Log("������ ��������� ��� ������������ � Foam!");
        }
    }

    // ���� ������������ Trigger, �� ������ OnCollisionEnter ����������� OnTriggerEnter
    void OnTriggerEnter(Collider other)
    {
        // ���������, ��� ������ ���������� � ��������, ������� ��� "Foam"
        if (other.CompareTag(foamTag))
        {
            // ���������� ������� ������
            Destroy(gameObject);
            Debug.Log("������ ��������� ��� ������������ � Foam!");
        }
    }
}
