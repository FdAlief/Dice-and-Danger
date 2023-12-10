using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChase : MonoBehaviour
{
    public float moveSpeed; // Kecepatan pergerakan musuh
    public float rotationSpeed; // Kecepatan rotasi musuh
    public float detectionRange; // Jarak deteksi musuh terhadap pemain
    public float stoppingDistance ; // Jarak di mana musuh berhenti mengejar pemain
    public Animator animator;

    private Transform player; // Transform pemain

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        // Memeriksa apakah pemain dalam jangkauan deteksi
        if (Vector3.Distance(transform.position, player.position) < detectionRange)
        {
            ChasePlayer();
        }
        else if (Vector3.Distance(transform.position, player.position) > detectionRange)
        {
            animator.SetBool("isWalking", false);
            animator.SetBool("isIdle", true);
        }
    }

    void ChasePlayer()
    {
        // Menyimpan arah pemain
        Vector3 moveDirection = (player.position - transform.position).normalized;

        // Menghitung rotasi ke arah pemain
        Quaternion toRotation = Quaternion.LookRotation(moveDirection, Vector3.up);
        transform.rotation = Quaternion.Slerp(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);

        // Jarak antara musuh dan pemain
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        // Jika jarak masih lebih besar dari stoppingDistance, terus mengejar pemain
        if (distanceToPlayer > stoppingDistance)
        {
            // Menggerakkan musuh ke arah pemain
            transform.Translate(moveDirection * moveSpeed * Time.deltaTime, Space.World);
        }

        animator.SetBool("isWalking", true);
        animator.SetBool("isIdle", false);
    }
}
