using UnityEngine;

public class BugMovement : MonoBehaviour
{
    public float speed = 2f;         // �������� ��������
    public float moveDistance = 5f;  // ��������� �������� � ���� �������

    private Vector3 startPosition;
    private int direction = 1;  // 1 - �����, -1 - �����

    void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        transform.Translate(Vector3.forward * speed * direction * Time.deltaTime);

        if (Vector3.Distance(startPosition, transform.position) >= moveDistance)
        {
            direction *= -1; // ������ �����������
            transform.Rotate(0f, 180f, 0f); // ������������ ����
        }
    }
}
