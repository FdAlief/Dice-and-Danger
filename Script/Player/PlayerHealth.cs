using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public float maxHealth = 100f;
    public float currentHealth;
    public Image healthBar;
    public GameObject GameOverPanel;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        healthBar.fillAmount = currentHealth / maxHealth; // Memperbarui tampilan Health Bar
        if (currentHealth <= 0)
        {
            Destroy(gameObject); // Hancurkan objek saat kesehatan mencapai 0
            GameOverPanel.SetActive(true);
            Time.timeScale = 0;
        }
    }

    public void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount;
    }

    public void AddHealth(int addAmount)
    {
        currentHealth += addAmount;
    }
}
