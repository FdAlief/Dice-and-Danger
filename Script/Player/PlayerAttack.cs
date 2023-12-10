using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private HealthEnemy healthEnemy;
    public int damage;

    // Start is called before the first frame update
    void Start()
    {
        healthEnemy = FindObjectOfType<HealthEnemy>();
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (healthEnemy != null)
            {
                if (Input.GetMouseButtonDown(1))
                {
                    healthEnemy.TakeDamage(damage);
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (healthEnemy != null)
            {
                if (Input.GetMouseButtonDown(1))
                {
                    healthEnemy.TakeDamage(damage);
                }
            }
        }
    }
}
