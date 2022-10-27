using UnityEngine;
using UnityEngine.UI;

public class HealthEnemy : MonoBehaviour
{
    [Header("Health")]
    public int currentHealth;
    public int maxHealth;
    [SerializeField] private Caracter caracter;
    [SerializeField] public Slider hpSliper;


    void Start()
    {
        currentHealth = maxHealth;

        if (hpSliper != null)
        {
            hpSliper.maxValue = maxHealth;
            hpSliper.value = hpSliper.maxValue;
        }
    }

    public void TakeDamage(int damage)
    {
        if (currentHealth <= 0)
            return;

        currentHealth -= damage;

        if (hpSliper != null)
            hpSliper.value -= damage;

        if (currentHealth <= 0)
        {
            currentHealth = 0;
            caracter.Died();
        }

    }

}
