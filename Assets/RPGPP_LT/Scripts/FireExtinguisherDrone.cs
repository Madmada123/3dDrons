using UnityEngine;

public class FireExtinguisherDrone : MonoBehaviour
{
    public GameObject foamPrefab;  // Префаб огнетушащей пены
    public Transform firePoint;    // Точка выхода пены (сопло)
    public float shootForce = 10f; // Скорость пены
    public float fireRate = 0.1f;  // Частота выпуска пены (чем меньше, тем быстрее)

    private bool isExtinguishing = false;
    private float nextFireTime = 0f;

    void Update()
    {
        if (Input.GetKey(KeyCode.Space)) // Пока держим Space - огнетушитель работает
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
            rb.velocity = firePoint.forward * shootForce; // Пена двигается в направлении сопла
        }
        Destroy(foam, 2f); // Удаляем пену через 2 секунды
    }
}
