using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Movement")]
    public float movementSpeed;
    public CharacterController characterController;
    private bool isMove = true;

    [Header("Animation")]
    public Animator animator;
    public GameObject animAttack;
    private float durationAttack = 2f;
    public GameObject animIdle;
    public GameObject animPistol;

    [Header("Rotasi")]
    public float rotationSpeed;
    public float rotationSpeed2;

    [Header("Gravitasi")]
    public float gravity;
    Vector3 velocity;
    public Transform groundCheck;
    public float groundDistance;
    public LayerMask groundMask;
    bool isGrounded;

    [Header("Shooting")]
    public Transform firePoint; // Titik di mana peluru ditembakkan
    public GameObject bulletPrefab; // Prefab peluru
    public float bulletForce = 20f; // Kecepatan peluru

    // Start is called before the first frame update
    void Start()
    {

    }

    void Update()
    {
        if (isMove)
        {
            Movement();

            if (Input.GetMouseButtonDown(1))
            {
                Attack();
            }
        }

        if (Input.GetMouseButtonDown(0))
        {
            Shot();
        }

        // Rotate player towards the mouse cursor when shooting
        if (Input.GetMouseButtonDown(0) && animPistol.activeSelf)
        {
            RotatePlayerTowardsMouse();
        }
    }

    private void Shot()
    {
        // Check if animPistol is active before shooting
        if (animPistol.activeSelf)
        {
            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            Rigidbody rb = bullet.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.AddForce(firePoint.up * bulletForce, ForceMode.Impulse);
            }
            Destroy(bullet, 2.0f);
        }
    }

    // Rotate player towards the mouse cursor
    private void RotatePlayerTowardsMouse()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            Vector3 mouseDir = hit.point - transform.position;
            mouseDir.y = 0f; // Keep the rotation only in the horizontal plane
            Quaternion toRotation = Quaternion.LookRotation(mouseDir, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed2 * Time.deltaTime);
        }
    }

    // Player Bergerak
    void Movement()
    {
        if (!isMove)
        {
            // Player is not allowed to move while attacking
            return;
        }

        // Gerak Kanan Kiri
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        // Normalize the movement vector to ensure consistent speed
        Vector3 movementDirection = new Vector3(moveX, 0, moveZ).normalized;
        characterController.Move(movementDirection * movementSpeed * Time.deltaTime);

        // Animasi
        float moveMagnitude = movementDirection.magnitude;

        // Set the "isRunning" parameter in the Animator
        animator.SetBool("isRunning", moveMagnitude > 0);

        // Rotasi
        if (movementDirection != Vector3.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(movementDirection, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
        }

        // Gravitasi
        velocity.y += gravity * Time.deltaTime;
        characterController.Move(velocity * Time.deltaTime);

        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -4f;
        }
    }

    void Attack()
    {
        //isMove = true;
        animAttack.SetActive(true);
        animIdle.SetActive(false);
        StartCoroutine(ChangeAnimIdleToAttack());
    }

    private IEnumerator ChangeAnimIdleToAttack()
    {
        yield return new WaitForSeconds(durationAttack);
        animAttack.SetActive(false);
        animIdle.SetActive(true);

        // Set isMove back to true after the attack animation is finished
        //isMove = true;
    }

    public void Pistol()
    {
        animPistol.SetActive(true);
        animIdle.SetActive(false);
        isMove = false;  // Disable movement and attack when using the pistol
        StartCoroutine(ShotToIdle());
    }

    private IEnumerator ShotToIdle()
    {
        yield return new WaitForSeconds(10);
        animPistol.SetActive(false);
        animIdle.SetActive(true);
        isMove = true;
    }
}
