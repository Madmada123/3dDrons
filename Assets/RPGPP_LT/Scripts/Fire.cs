using UnityEngine;

public class Fire : MonoBehaviour
{
    public GameObject fireEffectPrefab; // Префаб огня, который можно установить через инспектор
    private ParticleSystem fireParticleSystem;
    private bool isExtinguished = false;
    private float destructionTime; // Время уничтожения огня

    void Start()
    {
        if (fireEffectPrefab != null)
        {
            // Создаем эффекты огня из префаба
            GameObject fireEffect = Instantiate(fireEffectPrefab, transform.position, Quaternion.identity);
            fireEffect.transform.parent = transform; // Привязываем к объекту огня
            fireParticleSystem = fireEffect.GetComponent<ParticleSystem>(); // Получаем компонент Particle System
        }
        else
        {
            Debug.LogError("Префаб огня не установлен!");
        }
    }

    // Метод для тушения огня
    public void ExtinguishFire()
    {
        if (!isExtinguished && fireParticleSystem != null)
        {
            fireParticleSystem.Stop();
            isExtinguished = true;
            destructionTime = Time.time; // Сохраняем время потушения огня
            Debug.Log("Огонь потушен!");
        }
    }

    // Метод для получения времени потушения
    public float GetDestructionTime()
    {
        return destructionTime; // Возвращаем время потушения
    }
}
