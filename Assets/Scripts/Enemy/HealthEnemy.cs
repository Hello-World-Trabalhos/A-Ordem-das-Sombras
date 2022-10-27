using UnityEngine;
using UnityEngine.UI;

public class HealthEnemy : MonoBehaviour
{
    [Header("Health")]
    public int currentHealth;
    public int maxHealth;
    [SerializeField] private Caracter caracter;


    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        if (currentHealth <= 0)
            return;

        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            currentHealth = 0;
            caracter.Died();
        }

    }

}
