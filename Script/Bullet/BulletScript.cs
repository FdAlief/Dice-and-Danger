using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    private HealthEnemy healthEnemy;
    public int damage;

    // Start is called before the first frame update
    void Start()
    {
        healthEnemy = FindObjectOfType<HealthEnemy>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            healthEnemy.TakeDamage(damage);
        }
    }
}
