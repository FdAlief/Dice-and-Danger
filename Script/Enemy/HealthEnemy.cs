using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthEnemy : MonoBehaviour
{
    public float maxHealth = 100f;
    public float currentHealth;
    public Image healthBar;
    public DropItemComponent dropCard;

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
            dropCard.DropItem();
            Destroy(gameObject); // Hancurkan objek saat kesehatan mencapai 0
        }
    }
    public void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount;
    }
}
