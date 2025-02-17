using UnityEngine;

public class FireExtinguisher : MonoBehaviour
{
    public string fireTag = "Fire";
    public Manager gameManager;
   

    void Start()
    {
        if (gameManager == null)
        {
            gameManager = FindObjectOfType<Manager>();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Collision detected with: " + other.gameObject.name);

        if (other.CompareTag(fireTag))
        {
            Debug.Log("Collided with fire");

            Fire fire = other.GetComponent<Fire>();

            if (fire != null)
            {
                Debug.Log("Fire component found");

                fire.ExtinguishFire();

                float timeTaken = fire.GetDestructionTime();
                Debug.Log("Time taken to extinguish fire: " + timeTaken);

                gameManager.CalculateScore(timeTaken);
                gameManager.FireExtinguishedHandler(); // явно вызываем метод дл€ остановки

                Destroy(other.gameObject);

                Debug.Log("Fire extinguished, score calculated!");
            }
            else
            {
                Debug.Log("Fire component not found!");
            }
        }
    }
}
