using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public Animator animator;
    private PlayerHealth playerHealth;
    public int damage;

    private void Start()
    {
        playerHealth = FindObjectOfType<PlayerHealth>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            animator.SetBool("isAttack", true);
            Invoke("damagePlayer", 1);
        }
    }

    void damagePlayer()
    {
        playerHealth.TakeDamage(damage);
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            animator.SetBool("isAttack", false);
        }
    }
}