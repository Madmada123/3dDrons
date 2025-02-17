using UnityEngine;

public class FireExtinguisherDrone : MonoBehaviour
{
    public GameObject foamPrefab;  // ������ ����������� ����
    public Transform firePoint;    // ����� ������ ���� (�����)
    public float shootForce = 10f; // �������� ����
    public float fireRate = 0.1f;  // ������� ������� ���� (��� ������, ��� �������)

    private bool isExtinguishing = false;
    private float nextFireTime = 0f;

    void Update()
    {
        if (Input.GetKey(KeyCode.Space)) // ���� ������ Space - ������������ ��������
        {
            isExtinguishing = true;
            if (Time.time >= nextFireTime)
            {
                ShootFoam();
                nextFireTime = Time.time + fireRate;
            }
        }
        else
        {
            isExtinguishing = false;
        }
    }

    void ShootFoam()
    {
        GameObject foam = Instantiate(foamPrefab, firePoint.position, firePoint.rotation);
        Rigidbody rb = foam.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.velocity = firePoint.forward * shootForce; // ���� ��������� � ����������� �����
        }
        Destroy(foam, 2f); // ������� ���� ����� 2 �������
    }
}
