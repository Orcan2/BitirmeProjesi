using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 1000;
    public int currentHealth;
    public MenuManager menuManager;

    public Slider healthSlider; //  Slider 

    void Start()
    {
        currentHealth = maxHealth;
        UpdateHealthBar();
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        UpdateHealthBar();

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        // Oyuncu ölü
        Debug.Log("Player öldü!");

        menuManager.PlayerDie();
        
    }

    void UpdateHealthBar()
    {
        healthSlider.value = currentHealth; // Sağlık değerini guncelle
    }
}
