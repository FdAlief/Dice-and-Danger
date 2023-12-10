using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UseCardHealth : MonoBehaviour
{
    public int hargaCard;
    public int bonusHealth = 6;
    private PlayerHealth playerHealth;

    private void Start()
    {
        playerHealth = FindObjectOfType<PlayerHealth>();
    }

    public void onClickButton()
    {
        if (PointManager.totalPoint >= hargaCard)
        {
            PointManager.totalPoint -= hargaCard;
            playerHealth.currentHealth += bonusHealth;
            Destroy(gameObject);
        }
        else
        {
            Debug.Log("Uang nya gk ada mank");
        }
    }
}
