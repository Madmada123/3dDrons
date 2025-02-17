using UnityEngine;

public class DestroyOnFoamTouch : MonoBehaviour
{
    public string foamTag = "Foam"; // Тег, с которым объект должен столкнуться для уничтожения

    void OnCollisionEnter(Collision collision)
    {
        // Проверяем, что объект столкнулся с объектом, имеющим тег "Foam"
        if (collision.gameObject.CompareTag(foamTag))
        {
            // Уничтожаем текущий объект
            Destroy(gameObject);
            Debug.Log("Объект уничтожен при столкновении с Foam!");
        }
    }

    // Если используется Trigger, то вместо OnCollisionEnter используйте OnTriggerEnter
    void OnTriggerEnter(Collider other)
    {
        // Проверяем, что объект столкнулся с объектом, имеющим тег "Foam"
        if (other.CompareTag(foamTag))
        {
            // Уничтожаем текущий объект
            Destroy(gameObject);
            Debug.Log("Объект уничтожен при столкновении с Foam!");
        }
    }
}
