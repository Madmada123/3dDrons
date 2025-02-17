using UnityEngine;

public class Fire : MonoBehaviour
{
    public GameObject fireEffectPrefab; // ������ ����, ������� ����� ���������� ����� ���������
    private ParticleSystem fireParticleSystem;
    private bool isExtinguished = false;
    private float destructionTime; // ����� ����������� ����

    void Start()
    {
        if (fireEffectPrefab != null)
        {
            // ������� ������� ���� �� �������
            GameObject fireEffect = Instantiate(fireEffectPrefab, transform.position, Quaternion.identity);
            fireEffect.transform.parent = transform; // ����������� � ������� ����
            fireParticleSystem = fireEffect.GetComponent<ParticleSystem>(); // �������� ��������� Particle System
        }
        else
        {
            Debug.LogError("������ ���� �� ����������!");
        }
    }

    // ����� ��� ������� ����
    public void ExtinguishFire()
    {
        if (!isExtinguished && fireParticleSystem != null)
        {
            fireParticleSystem.Stop();
            isExtinguished = true;
            destructionTime = Time.time; // ��������� ����� ��������� ����
            Debug.Log("����� �������!");
        }
    }

    // ����� ��� ��������� ������� ���������
    public float GetDestructionTime()
    {
        return destructionTime; // ���������� ����� ���������
    }
}
